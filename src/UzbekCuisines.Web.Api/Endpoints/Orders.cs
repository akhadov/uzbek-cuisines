using Carter;
using MediatR;
using UzbekCuisines.Application.Orders.Create;
using UzbekCuisines.Application.Orders.GetOrderSummary;

namespace UzbekCuisines.Web.Api.Endpoints;

public class Orders : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("orders", async (Guid customerId, ISender sender) =>
        {
            var command = new CreateOrderCommand(customerId);

            await sender.Send(command);

            return Results.Ok();
        });

        app.MapGet("orders/{id}/summary", async (Guid id, ISender sender) =>
        {
            var query = new GetOrderSummaryQuery(id);

            return Results.Ok(await sender.Send(query));
        });
    }
}
