using Application.Reviews.Update;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Reviews;

internal sealed class UpdateReview : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("reviews/{reviewId}", async (
            Guid reviewId,
            UpdateReviewRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateReviewCommand(
                reviewId,
                request.Rating,
                request.Comment);

            Result result = await sender.Send(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Reviews);
    }
}
