using Application.Abstractions.Messaging;

namespace Application.Reviews.Update;
public sealed record UpdateReviewCommand(Guid ReviewId, int Rating, string Comment) : ICommand;
