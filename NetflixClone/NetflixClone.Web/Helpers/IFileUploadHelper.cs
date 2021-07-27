using Microsoft.AspNetCore.Http;

namespace NetflixClone.Web.Helpers
{
    public interface IFileUploadHelper
    {
        string UploadFile(IFormFile file);
    }
}
