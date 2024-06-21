
using Application.Dishes.Remove;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Dishes;

internal sealed class RemoveDish : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("dishes/{dishId}", async (
            Guid dishId,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var query = new RemoveDishCommand(dishId);

            Result result = await sender.Send(query, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Dishes);
    }
}
