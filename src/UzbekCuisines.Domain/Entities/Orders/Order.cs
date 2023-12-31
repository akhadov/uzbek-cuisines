﻿using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UzbekCuisines.Domain.Entities.Customers;

namespace UzbekCuisines.Domain.Entities.Orders;

public class Order : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("orders", async (Guid CustomerId, ISender sender) =>
        {
            var command = new CreateOrderCommand(customerId);

            await sender.Send(command);

            return Results.Ok();
        });

        app.MapGet("orders/{id}/summary", async (Guid id, ISender sender) =>
        {
            var query = new CreateOrderQuery(id);

            return Results.Ok(await sender.Send(query));

        }).RequireRateLimiting("fixed");
    }
}
