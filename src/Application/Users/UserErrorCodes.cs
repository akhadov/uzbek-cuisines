namespace Application.Users;

public static class UserErrorCodes
{
    public static class CreateUser
    {
        public const string MissingFirstName = nameof(MissingFirstName);
        public const string MissingLastName = nameof(MissingLastName);
    }
}
