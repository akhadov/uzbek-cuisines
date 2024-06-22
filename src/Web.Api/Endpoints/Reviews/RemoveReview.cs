using Application.Reviews.Remove;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Reviews;

internal sealed class RemoveReview : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("reviews/{reviewId}", async (
            Guid reviewId,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var query = new RemoveReviewCommand(reviewId);

            Result result = await sender.Send(query, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Reviews);
    }
}
