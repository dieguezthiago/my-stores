using FluentAssertions;
using My.Store.Domain.Exceptions;
using My.Store.Domain.ValueObjects;

namespace My.Stores.Domain.Unit.Tests.ValueObjects;

public class EmailTests
{
    [Theory]
    [InlineData("test@example.com")]
    [InlineData("Test@Example.com")]
    [InlineData("test.123@example.co.uk")]
    [InlineData("test-123@example.com")]
    public void Parse_WithValidInput_ReturnsEmail(string input)
    {
        // Act
        var result = Email.Parse(input);

        // Assert
        result.Should().NotBeNull();
        result.Address.Should().Be(input.Trim().ToLowerInvariant());
    }
    
    [Fact]
    public void Parse_WithNullInput_ThrowsInvalidEmailFormatException()
    {
        // Arrange
        string input = null;

        // Act
        var act = () => Email.Parse(input);

        // Assert
        act.Should().Throw<InvalidEmailFormatException>()
            .WithMessage("The email address provided is not in a valid format.");
    }

    [Fact]
    public void Parse_WithEmptyInput_ThrowsInvalidEmailFormatException()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var act = () => Email.Parse(input);

        // Assert
        act.Should().Throw<InvalidEmailFormatException>()
            .WithMessage("The email address provided is not in a valid format.");
    }

    [Fact]
    public void Parse_WithWhiteSpaceInput_ThrowsInvalidEmailFormatException()
    {
        // Arrange
        var input = "   ";

        // Act
        var act = () => Email.Parse(input);

        // Assert
        act.Should().Throw<InvalidEmailFormatException>()
            .WithMessage("The email address provided is not in a valid format.");
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("test@")]
    [InlineData("@example.com")]
    [InlineData("test@example")]
    public void Parse_WithInvalidInput_ThrowsInvalidEmailFormatException(string input)
    {
        // Act
        var act = () => Email.Parse(input);

        // Assert
        act.Should().Throw<InvalidEmailFormatException>()
            .WithMessage("The email address provided is not in a valid format.");
    }
}