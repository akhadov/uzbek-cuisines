using Application.Recipes.Update;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Recipes;

internal sealed class UpdateRecipe : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("recipes/{recipeId}", async (
            Guid recipeId,
            UpdateRecipeRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateRecipeCommand(
                recipeId,
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
