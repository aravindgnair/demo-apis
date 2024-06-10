using Demo.AuthJwt.Data.Models;
using Demo.AuthJwt.Data.Repositories.Interfaces;

namespace Demo.AuthJwt.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users =
    [
        new User { Id = 1, FirstName = "Alice", Email = "alice@tailspin.com", Password = AppConstants.EncryptedPassword },
        new User { Id = 2, FirstName = "Bob", Email = "bob@tailspin.com", Password = AppConstants.EncryptedPassword }
    ];

    public Task<User?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByEmail(string email)
    {
        return Task.FromResult(_users.SingleOrDefault(z => z.Email == email));
    }

    public Task Create(User user)
    {
        _users.Add(user);

        return Task.FromResult(true);
    }

    public Task Update(User user)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}