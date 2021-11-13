using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VoiceNET.Lib.Demo.ASP.NET.Models;

namespace VoiceNET.Lib.Demo.ASP.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("PostRecord")]
        public async Task<IActionResult> PostRecord()
        {
            var files = Request.Form.Files;
            //long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            //Save image
            using (var ms = new FileStream(filePath, FileMode.Create))
            {
                await files[0].CopyToAsync(ms);
            }

            VBuilder.ModelPath(Path.Combine("MLModel.zip"));

            //setWebRecord support from VoiceNET.Library >= 1.0.2.4

            VBuilder.setWebRecord(filePath);

            return Content(VBuilder.Result());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
