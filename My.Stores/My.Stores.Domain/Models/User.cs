using My.Store.Domain.Exceptions;
using My.Store.Domain.ValueObjects;

namespace My.Store.Domain.Models;

public class User
{
    public Guid? Id { get; set; }
    public Email Email { get; init; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Gender Gender { get; private set; }
    public DateOnly DateOfBirth { get; set; }

    public User(Email email, string firstName, string lastName, Gender gender, DateOnly dateOfBirth)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new FirstNameRequiredException();

        if (string.IsNullOrWhiteSpace(lastName))
            throw new LastNameRequiredException();

        if (dateOfBirth == default)
            throw new DateOfBirthRequiredException();

        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }
}

public enum Gender
{
    Male,
    Female,
    Other
}