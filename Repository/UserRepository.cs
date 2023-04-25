using Users.API.Data;
using Users.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Users.API.Repository
{
  public class UserRepository : IUserRepository
  {
    private readonly UserContext _context;
    public UserRepository(UserContext context)
    {
      this._context = context;
    }
   
    public void DeleteUser(User user)
    {
      _context.Users.Remove(user);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
      return await _context.Users.ToListAsync();
    }

    public async Task<User> GetById(int id)
    {
      return await _context.Users.FindAsync(id);
    }

    public void CreateUser(User user)
    {
      _context.Add(user);
    }

    public void UpdateUser(User user)
    {
      _context.Users.Update(user);
    }

    public async Task<bool> SaveChangesAsync() {
      return await _context.SaveChangesAsync() > 0;
    }

    public async Task<User> GetByLogin (string email) {
      var userFounded =  _context.Users.Where(x => x.Email == email).Single();
      return userFounded;
    }
  }
}