using GestionTareas.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace GestionTareas.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private RptaGeneral _rptaGeneral;

        [HttpPost]
        [Route("Task")]
        public async Task<IActionResult> Create()
        {
            try
            {
                Log.Information("Start method: " + Request.GetDisplayUrl().ToString());

                return Ok(_rptaGeneral);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("Task")]
        public async Task<IActionResult> Get()
        {
            try
            {
                Log.Information("Start method: " + Request.GetDisplayUrl().ToString());

                return Ok(_rptaGeneral);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpPatch]
        [Route("Check")]
        public async Task<IActionResult> Check()
        {
            try
            {
                Log.Information("Start method: " + Request.GetDisplayUrl().ToString());

                return Ok(_rptaGeneral);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete()
        {
            try
            {
                Log.Information("Start method: " + Request.GetDisplayUrl().ToString());

                return Ok(_rptaGeneral);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

    }
}
