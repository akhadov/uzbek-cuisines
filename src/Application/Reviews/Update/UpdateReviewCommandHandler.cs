using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Reviews;
using SharedKernel;

namespace Application.Reviews.Update;
internal sealed class UpdateReviewCommandHandler(
    IReviewRepository reviewRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateReviewCommand>
{
    public async Task<Result> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        Review? review = await reviewRepository.GetByIdAsync(request.ReviewId, cancellationToken);

        if (review is null)
        {
            return Result.Failure(ReviewErrors.NotFound(request.ReviewId));
        }

        Result<Rating> ratingResult = Rating.Create(request.Rating);

        if (ratingResult.IsFailure)
        {
            return Result.Failure(ratingResult.Error);
        }

        review.Update(ratingResult.Value, new Comment(request.Comment));

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
