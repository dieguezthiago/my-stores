using FluentAssertions;
using My.Store.Domain.Exceptions;
using My.Store.Domain.Models;
using My.Store.Domain.ValueObjects;

namespace My.Stores.Domain.Unit.Tests.Models;

public class UserTests
{
    [Fact]
    public void Constructor_ValidArguments_CreatesUser()
    {
        // Arrange
        var email = Email.Parse("john.doe@example.com");
        var firstName = "John";
        var lastName = "Doe";
        var gender = Gender.Male;
        var dateOfBirth = new DateOnly(1990, 1, 1);

        // Act
        var user = new User(email, firstName, lastName, gender, dateOfBirth);

        // Assert
        user.Email.Should().Be(email);
        user.FirstName.Should().Be(firstName);
        user.LastName.Should().Be(lastName);
        user.Gender.Should().Be(gender);
        user.DateOfBirth.Should().Be(dateOfBirth);
    }

    [Fact]
    public void Constructor_NullFirstName_ThrowsFirstNameRequiredException()
    {
        // Arrange
        var email = Email.Parse("john.doe@example.com");
        string firstName = null;
        var lastName = "Doe";
        var gender = Gender.Male;
        var dateOfBirth = new DateOnly(1990, 1, 1);

        // Act
        Action act = () => new User(email, firstName, lastName, gender, dateOfBirth);

        // Assert
        act.Should().Throw<FirstNameRequiredException>()
            .WithMessage("First name is required.");
    }

    [Fact]
    public void Constructor_WhiteSpaceFirstName_ThrowsFirstNameRequiredException()
    {
        // Arrange
        var email = Email.Parse("john.doe@example.com");
        var firstName = " ";
        var lastName = "Doe";
        var gender = Gender.Male;
        var dateOfBirth = new DateOnly(1990, 1, 1);

        // Act
        Action act = () => new User(email, firstName, lastName, gender, dateOfBirth);

        // Assert
        act.Should().Throw<FirstNameRequiredException>()
            .WithMessage("First name is required.");
    }

    [Fact]
    public void Constructor_NullLastName_ThrowsLastNameRequiredException()
    {
        // Arrange
        var email = Email.Parse("john.doe@example.com");
        var firstName = "John";
        string lastName = null;
        var gender = Gender.Male;
        var dateOfBirth = new DateOnly(1990, 1, 1);

        // Act
        Action act = () => new User(email, firstName, lastName, gender, dateOfBirth);

        // Assert
        act.Should().Throw<LastNameRequiredException>()
            .WithMessage("Last name is required.");
    }

    [Fact]
    public void Constructor_WhiteSpaceLastName_ThrowsLastNameRequiredException()
    {
        // Arrange
        var email = Email.Parse("john.doe@example.com");
        var firstName = "John";
        string lastName = " ";
        var gender = Gender.Male;
        var dateOfBirth = new DateOnly(1990, 1, 1);

        // Act
        Action act = () => new User(email, firstName, lastName, gender, dateOfBirth);

        // Assert
        act.Should().Throw<LastNameRequiredException>()
            .WithMessage("Last name is required.");
    }

    [Fact]
    public void Constructor_DefaultDateOfBirth_ThrowsDateOfBirthRequiredException()
    {
        // Arrange
        var email = Email.Parse("john.doe@example.com");
        var firstName = "John";
        var lastName = "Doe";
        var gender = Gender.Male;
        var dateOfBirth = default(DateOnly);

        // Act
        Action act = () => new User(email, firstName, lastName, gender, dateOfBirth);

        // Assert
        act.Should()
            .Throw<DateOfBirthRequiredException>()
            .WithMessage("Date of birth is required.");
    }
}