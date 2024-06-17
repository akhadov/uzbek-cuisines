namespace Application.Reviews.AddReview;
public sealed record AddReviewRequest(Guid RecipeId, int Rating, string Comment);
