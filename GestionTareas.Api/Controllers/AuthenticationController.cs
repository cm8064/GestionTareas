using GestionTareas.Api.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace GestionTareas.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequestModel loginModel)
        {
            try
            {
                Log.Information("Start method: " + Request.GetDisplayUrl().ToString());

                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.ToString());
            }

        }
    }
}
