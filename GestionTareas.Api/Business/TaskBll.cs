using GestionTareas.Api.Infrastructure;
using GestionTareas.Api.Models;
using GestionTareas.Api.Models.Request;
using GestionTareas.Api.Utility;
using Serilog;

namespace GestionTareas.Api.Business
{
    public class TaskBll
    {
        private RptaGeneral _rptaGeneral;
        private DbContext _newDbContext;

        public TaskBll(RptaGeneral rptaGeneral, DbContext DbContext)
        {

            _rptaGeneral = rptaGeneral;
            _newDbContext = DbContext;

            _rptaGeneral.code = 0;
            _rptaGeneral.message = null;
            _rptaGeneral.data = null;
            _rptaGeneral.objectResponse = null;

        }

        public RptaGeneral Create(TaskCreateRequestModel taskCreateModel)
        {
            try
            {
                Log.Information("Start method: TaskBll-Create");

                return _newDbContext.Create(taskCreateModel);
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
                _rptaGeneral.code = 500;
                _rptaGeneral.message = ex.Message;
                _rptaGeneral.data = ex.ToString();
                return _rptaGeneral;
            }
            
        }

        public RptaGeneral ListAll()
        {
            try
            {
                Log.Information("Start method: TaskBll-ListAll");

                return _newDbContext.Select();
                
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                _rptaGeneral.code = 500;
                _rptaGeneral.message = ex.Message;
                _rptaGeneral.data = ex.ToString();
                return _rptaGeneral;
            }

        }

    }
}
