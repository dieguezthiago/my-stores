using My.Store.Domain.Models;

namespace My.Store.Domain.Services;

public interface IUserService
{
    Task<Guid> Register(string email, string firstName, string lastName, Gender gender, DateOnly dateOfBirth);
}