using Microsoft.EntityFrameworkCore;
using shop_api.Data;
using shop_api.IRepository;
using shop_api.Models;

namespace shop_api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopDbContext _db;
       public UserRepository(ShopDbContext db) 
        {
            _db = db;
        }
        public void AddUser(User user)
        {
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool CheckUser(Guid Id)
        {
            return _db.Users.Any(e => e.UserId == Id);
        }

        public User DeleteUser(Guid Id)
        {
            try
            {
                User? user = _db.Users.Find(Id);

                if (user != null)
                {
                    _db.Users.Remove(user);
                    _db.SaveChanges();
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return _db.Users.ToList();
            }
            catch
            {
                throw;
            }
        }

        public User GetUserDetails(Guid Id)
        {
            try
            {
                User? user = _db.Users.Find(Id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _db.Entry(user).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
