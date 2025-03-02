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

                Guid guidConvertido = Guid.Parse(loginModel.IdentifierCode);

                /*
                var query = _InfraIntegrador.FindByGuid(guidConvertido, loginModel.User);

                if (query != null)
                {
                    _rptaGeneral.code = 200;

                    //Valida que no este inactivo
                    if (query.IntegradorEstado == false)
                        _rptaGeneral.message = "El código de integrador se encuentra inactivo.";

                    //Valida que el usuario y contraseña coincidan
                    if (query.IntegradorContrasena == loginModel.Password)
                    {
                        //Armar Token JWT
                        _rptaGeneral.message = "Login exitoso";

                        LoginResponseModel newLoginResponseModel = new LoginResponseModel()
                        {
                            token = _nuevoCustom.GenerarJWT(query.IntegradorId, query.IntegradorIdentificacion.ToString(), query.IntegradorUsuario)
                        };

                        _rptaGeneral.objectResponse = newLoginResponseModel;
                    }
                    else
                    {
                        _rptaGeneral.message = "El código y/ó la contraseña no coinciden.";
                    }

                }
                else
                {
                    _rptaGeneral.code = 404;
                    _rptaGeneral.message = "Código de integrador no encontrado.";
                }

                */

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
