using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Dishes;
using SharedKernel;

namespace Application.Dishes.Update;
internal sealed class UpdateDishCommandHandler(
    IDishRepository dishRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateDishCommand, Guid>
{
    public async Task<Result<Guid>> Handle(UpdateDishCommand request, CancellationToken cancellationToken)
    {
        Dish? dish = await dishRepository.GetByIdAsync(request.DishId, cancellationToken);

        if (dish is null)
        {
            return Result.Failure<Guid>(DishErrors.NotFound(request.DishId));
        }

        dish.Update(request.Name);

        dishRepository.Update(dish);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return dish.Id;
    }
}
