using EmreUgur.BackedProject.DTO.Dtos;
using FluentValidation;

namespace EmreUgur.BackedProject.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInDtoValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName can't be blank");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can't be blank.");
        }
    }
}
