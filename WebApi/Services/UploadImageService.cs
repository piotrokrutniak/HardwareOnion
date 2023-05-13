using Application.DTOs.Email;
using Application.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DriveFile = Google.Apis.Drive.v3.Data.File;
namespace WebApi.Services
{
    public class UploadImageService : IUploadImageService
    {
        private GoogleCredential Credentials;
        public DriveService driveService;
        public UploadImageService()
        {
            string[] scopes = new string[] {

                                                 DriveService.Scope.Drive,
                                                 DriveService.Scope.DriveFile,
                                                 DriveService.Scope.DriveMetadata,
                                                 DriveService.Scope.DriveAppdata,
                                                 DriveService.Scope.DriveScripts
                };

            string directory = AppDomain.CurrentDomain.BaseDirectory + "credentials.json";
            Credentials = GoogleCredential.FromStream(new FileStream("credentials.json", FileMode.Open, FileAccess.Read)).CreateScoped(scopes);
            driveService = new DriveService(new BaseClientService.Initializer
            {
                ApplicationName = "HardwareOnion",
                HttpClientInitializer = Credentials
            });
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            try
            {
                DriveFile fileMetadata = new()
                {
                    Name = file.FileName,
                    WritersCanShare = true,
                };

                Permission readable = new Permission()
                {
                    Type = "anyone",
                    Role = "reader"
                };

                var stream = file.OpenReadStream();

                var request = driveService.Files.Create(fileMetadata, stream, "image/jpeg");
                request.Fields = "id, webContentLink, webViewLink, name";

                var exception = await request.UploadAsync();

                if (exception.Exception != null)
                {
                    throw new ExternalException(exception.Exception.Message);
                }

                var id = request.ResponseBody.Id;

                var permissionRequest = driveService.Permissions.Create(readable, id);
                await permissionRequest.ExecuteAsync();

                ////
                //// Direct image link template
                //// https://drive.google.com/uc?export=view&id={id}
                ////

                return $"https://drive.google.com/uc?export=view&id={id}";
            }
            catch (Exception e)
            {
                // TODO(developer) - handle error appropriately
                if (e is AggregateException)
                {
                    Console.WriteLine("Credentials Not found");
                }
                else if (e is FileNotFoundException)
                {
                    Console.WriteLine("File not found");
                }
                else
                {
                    throw;
                }
            }
            
            return null;

        }

        public async Task<string> GetImages(int pageSize)
        {
            var request = driveService.Files.List();
            request.PageSize = pageSize;

            var response = await request.ExecuteAsync();
            
            return response.Files.ToString();
        }

        public async Task<bool> DeleteImage(string imageId)
        {
            var request = driveService.Files.Delete(imageId);
            bool success = request.ExecuteAsync().IsCompletedSuccessfully;

            return success;
        }
    }
}
