using FluentValidation;
using WebAPI_Teledok.DTO;

namespace WebAPI_Teledok.Validation
{
    public class FounderValidator : FluentValidation.AbstractValidator<FounderDTO>
    {
        public FounderValidator() 
        {

            RuleFor(f => f.INNFounder)
                .NotEmpty().WithMessage("ИНН не может быть пустым.")
                .Length(10, 12).WithMessage("ИНН должен быть 10 или 12 символов.");

            RuleFor(f => f.SurnameFounder)
                .NotEmpty().WithMessage("Фамилия не должна быть пустой.")
                .Must(x => x != null && !string.IsNullOrWhiteSpace(x) && x.ToUpper().First() == x.First())
                .WithMessage("Первая буква фамилии должна быть заглавной.");

            RuleFor(f => f.NameFounder)
               .NotEmpty().WithMessage("Имя не должно быть пустым.")
               .Must(x => x != null && !string.IsNullOrWhiteSpace(x) && x.ToUpper().First() == x.First())
               .WithMessage("Первая буква имени должна быть заглавной.");

            RuleFor(f => f.MiddleNameFounder)
                .Must(x => string.IsNullOrEmpty(x) || x != null && !string.IsNullOrWhiteSpace(x) && x.ToUpper().First() == x.First())
                .WithMessage("Первая буква отчества должна быть заглавной.");

            RuleFor(f => f.ClientID)
                .GreaterThan(0).WithMessage("Необходимо выбрать клиента.");

        }
    }
}
