using FluentValidation;
using GestionTareas.Api.Models.Request;

namespace GestionTareas.Api.Validations
{
    public class TaskCreateValidation: AbstractValidator<TaskCreateRequestModel>
    {
        public TaskCreateValidation()
        {
            RuleFor(x => x.taskName).NotEmpty().WithMessage("El campo: -{PropertyName}- es requerido");
        }
        
    }
}
