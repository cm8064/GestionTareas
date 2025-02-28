namespace GestionTareas.Api.Models.Request
{
    public class LoginRequestModel
    {
        public string IdentifierCode { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
