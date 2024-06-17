using Application.Recipes.AddIngredients;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Recipes;

public class AddIngredient : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("recipes/{recipeId}/ingredients", async (
            Guid recipeId,
            List<IngredientRequest> ingredients,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new AddIngredientsCommand(recipeId, ingredients);

            Result result = await sender.Send(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Recipes);
    }
}
