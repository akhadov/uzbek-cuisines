using FluentValidation;

namespace Application.Users.RegisterUser;
internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty().WithErrorCode(UserErrorCodes.CreateUser.MissingFirstName);

        RuleFor(c => c.LastName)
            .NotEmpty().WithErrorCode(UserErrorCodes.CreateUser.MissingLastName);

        RuleFor(c => c.Email)
            .NotEmpty().WithErrorCode(UserErrorCodes.CreateUser.MissingEmail)
            .EmailAddress().WithErrorCode(UserErrorCodes.CreateUser.InvalidEmail);

        RuleFor(c => c.Password).NotEmpty().MinimumLength(5);
    }
}
