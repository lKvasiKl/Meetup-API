using Data.Entities;

namespace Data.Repositories.IRepositories
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByCredentialsAsync(string email, string password);
    }
}
