using Application.Dishes.Get;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Dishes;

internal sealed class GetDish : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("dishes/{dishId}", async (
            Guid dishId,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var query = new GetDishQuery(dishId);

            Result<DishResponse> result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Dishes);
    }
}
