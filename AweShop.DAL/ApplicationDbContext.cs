using AweShop.Models;
using System.Data.Entity;

namespace AweShop.DAL
{
    public class ApplicationDbContext : DbContext
    {
        // 👇 TUYỆT CHIÊU: Gắn cứng chuỗi kết nối vào đây (Lưu ý dấu \\ là đúng nhé)
        public ApplicationDbContext()
            : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AweShop.DAL.ApplicationDbContext;Integrated Security=True")
        {
        }
        // 👆 Hết phần sửa

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}