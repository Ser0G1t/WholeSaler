using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WholeSaler.Exceptions;
using WholeSaler.IService;

namespace WholeSaler.Controller
{
    public class ImportController
    {
        private readonly IImportService _importService;

        public ImportController(IImportService importService)
        {
            _importService = importService;
        }
        [Authorize(Roles = "manager")]
        [HttpPost("import")]
        public async Task <ActionResult<string>> importAssortments([FromRoute] string format, [FromForm] IFormFile file)
        {
            if(file is null || file.Length < 0)
            {
                throw new EmptyFileException("File is empty!");
            }
            
            await _importService.Import(format, file);
            return ("File has been imported");
        }
    }
}
