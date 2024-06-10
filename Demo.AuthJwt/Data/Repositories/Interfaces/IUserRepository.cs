using Demo.AuthJwt.Data.Models;

namespace Demo.AuthJwt.Data.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetById(int id);

    Task<User?> GetByEmail(string email);

    Task Create(User user);

    Task Update(User user);

    Task Delete(int id);
}