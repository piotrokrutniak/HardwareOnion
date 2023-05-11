using Application.DTOs.Email;
using Application.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

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

            //Add credentials file from Google API to project base directory
            string directory = AppDomain.CurrentDomain.BaseDirectory + "credentials.json";
            //Credentials = GoogleCredential.FromJson(File.ReadAllText(directory)).CreateScoped();
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
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = file.FileName
                };

                var stream = file.OpenReadStream();

                var request = driveService.Files.Create(fileMetadata, stream, "image/jpeg");
                request.Fields = "id, webContentLink, webViewLink, name";
                //await request.UploadAsync();
                var exception = await request.UploadAsync();
                string exceptionMessage;
                if (exception.Exception != null)
                {
                    exceptionMessage = exception.Exception.Message;
                }
                var response = request.ResponseBody;

                return response.WebViewLink;
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

    }
}
