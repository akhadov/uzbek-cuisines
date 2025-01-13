using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Domain.Users;
using SharedKernel;

namespace Application.Users.LogInUser;
internal sealed class LoginUserCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    ITokenProvider tokenProvider) : ICommandHandler<LoginUserCommand, string>
{
    public async Task<Result<string>> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null)
        {
            return Result.Failure<string>(UserErrors.NotFoundByEmail);
        }

        bool verified = passwordHasher.Verify(request.Password, user.PasswordHash);

        if (!verified)
        {
            return Result.Failure<string>(UserErrors.NotFoundByEmail);
        }

        string token = tokenProvider.Create(user);

        return token;
    }
}
