using Users.API.Model;

namespace Users.API.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);

        Task<bool> SaveChangesAsync();

        Task<User> GetByLogin(string email);
    }
}