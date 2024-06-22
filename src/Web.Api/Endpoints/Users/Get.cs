﻿using Application.Users.GetById;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Users;

public class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/{userId}", async (
            Guid userId,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var query = new GetUserByIdQuery(userId);

            Result<UserResponse> result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .HasPermission(Permissions.UsersRead)
        .WithTags(Tags.Users);
    }
}
