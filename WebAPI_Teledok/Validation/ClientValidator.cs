using FluentValidation;
using WebAPI_Teledok.DTO;

namespace WebAPI_Teledok.Validation
{
    public class ClientValidator : FluentValidation.AbstractValidator<ClientDTO>
    {
        public ClientValidator() 
        {
            RuleFor(f => f.INNClient)
              .NotEmpty().WithMessage("ИНН не может быть пустым.")
              .Length(10, 12).WithMessage("ИНН должен быть 10 или 12 символов.");

            RuleFor(f => f.TypeOfClientID)
               .GreaterThan(0).WithMessage("Необходимо выбрать клиента.");

        }
    }
}
