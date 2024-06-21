using Application.Categories.Update;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Categories;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/{categoryId}", async (
            Guid categoryId,
            UpdateCategoryRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateCategoryCommand(
                categoryId,
                request.Name);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Categories);
    }
}
