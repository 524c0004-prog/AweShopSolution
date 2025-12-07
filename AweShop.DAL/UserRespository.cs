using System.Collections.Generic;
using System.Linq;
using AweShop.Models;

namespace AweShop.DAL
{
    public class UserRepository
    {
        // Giả lập Database người dùng
        public static List<User> Users = new List<User>()
        {
            new User { Id = 1, Email = "admin@awe.com", Password = "123", FirstName = "Super", LastName = "Admin", Role = "Admin" },
            new User { Id = 2, Email = "khach@gmail.com", Password = "123", FirstName = "Nguyen", LastName = "Van A", Role = "Customer" }
        };

        public User CheckLogin(string email, string password)
        {
            return Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public void Register(User user)
        {
            user.Id = Users.Count + 1;
            user.Role = "Customer"; // Mặc định đăng ký là khách
            Users.Add(user);
        }
    }
}