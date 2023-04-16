using OfficeOpenXml;

namespace apiUploadXLS.Util
{
    public class ObterValorCelula
    {
        private readonly ExcelWorksheet _excelWorksheet;

        public ObterValorCelula(ExcelWorksheet excelWorksheet)
        {
            _excelWorksheet = excelWorksheet;
        }

        public virtual string ObterValor(int row, int coluna)
        {
            //obter o valor da linha pela coluna
            var valorCelula = _excelWorksheet.Cells[row, coluna].Value;
            string valor = valorCelula?.ToString() ?? string.Empty;
            return valor;
        }


    }
}
