using DocumentSigningSolution.Domain.Common.Models;
using DocumentSigningSolution.Domain.UserAggregate.ValueObjects;

namespace DocumentSigningSolution.Domain.UserAggregate;
public sealed class User : AggregateRoot<UserId, Guid>
{
    public string FirstName { get; private set; } = "";
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; } // TODO: Hash this

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private User(
        string firstName,
        string lastName,
        string email,
        string password,
        UserId? userId = null)
        : base(userId ?? UserId.CreateUnique())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        // TODO: enforce invariants
        return new User(
            firstName,
            lastName,
            email,
            password);
    }
#pragma warning disable CS8618
    private User()
    {
    }
#pragma warning restore CS8618
}
