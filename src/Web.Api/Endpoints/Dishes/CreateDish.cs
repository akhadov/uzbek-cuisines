using Application.Dishes.Create;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Dishes;

internal sealed class CreateDish : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("dishes", async (
            CreateDishRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateDishCommand(
                request.Name);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Dishes);
    }
}
