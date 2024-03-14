using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ImageHostingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetImage(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                return Ok(path);
            }
            return BadRequest();
        }

        [HttpGet("/{FileName}")]
        public ActionResult Image(string FileName)
        {
            string path = Path.GetFullPath("/Files/" + FileName); //validate the path for security or use other means to generate the path.
            return PhysicalFile(path, "image/jpeg");
        }
    }
}
