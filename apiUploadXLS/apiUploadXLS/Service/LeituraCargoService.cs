using apiUploadXLS.Models;
using apiUploadXLS.Util;
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

                rowCount = worksheet.Cells.Where(c => !string.IsNullOrEmpty(c.Value?.ToString() ?? string.Empty)).LastOrDefault().End.Row; 

                //Começa na row 2 para ignorar o cabeçalho na row 1
                for (int row = 2; row <= rowCount; row++)
                {
                    var obterValorCelula = new ObterValorCelula(worksheet);

                    var listaCargo = new CargoFuncionario
                    {   
                        IdEmpresa = obterValorCelula.ObterValor(row,1),
                        CodigoRH = obterValorCelula.ObterValor(row, 2),
                        CodigoEsocial = Convert.ToInt32(obterValorCelula.ObterValor(row, 3)),
                        CBO = obterValorCelula.ObterValor(row, 4),
                        Cargo = obterValorCelula.ObterValor(row, 5),
                        Funcao = obterValorCelula.ObterValor(row, 6),
                        DescricaoAtividades = obterValorCelula.ObterValor(row, 7),
                        RequisitosdaFuncao = obterValorCelula.ObterValor(row, 8),
                        Recomendacoes = obterValorCelula.ObterValor(row, 9),
                        ProcedimentosAcidentes = obterValorCelula.ObterValor(row, 10),
                        RespEmpregado = obterValorCelula.ObterValor(row, 11),
                        Observacoes = obterValorCelula.ObterValor(row, 12),
                        AtividadesPericInsalubEspeciais = obterValorCelula.ObterValor(row, 13),
                        IdSetor = obterValorCelula.ObterValor(row, 14),
                        Setor = obterValorCelula.ObterValor(row, 15)

                    };
                   response.Add(listaCargo);
                }

            }

            return response;


        }
    }
}
