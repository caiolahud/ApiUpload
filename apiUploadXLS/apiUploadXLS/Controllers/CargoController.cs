﻿using apiUploadXLS.Models;
using apiUploadXLS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using apiUploadXLS.Util;

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

                var cargos =  new LeituraCargoService(streamFile).LeituraXLS();

                var headerAutenticacao = GerarSenhaService.GerarSenha();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", headerAutenticacao);

                    HttpResponseMessage? response = null;

                    foreach (var cargo in cargos)
                    {
                        var conteudo = ConvertToJson.Tojson(cargo);

                        response = httpClient.PostAsJsonAsync("https://app.sgg.net.br/api/v3/cargo/", conteudo).Result;

                        var retorno = response.Content.ReadAsStringAsync().Result;
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        //Caso a API retorne OK com status 200
                        return Ok(new { Message = "Arquivo carregado com sucesso." });
                    }
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        //Caso a API retorne status 400
                        string mensagem = response.Content.ReadAsStringAsync().Result;
                        return BadRequest(mensagem);
                    }
                    else
                    {
                        //Caso a API retorne outro status
                        return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                    }
                }                              
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
                       
        }
                
    }
}
