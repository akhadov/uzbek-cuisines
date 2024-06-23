using System.Data.Common;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Dapper;
using Domain.Categories;
using SharedKernel;

namespace Application.Dishes.Get;
internal sealed class GetDishQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetDishQuery, DishResponse>
{
    public async Task<Result<DishResponse>> Handle(GetDishQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
                Select
                    id AS {nameof(DishResponse.Id)},
                    name AS {nameof(DishResponse.Name)}
                FROM dishes
                WHERE id = @DishId
            """;

        DishResponse? dish = await connection.QuerySingleOrDefaultAsync<DishResponse>(sql, request);

        if (dish is null)
        {
            return Result.Failure<DishResponse>(CategoryErrors.NotFound(request.DishId));
        }

        return dish;
    }
}
