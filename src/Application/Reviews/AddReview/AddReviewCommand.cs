using Application.Abstractions.Messaging;

namespace Application.Reviews.AddReview;
public sealed record AddReviewCommand(Guid RecipeId, int Rating, string Comment) : ICommand;
