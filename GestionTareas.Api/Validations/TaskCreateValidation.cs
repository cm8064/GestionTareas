using FluentValidation;
using GestionTareas.Api.Models.Request;

namespace GestionTareas.Api.Validations
{
    public class TaskCreateValidation: AbstractValidator<TaskCreateRequestModel>
    {
        public TaskCreateValidation()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("El campo: -{PropertyName}- es requerido");

            RuleFor(x => x.name).NotEqual("string").WithMessage("El campo: -{PropertyName} requiere un valor válido.");

            RuleFor(x => x.name).MinimumLength(3).WithMessage("El campo: -{PropertyName}- debe ser mínimo de 3 caracteres");

            RuleFor(x => x.name).MaximumLength(100).WithMessage("El campo: -{PropertyName}- debe ser máximo de 100 caracteres");
            
        }
        
    }
}
