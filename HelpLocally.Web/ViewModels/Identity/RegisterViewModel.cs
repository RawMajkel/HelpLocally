using FluentValidation;

namespace HelpLocally.Web.ViewModels.Identity
{
    public class RegisterViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Login must not me empty");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password must not me empty")
                .MinimumLength(5).WithMessage("Password must contain at least 5 characters");
        }
    }
}
