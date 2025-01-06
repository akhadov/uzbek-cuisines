using System.Data.Common;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Abstractions.Models;
using Application.Categories.Get;
using Dapper;
using SharedKernel;

namespace Application.Categories.GetAll;
internal sealed class GetCategoriesQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetCategoriesQuery, PaginatedList<CategoryResponse>>
{
    public async Task<Result<PaginatedList<CategoryResponse>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string countSql = @"
                SELECT COUNT(*)
                FROM categories
            ";

        const string sql = @"
                SELECT
                    id AS Id,
                    name AS Name
                FROM categories
                ORDER BY id
                OFFSET @Offset ROWS
                FETCH NEXT @PageSize ROWS ONLY
            ";

        int totalCount = await connection.ExecuteScalarAsync<int>(countSql);

#pragma warning disable IDE0037 // Use inferred member name
        IEnumerable<CategoryResponse> categories = await connection.QueryAsync<CategoryResponse>(sql, new { Offset = (request.PageNumber - 1) * request.PageSize, PageSize = request.PageSize });
#pragma warning restore IDE0037 // Use inferred member name


        var paginatedCategories = new PaginatedList<CategoryResponse>(categories.ToList(), totalCount, request.PageNumber, request.PageSize);

        return Result.Success(paginatedCategories);
    }
}
