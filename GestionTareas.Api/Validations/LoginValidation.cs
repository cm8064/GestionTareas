using FluentValidation;
using GestionTareas.Api.Models.Request;

namespace GestionTareas.Api.Validations
{
    public class LoginValidation : AbstractValidator<LoginRequestModel>
    {
        public LoginValidation()
        {
            RuleFor(x => x.IdentifierCode).NotEmpty().WithMessage("El campo: -{PropertyName}- es requerido");
            RuleFor(x => x.User).NotEmpty().WithMessage("El campo: {PropertyName}- es requerido");
            RuleFor(x => x.Password).NotEmpty().WithMessage("El campo: -{PropertyName}- es requerido");

            RuleFor(x => x.IdentifierCode).NotEqual("string").WithMessage("El campo: -{PropertyName} requiere un valor valido.");
            RuleFor(x => x.User).NotEqual("string").WithMessage("El campo: -{PropertyName} requiere un valor valido.");
            RuleFor(x => x.Password).NotEqual("string").WithMessage("El campo: -{PropertyName} requiere un valor valido.");
        }
    }
}
