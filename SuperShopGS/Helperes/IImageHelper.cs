using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SuperShopGS.Helperes
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string folder);
    }
}
