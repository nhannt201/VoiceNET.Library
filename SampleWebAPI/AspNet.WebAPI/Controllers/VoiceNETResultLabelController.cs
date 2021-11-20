using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace VoiceNET.Lib.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoiceNETResultLabelController : ControllerBase
    {

        private readonly ILogger<VoiceNETResultLabelController> _logger;

        public VoiceNETResultLabelController(ILogger<VoiceNETResultLabelController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Content("null");
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            var files = Request.Form.Files;

            var filePath = Path.GetTempFileName();

            using (var ms = new FileStream(filePath, FileMode.Create))
            {
                await files[0].CopyToAsync(ms);
            }

           //VBuilder.ModelPath ( Path.GetFullPath("MLModel.zip"));

            VBuilder.ModelPath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\SampleModel\MLModel.zip");

            return Content(VBuilder.Result(filePath));
        }

     
        

    }
}
