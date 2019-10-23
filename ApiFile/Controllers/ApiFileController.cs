using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using ApiFile.FileProcess;
using ApiFile.Models;

namespace ApiFile.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ApiFileController : ControllerBase
    {
        private readonly ILogRepository _log;
        readonly string textFileOutput = "Trip_File_Output";

        public ApiFileController(ILogRepository log)
        {
            _log = log;
        }

        //Post requets for processed file of trips.
        //Input: FileText
        //Output: File
        [HttpPost]
        [Route("PostFileTxt")]
        public IActionResult PostFileTxt([FromForm]FileText info)
        {
            if (info == null)
                return BadRequest();

            info.Date = DateTime.Now;
            _log.Add(info).Wait();
            ProcessFile processFile = new ProcessFile(new ProcessFileTxt());

            try
            {
                Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)Request.Headers["Origin"] });
                MemoryStream fileProcessed = processFile.FileProcess(info.File);
                return File(fileProcessed, "text/plain", textFileOutput);
            }
            catch (OutOfMemoryException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
