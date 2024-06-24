
using Application.Users.GetLoggedInUser;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Users;

internal sealed class GetLoggedInUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/me", async (
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var query = new GetLoggedInUserQuery();

            Result<UserResponse> result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .HasPermission(Permissions.UsersRead)
        .WithTags(Tags.Users);
    }
}
