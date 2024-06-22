using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Reviews;
using SharedKernel;

namespace Application.Reviews.Remove;
internal sealed class RemoveReviewCommandHandler(
    IReviewRepository reviewRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RemoveReviewCommand>
{
    public async Task<Result> Handle(RemoveReviewCommand request, CancellationToken cancellationToken)
    {
        Review? review = await reviewRepository.GetByIdAsync(request.ReviewId, cancellationToken);

        if (review is null)
        {
            return Result.Failure(ReviewErrors.NotFound(request.ReviewId));
        }

        reviewRepository.Remove(review);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
