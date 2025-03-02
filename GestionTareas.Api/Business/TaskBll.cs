using GestionTareas.Api.Models;
using GestionTareas.Api.Models.Request;
using GestionTareas.Api.Utility;
using Serilog;

namespace GestionTareas.Api.Business
{
    public class TaskBll
    {
        private RptaGeneral _rptaGeneral;

        public TaskBll(RptaGeneral rptaGeneral)
        {

            _rptaGeneral = rptaGeneral;
            
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

                return _rptaGeneral;
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
                _rptaGeneral.message = ex.Message;
                _rptaGeneral.data = ex.ToString();
                return _rptaGeneral;
            }
            
        }

    }
}
