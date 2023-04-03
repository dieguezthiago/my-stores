using FluentAssertions;
using Moq;
using My.Store.Domain.Abstractions.Repositories;
using My.Store.Domain.Exceptions;
using My.Store.Domain.Models;
using My.Store.Domain.Services.Implementations;
using My.Store.Domain.ValueObjects;

namespace My.Stores.Domain.Unit.Tests.Services;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_userRepositoryMock.Object);
    }

    [Fact]
    public async Task Register_EmailNotYetRegistered_SuccessfullyRegistersUser()
    {
        // Arrange
        var email = "john.doe@example.com";
        var firstName = "John";
        var lastName = "Doe";
        var gender = Gender.Male;
        var dateOfBirth = new DateOnly(1990, 1, 1);

        _userRepositoryMock
            .Setup(x => x.UserWithSameEmailExists(It.IsAny<Email>()))
            .ReturnsAsync(false);
        _userRepositoryMock
            .Setup(x => x.Add(It.IsAny<User>()))
            .Callback<User>(user => { user.Id = Guid.NewGuid(); })
            .Returns(Task.CompletedTask);

        // Act
        var result = await _userService.Register(email, firstName, lastName, gender, dateOfBirth);

        // Assert
        _userRepositoryMock.Verify(x => x.UserWithSameEmailExists(It.IsAny<Email>()), Times.Once);
        _userRepositoryMock.Verify(x => x.Add(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task Register_EmailAlreadyRegistered_ThrowsEmailAlreadyTakenException()
    {
        // Arrange
        var email = "jane.doe@example.com";
        var firstName = "Jane";
        var lastName = "Doe";
        var gender = Gender.Female;
        var dateOfBirth = new DateOnly(1995, 1, 1);

        _userRepositoryMock
            .Setup(x => x.UserWithSameEmailExists(It.IsAny<Email>()))
            .ReturnsAsync(true);

        // Act
        Func<Task> act = async () => await _userService.Register(email, firstName, lastName, gender, dateOfBirth);

        // Assert
        await act.Should()
            .ThrowAsync<EmailAlreadyTakenException>()
            .WithMessage("Email address has already been registered.");

        _userRepositoryMock.Verify(x => x.UserWithSameEmailExists(It.IsAny<Email>()), Times.Once);
        _userRepositoryMock.Verify(x => x.Add(It.IsAny<User>()), Times.Never);
    }
}