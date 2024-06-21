using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Dishes;
using SharedKernel;

namespace Application.Dishes.Remove;
internal sealed class RemoveDishCommandHandler(
    IDishRepository dishRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RemoveDishCommand>
{
    public async Task<Result> Handle(RemoveDishCommand request, CancellationToken cancellationToken)
    {
        Dish? dish = await dishRepository.GetByIdAsync(request.DishId, cancellationToken);

        if (dish is null)
        {
            return Result.Failure(DishErrors.NotFound(request.DishId));
        }

        dishRepository.Remove(dish);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();

    }
}
