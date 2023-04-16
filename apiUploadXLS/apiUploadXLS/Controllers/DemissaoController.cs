using apiUploadXLS.Service;
using apiUploadXLS.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net;

namespace apiUploadXLS.Controllers
{
    [Route("api/demissao/")]
    [ApiController]
    public class DemissaoController : ControllerBase
    {

        private readonly IWebHostEnvironment _environment;

        public DemissaoController(IWebHostEnvironment environment)
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

                var streamFile = new LeituraStreamService(file).LeituraStream();

                var demissoes = new LeituraCargoService(streamFile).LeituraXLS();

                var headerAutenticacao = GerarSenhaService.GerarSenha();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", headerAutenticacao);

                    HttpResponseMessage? response = null;

                    foreach (var demissao in demissoes)
                    {
                        var conteudo = ConvertToJson.Tojson(demissao);

                        response = httpClient.PostAsJsonAsync("https://app.sgg.net.br/api/v3/demissao/", conteudo).Result;

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
