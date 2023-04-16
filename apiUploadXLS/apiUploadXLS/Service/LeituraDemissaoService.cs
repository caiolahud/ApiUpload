using apiUploadXLS.Models;
using apiUploadXLS.Util;
using OfficeOpenXml;

namespace apiUploadXLS.Service
{
    public class LeituraDemissaoService
    {
        private readonly Stream _stream;

        public LeituraDemissaoService(Stream stream)
        {
            _stream = stream;
        }

        public List<Demissao> LeituraXLS()
        {
            var response = new List<Demissao>();

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

                    var listaDemissao = new Demissao
                    {
                        IdEmpresa = obterValorCelula.ObterValor(row, 1),
                        IdFuncionario = obterValorCelula.ObterValor(row, 2),
                        DataDemissao = obterValorCelula.ObterValor(row, 3),
                        Motivo = Convert.ToInt32(obterValorCelula.ObterValor(row, 4))
                        
                    };
                    response.Add(listaDemissao);
                }

            }
            
            return response;

        }
    }
}
