using System.Data.Common;
using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Dapper;
using SharedKernel;

namespace Application.Users.GetById;
internal sealed class GetUserByIdQueryHandler(
    IDbConnectionFactory dbConnectionFactory,
    IUserContext userContext) : IQueryHandler<GetUserByIdQuery, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql = """
            SELECT
                id AS Id,
                first_name AS FirstName,
                last_name AS LastName,
                email AS Email
            FROM users
            WHERE id = @Id
            """;

        UserResponse user = await connection.QuerySingleAsync<UserResponse>(
            sql,
            new
            {
                userContext.UserId
            });

        return user;
    }
}
