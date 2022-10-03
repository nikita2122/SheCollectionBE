using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SheCollectionBE.Controllers
{
    public class FileController : BaseController
    {
        readonly static string homePath = (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
                                           ? Environment.GetEnvironmentVariable("HOME") : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

        readonly string sheCollectionHomePath = Path.Combine(homePath, "SheCollectionFiles");

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            string[] fileParts = file.FileName.Split(".");
            // create the new file name consisting of the current time plus a GUID
            string newFileName = DateTime.Now.Ticks + "-" + Guid.NewGuid().ToString() + "." + fileParts[fileParts.Length - 1];

            // Verify the home-guac directory exists, and combine the home-guac directory with the new file name
            Directory.CreateDirectory(sheCollectionHomePath);
            var filePath = Path.Combine(sheCollectionHomePath, newFileName);

            // Create a new file in the home-guac directory with the newly generated file name
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                //copy the contents of the received file to the newly created local file 
                await file.CopyToAsync(stream);
            }
            // return the file name for the locally stored file
            return Ok("{\"fileName\":\"" + newFileName + "\"}");
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> Download(string id)
        {
            string path = Path.Combine(sheCollectionHomePath, id);

            if (System.IO.File.Exists(path))
            {
                // Get all bytes of the file and return the file with the specified file contents 
                byte[] b = await System.IO.File.ReadAllBytesAsync(path);
                return File(b, "application/octet-stream", id);
            }
            else
            {
                // return error if file not found
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("download/banner/{id}")]
        public async Task<IActionResult> DownloadBanner(string id)
        {
            string path = Path.Combine(sheCollectionHomePath, "banners/" + id);

            if (System.IO.File.Exists(path))
            {
                // Get all bytes of the file and return the file with the specified file contents 
                byte[] b = await System.IO.File.ReadAllBytesAsync(path);
                return File(b, "application/octet-stream", id);
            }
            else
            {
                // return error if file not found
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetBanners")]
        public async Task<IActionResult> GetBanners()
        {
            string path = Path.Combine(sheCollectionHomePath, "banners");
            if (System.IO.Directory.Exists(path))
            {
                string[] paths = System.IO.Directory.EnumerateFiles(path).ToArray();
                List<string> fileNames = new List<string>(paths.Length);

                foreach (string p in paths)
                {
                    fileNames.Add(Path.GetFileName(p));
                }

                return new OkObjectResult(fileNames.ToArray());
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
