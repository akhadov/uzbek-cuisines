using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Recipes;
using Domain.Reviews;
using SharedKernel;

namespace Application.Reviews.AddReview;
internal sealed class AddReviewCommandHandler(
    IRecipeRepository recipeRepository,
    IReviewRepository reviewRepository,
    IUnitOfWork unitOfWork,
    IDateTimeProvider dateTimeProvider) : ICommandHandler<AddReviewCommand>
{
    public async Task<Result> Handle(AddReviewCommand request, CancellationToken cancellationToken)
    {
        Recipe? recipe = await recipeRepository.GetByIdAsync(request.RecipeId, cancellationToken);

        if (recipe is null)
        {
            return Result.Failure(RecipeErrors.NotFound(request.RecipeId));
        }

        Result<Rating> ratingResult = Rating.Create(request.Rating);

        if (ratingResult.IsFailure)
        {
            return Result.Failure(ratingResult.Error);
        }

        Result<Review> reviewResult = Review.Create(
            recipe,
            ratingResult.Value,
            new Comment(request.Comment),
            dateTimeProvider.UtcNow);

        if (reviewResult.IsFailure)
        {
            return Result.Failure(reviewResult.Error);
        }

        reviewRepository.Add(reviewResult.Value);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
