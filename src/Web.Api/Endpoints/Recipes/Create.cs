using Application.Recipes.Create;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Recipes;

public class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("recipes", async (
            CreateRecipeRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateRecipeCommand(
                request.UserId,
                request.DishId,
                request.CategoryId,
                request.Description,
                request.PrepTime,
                request.CookTime,
                request.Servings,
                request.ImagePath);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Recipes);
    }
}
