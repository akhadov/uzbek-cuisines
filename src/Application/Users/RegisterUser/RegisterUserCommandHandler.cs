using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using SharedKernel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Users.RegisterUser;
internal sealed class RegisterUserCommandHandler(
    IPasswordHasher passwordHasher,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        string passwordHash = passwordHasher.Hash(request.Password);

        var user = User.Create(
            request.Email,
            request.FirstName,
            request.LastName,
            passwordHash);

        userRepository.Add(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
