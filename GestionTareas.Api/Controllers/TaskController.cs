using GestionTareas.Api.Business;
using GestionTareas.Api.Models;
using GestionTareas.Api.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace GestionTareas.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private RptaGeneral _rptaGeneral;
        private TaskBll _taskBll;

        public TaskController(TaskBll newTaskBll)
        {
            _taskBll = newTaskBll;
        }

        [HttpPost]
        [Route("Task")]
        public async Task<IActionResult> Create(TaskCreateRequestModel taskCreateModel)
        {

            //Method for create task
            try
            {
                Log.Information("Start method: " + Request.GetDisplayUrl().ToString());

                return Ok(_taskBll.Create(taskCreateModel));
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
            //Method for list all task
            try
            {
                Log.Information("Start method: " + Request.GetDisplayUrl().ToString());

                return Ok(_taskBll.ListAll());
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
