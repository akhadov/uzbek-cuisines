using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Dishes;
using SharedKernel;

namespace Application.Dishes.Create;
internal sealed class CreateDishCommandHandler(
    IDishRepository dishRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateDishCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {

        var dish = Dish.Create(request.Name);

        dishRepository.Insert(dish);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return dish.Id;
    }
}
