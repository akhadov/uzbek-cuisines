using Application.Abstractions.Messaging;
using Application.Abstractions.Models;
using Application.Categories.Get;

namespace Application.Categories.GetAll;
public sealed record GetCategoriesQuery(int PageNumber, int PageSize) : IQuery<PaginatedList<CategoryResponse>>;
