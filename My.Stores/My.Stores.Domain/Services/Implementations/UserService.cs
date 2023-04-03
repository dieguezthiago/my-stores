using My.Store.Domain.Abstractions.Repositories;
using My.Store.Domain.Exceptions;
using My.Store.Domain.Models;
using My.Store.Domain.ValueObjects;

namespace My.Store.Domain.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Register(string email, string firstName, string lastName, Gender gender, DateOnly dateOfBirth)
    {
        var emailParsed = Email.Parse(email);

        if (await _userRepository.UserWithSameEmailExists(emailParsed))
            throw new EmailAlreadyTakenException();

        var newUser = new User(emailParsed, firstName, lastName, gender, dateOfBirth);

        await _userRepository.Add(newUser);

        return (Guid) newUser.Id!;
    }
}