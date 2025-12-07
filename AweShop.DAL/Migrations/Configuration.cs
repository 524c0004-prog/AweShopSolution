namespace AweShop.DAL.Migrations
{
    using AweShop.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AweShop.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AweShop.DAL.ApplicationDbContext context)
        {
            // Kiểm tra: Chỉ thêm dữ liệu nếu bảng Product đang trống hoặc để cập nhật lại
            // AddOrUpdate sẽ dựa vào 'Id' để biết là thêm mới hay sửa cái cũ.

            context.Products.AddOrUpdate(p => p.Id, // Dùng Id làm khóa để kiểm tra trùng
                new Product
                {
                    Id = 1,
                    Name = "Apple iPhone 17 - 256gb",
                    Category = "Smartphone",
                    Price = 1199,
                    ImageUrl = "/Images/iphone17.png"
                },
                new Product
                {
                    Id = 2,
                    Name = "Vivo X300 pro",
                    Category = "Smartphone",
                    Price = 1340,
                    ImageUrl = "/Images/vivox300pro.png"
                },
                new Product
                {
                    Id = 3,
                    Name = "HUAWEI FreeClip 2",
                    Category = "Audio",
                    Price = 250,
                    ImageUrl = "/Images/huawei.png"
                },
                new Product
                {
                    Id = 4,
                    Name = "Samsung QLED TV 75\"",
                    Category = "TV & Home",
                    Price = 2150,
                    ImageUrl = "/Images/SamsungTv75.png"
                },
                new Product
                {
                    Id = 5,
                    Name = "Macbook Air M4",
                    Category = "Laptop",
                    Price = 1340,
                    ImageUrl = "/Images/macbookair.png"
                },
                new Product
                {
                    Id = 6,
                    Name = "Apple Airpods Max",
                    Category = "Accessories",
                    Price = 550,
                    ImageUrl = "/Images/airpodsMax.png"
                },
                new Product
                {
                    Id = 7,
                    Name = "Apple Watch Series 11",
                    Category = "Wearables",
                    Price = 560,
                    ImageUrl = "/Images/watch11.png"
                },
                new Product
                {
                    Id = 8,
                    Name = "Harman Karrdon Aura Studio 5 ",
                    Category = "Audio",
                    Price = 460, 
                    ImageUrl = "/Images/HarmanKardon.png"
                },
                new Product
                {
                    Id = 9,
                    Name = "Ipad Pro M4",
                    Category = "Laptop",
                    Price = 1140,
                    ImageUrl = "/Images/ipadpro.png"
                },
                new Product
                {
                    Id = 10,
                    Name = "JBL go 2",
                    Category = "Audio",
                    Price = 59,
                    ImageUrl = "/Images/jbl.png"
                },
                new Product
                {
                    Id = 11,
                    Name = "Samsung UHD TV 43\"",
                    Category = "TV & Home",
                    Price = 564,
                    ImageUrl = "/Images/SamsungTv43.png"
                }
                
            );

            // Lưu thay đổi xuống Database
            context.SaveChanges();
        }
    }
}