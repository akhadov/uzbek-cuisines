using SharedKernel;

namespace Domain.Users;

public sealed record FirstName
{
    public FirstName(string? value)
    {
        Ensure.NotNullOrEmpty(value);

        Value = value;
    }

    public string Value { get; }
}
