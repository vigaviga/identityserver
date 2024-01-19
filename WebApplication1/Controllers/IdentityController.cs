using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("identity")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var d = new JsonResult(from c in User.Claims select new { c.Type, c.Value });
            return d;
        }
    }
}
