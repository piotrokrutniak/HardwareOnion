using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUploadImageService
    {
        Task<string> UploadImage(IFormFile file);
        Task<string> GetImages(int pageSize);
    }
}
