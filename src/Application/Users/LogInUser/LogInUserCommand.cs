using Application.Abstractions.Messaging;

namespace Application.Users.LogInUser;
public sealed record LoginUserCommand(string Email, string Password) : ICommand<string>;
