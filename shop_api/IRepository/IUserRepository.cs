using shop_api.Models;

namespace shop_api.IRepository
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();
        public User GetUserDetails(Guid Id);
        public void AddUser(User user);
        public void UpdateUser(User user);
        public User DeleteUser(Guid Id);
        public bool CheckUser(Guid Id);
    }
}
