using GestionTareas.Api.Models;
using GestionTareas.Api.Models.Request;
using GestionTareas.Api.Models.Response;
using GestionTareas.Api.Utility;
using Serilog;

namespace GestionTareas.Api.Business
{
    public class AuthenticationBll
    {
        private RptaGeneral _rptaGeneral;
        private Custom _nuevoCustom;

        public AuthenticationBll(RptaGeneral rptaGeneral, Custom nuevoCustom)
        {

            _rptaGeneral = rptaGeneral;
            _nuevoCustom = nuevoCustom;

            _rptaGeneral.code = 0;
            _rptaGeneral.message = null;
            _rptaGeneral.data = null;
            _rptaGeneral.objectResponse = null;

        }

        public RptaGeneral Login(LoginRequestModel loginModel)
        {
            try
            {
                Log.Information("Start method: AuthenticationBll-Login");

                //Acá se recrea la forma en como llama la BD para consultar el usuario y confirmar que tenga acceso a la aplicación
                
                LoginResponseModel newLoginResponseModel = new LoginResponseModel()
                {
                    //Armar Token JWT
                    token = _nuevoCustom.GenerarJWT(loginModel.IdentifierCode.ToString(), loginModel.User)
                };

                _rptaGeneral.message = "Login exitoso";
                _rptaGeneral.objectResponse = newLoginResponseModel;

                return _rptaGeneral;

            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                _rptaGeneral.message = ex.Message;
                _rptaGeneral.data = ex.ToString();
                return _rptaGeneral;
            }
        }
    }
}
