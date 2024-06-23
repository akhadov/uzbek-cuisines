using Application.Abstractions.Messaging;

namespace Application.Categories.Get;
public sealed record GetCategoryQuery(Guid CategoryId) : IQuery<CategoryResponse>;
