using Application.Recipes.Remove;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Recipes;

internal sealed class RemoveRecipe : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("recipes/{recipeId}", async (
            Guid recipeId,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var query = new RemoveRecipeCommand(recipeId);

            Result result = await sender.Send(query, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Recipes);
    }
}
