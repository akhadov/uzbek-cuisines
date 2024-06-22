
using Application.Users.LogInUser;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Users;

internal sealed class LogIn : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/login", async (
            LogInUserRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new LogInUserCommand(
                request.Email,
                request.Password);

            Result result = await sender.Send(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .AllowAnonymous()
        .WithTags(Tags.Users);
    }
}
