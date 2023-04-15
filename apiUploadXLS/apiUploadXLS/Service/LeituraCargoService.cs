using apiUploadXLS.Models;
using OfficeOpenXml;

namespace apiUploadXLS.Service
{
    public class LeituraCargoService
    {
        private readonly Stream _stream; 
        public LeituraCargoService(Stream stream) 
        {
            _stream = stream;
        }

        public List<CargoFuncionario> LeituraXLS()
        {
            var response = new List<CargoFuncionario>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(_stream))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column;

                int rowCount = worksheet.Dimension.End.Row;

                //Começa na row 2 para ignorar o cabeçalho na row 1
                for (int row = 2; row <= rowCount; row++)
                {
                    var obterValorCelula = new ObterValorCelula(worksheet);

                    var listaCargo = new CargoFuncionario
                    {   
                        Id_empresa = obterValorCelula.ObterValor(row,1),
                        Codigo_rh = obterValorCelula.ObterValor(row, 2),
                        Codigo_esocial = obterValorCelula.ObterValor(row, 3),
                        CBO = obterValorCelula.ObterValor(row, 4),
                        Cargo = obterValorCelula.ObterValor(row, 5),
                        Funcao = obterValorCelula.ObterValor(row, 6),
                        Descricao_atividades = obterValorCelula.ObterValor(row, 7),
                        Requisitos_da_funcao = obterValorCelula.ObterValor(row, 8),
                        Recomendacoes = obterValorCelula.ObterValor(row, 9),
                        Procedimentos_acidentes = obterValorCelula.ObterValor(row, 10),
                        Resp_empregado = obterValorCelula.ObterValor(row, 11),
                        Observacoes = obterValorCelula.ObterValor(row, 12),
                        Atividades_peric_insalub_especiais = obterValorCelula.ObterValor(row, 13),
                        Id_setor = obterValorCelula.ObterValor(row, 14),
                        Setor = obterValorCelula.ObterValor(row, 15)

                    };
                   response.Add(listaCargo);
                }

            }

            return response;


        }
    }
}
