using FluentValidation;

namespace Application.Dishes.Update;
internal sealed class UpdateDishCommandValidator : AbstractValidator<UpdateDishCommand>
{
    public UpdateDishCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
