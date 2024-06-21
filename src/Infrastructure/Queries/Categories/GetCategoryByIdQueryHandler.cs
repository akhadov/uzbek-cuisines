using Application.Abstractions.Messaging;
using Application.Categories.GetById;
using Domain.Categories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Infrastructure.Queries.Categories;
internal sealed class GetCategoryByIdQueryHandler(ApplicationDbContext context)
    : IQueryHandler<GetCategoryByIdQuery, CategoryResponse>
{
    public async Task<Result<CategoryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        CategoryResponse? category = await context.Categories
            .Where(c => c.Id == request.CategoryId)
            .Select(c => new CategoryResponse
            {
                Id = c.Id,
                Name = c.Name.Value
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (category is null)
        {
            return Result.Failure<CategoryResponse>(CategoryErrors.NotFound(request.CategoryId));
        }

        return category;
    }
}
