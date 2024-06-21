using SharedKernel;

namespace Domain.Reviews;
public static class ReviewErrors
{
    public static Error NotFound(Guid reviewId) => Error.NotFound(
        "Reviews.NotFound",
        $"The review with the Id = '{reviewId}' was not found");

    public static readonly Error InvalidRating = Error.Conflict(
        "Reviews.InvalidRating",
        "The rating score is invalid");
}
