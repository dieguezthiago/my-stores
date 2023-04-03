using My.Store.Domain.Models;
using My.Store.Domain.ValueObjects;

namespace My.Store.Domain.Abstractions.Repositories;

public interface IUserRepository
{
    Task<bool> UserWithSameEmailExists(Email email);
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(Guid id);
    Task<User> GetByEmail(Email email);
    Task Add(User user);
    Task Update(User user);
    Task Delete(User user);
}