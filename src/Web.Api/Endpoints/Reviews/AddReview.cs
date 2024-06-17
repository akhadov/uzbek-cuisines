using Application.Reviews.AddReview;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Reviews;

public class AddReview : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("reviews", async (
            AddReviewRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new AddReviewCommand(
                request.RecipeId, request.Rating, request.Comment);

            Result result = await sender.Send(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Reviews);
    }
}
