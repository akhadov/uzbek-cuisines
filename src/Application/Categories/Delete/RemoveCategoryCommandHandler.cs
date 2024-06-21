using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Categories;
using SharedKernel;

namespace Application.Categories.Delete;
internal sealed class RemoveCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<RemoveCategoryCommand>
{
    public async Task<Result> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = await categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            return Result.Failure(CategoryErrors.NotFound(request.CategoryId));
        }

        categoryRepository.Remove(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
