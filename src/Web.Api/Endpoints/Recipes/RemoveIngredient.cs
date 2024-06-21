using Application.Recipes.RemoveIngredients;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Recipes;

internal sealed class RemoveIngredient : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("recipes/{recipeId}/ingredients/{ingredientId}", async (
            Guid recipeId,
            Guid ingredientId,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var query = new RemoveIngredientCommand(recipeId, ingredientId);

            Result result = await sender.Send(query, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Recipes);
    }
}
