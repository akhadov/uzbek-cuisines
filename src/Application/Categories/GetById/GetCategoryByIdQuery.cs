using Application.Abstractions.Messaging;

namespace Application.Categories.GetById;
public sealed record GetCategoryByIdQuery(Guid CategoryId) : IQuery<CategoryResponse>;
