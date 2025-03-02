using GestionTareas.Api.Business;
using GestionTareas.Api.Controllers;
using GestionTareas.Api.Models;
using GestionTareas.Api.Models.Request;
using GestionTareas.Api.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.UnitTesting
{
    public class ApiTesting
    {
        private readonly AuthenticationBll newAuthenticationBll;
        private readonly AuthenticationController newAuthenticationController;

        public ApiTesting()
        {
            //Acá se puede revisar porque algunas veces el object queda null
            newAuthenticationController = new AuthenticationController(newAuthenticationBll);
        }

        [Fact]
        public void TestLoginOk()
        {
            //Preparación
            LoginRequestModel newLogin = new LoginRequestModel();
            newLogin.User = "user_test";
            newLogin.Password = "abc123_";
            newLogin.IdentifierCode = "6f47614d-b2b2-4a20-8bf1-2d0a90a27bd9";

            //Ejecuçión
            var result = newAuthenticationController.Login(newLogin);

            //Aciertos del testing
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void TestLoginBody()
        {
            //Preparación
            LoginRequestModel newLogin = new LoginRequestModel();
            newLogin.User = "user_test";
            newLogin.Password = "abc123_";
            newLogin.IdentifierCode = "6f47614d-b2b2-4a20-8bf1-2d0a90a27bd9";

            //Ejecuçión
            var result = newAuthenticationController.Login(newLogin);

            //Aciertos del testing
            var rpta = Assert.IsType<Task<IActionResult>>(result);

            //Acá me hizo falta convertir la rpta para sacar del body el token
           
        }
    }
}
