using SharedKernel;

namespace Domain.Users;

public sealed class User : Entity
{
    private readonly List<Role> _roles = new();

    private User(
        Guid id,
        Email email,
        FirstName firstName,
        LastName lastName)
        : base(id)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    private User()
    {
    }

    public Email Email { get; private set; }

    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public string IdentityId { get; private set; } = string.Empty;

    public IReadOnlyCollection<Role> Roles => _roles.ToList();

    public static User Create(Email email, FirstName firstName, LastName lastName)
    {
        var user = new User(Guid.NewGuid(), email, firstName, lastName);

        user.Raise(new UserCreatedDomainEvent(user.Id));

        user._roles.Add(Role.Registered);

        return user;
    }

    public void SetIdentityId(string identityId)
    {
        IdentityId = identityId;
    }
}
