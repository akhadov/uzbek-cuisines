using SharedKernel;

namespace Domain.Users;

public sealed class User : Entity
{
    private User(Guid id, string email, string firstName, string lastName,  string passwordHash)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        PasswordHash = passwordHash;
    }

    private User()
    {
    }

    public Guid Id { get; private set; }

    public string Email { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string PasswordHash { get; set; }


    public static User Create(string firstName, string lastName, string email, string passwordHash)
    {
        var user = new User(Guid.NewGuid(), email, firstName, lastName, passwordHash);

        user.Raise(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}
