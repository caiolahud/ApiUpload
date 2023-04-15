using apiUploadXLS.Models;
using apiUploadXLS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiUploadXLS.Controllers
{
    [Route("api/cargo/")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public CargoController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
               

        [HttpPost("upload")]
        public IActionResult UploadArquivo(IFormFile file)
        {
            try
            {  
                //recuperar a extensão do arquivo
                string extensao = Path.GetExtension(file.FileName);
               
                if (string.IsNullOrEmpty(extensao) || !extensao.Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    return BadRequest("O arquivo deve estar na extensão .xlsx");
                }

                var streamFile =  new LeituraStreamService(file).LeituraStream();

                var cargo =  new LeituraCargoService(streamFile).LeituraXLS();

                return Ok(new { Message = "Arquivo carregado com sucesso." });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
                       
        }
    }
}
