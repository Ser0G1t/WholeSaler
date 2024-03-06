using WholeSaler.Exceptions;

namespace WholeSaler.Service.ImportService
{
    public class ImportService
    {
        private IImportStrategy _importFormat;
        public async Task Import(string format, IFormFile file)
        {
            setStrategy(format);
            await _importFormat.Import(file);
        }
        private void setStrategy(string format)
        {
            switch (format.ToLower())
            {
                case "xls":
                    _importFormat = new ImportXLS();
                    break;
                default:
                    throw new FormatNotSupportedException("strategy doesnt exist!");
            }
        }
    }
}
