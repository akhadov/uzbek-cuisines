
using Application.Dishes.Update;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Dishes;

internal sealed class UpdateDish : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("dishes/{dishId}", async (
            Guid dishId,
            UpdateDishRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateDishCommand(
                dishId,
                request.Name);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Dishes);
    }
}
