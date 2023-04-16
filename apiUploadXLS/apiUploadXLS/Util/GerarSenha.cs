using System.Text;

namespace apiUploadXLS.Util
{
    public static class GerarSenhaService
    {
       
        private const string chaveApi = "C3hneqglm8PmL2Iga0nDOooEakZPIslr";
        
        private const string senha = "";
        
        private const string credenciais = $"{chaveApi}:{senha}";
        
        public static string GerarSenha()
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(credenciais);
            
            var base64Credenciais = Convert.ToBase64String(byteArray);
            
            var headerAutenticacao = $"Basic {base64Credenciais}";

            return headerAutenticacao;

        }
    }
}
