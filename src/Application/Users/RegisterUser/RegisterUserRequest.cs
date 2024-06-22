namespace Application.Users.RegisterUser;
public sealed record RegisterUserRequest(
    string Email,
    string FirstName,
    string LastName,
    string Password);
