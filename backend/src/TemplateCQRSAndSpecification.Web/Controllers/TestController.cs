using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TemplateCQRSAndSpecification.Web.Controllers
{
    public class TestController : ApplicationController
    {
        [HttpPost]
        public async Task<IActionResult> Post()
        {

            return Ok();
        }

    }
}
