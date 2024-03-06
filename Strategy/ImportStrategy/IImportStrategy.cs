namespace WholeSaler.Service.ImportService
{
    public interface IImportStrategy
    {
        Task Import(IFormFile file);
    }
}
