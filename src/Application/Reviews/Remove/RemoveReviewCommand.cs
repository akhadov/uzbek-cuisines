using Application.Abstractions.Messaging;

namespace Application.Reviews.Remove;
public sealed record RemoveReviewCommand(Guid ReviewId) : ICommand;
