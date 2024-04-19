using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Преобразование рузультата выполнения операции в HTTP ответ
        /// </summary>
        protected IActionResult ConvertFluentResultToIActionResult(Result result)
        {
            if (result.IsFailed)
                return BadRequest(string.Join(" ", result.Reasons.Select(r => r.Message)));

            return Ok();
        }
    }
}
