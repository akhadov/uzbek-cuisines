using FluentValidation;

namespace Application.Dishes.Create;
internal sealed class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }

}
