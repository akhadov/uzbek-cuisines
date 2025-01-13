
using Application.Users.LogInUser;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Users;

internal sealed class Login : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/login", async (
            LoginUserRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new LoginUserCommand(
                request.Email,
                request.Password);

            Result<string> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .AllowAnonymous()
        .WithTags(Tags.Users);
    }
}
