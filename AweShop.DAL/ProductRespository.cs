using System.Collections.Generic;
using System.Data.Entity; // Cần thiết cho các thao tác EF (EntityState.Modified)
using System.Linq; // Cần thiết để sử dụng .ToList(), .FirstOrDefault()
using AweShop.Models; // Cần thiết để sử dụng Product
using AweShop.DAL; // Cần thiết để sử dụng ApplicationDbContext (nếu ApplicationDbContext nằm trong AweShop.DAL)

namespace AweShop.DAL
{
    public class ProductRepository
    {
        // 1. Lấy tất cả sản phẩm
        public List<Product> GetProducts()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.ToList();
            }
        }

        // 2. Lấy sản phẩm theo Category (Dùng bởi ProductService)
        public List<Product> GetProductsByCategory(string categoryName)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.Where(p => p.Category == categoryName).ToList();
            }
        }

        // 3. Lấy sản phẩm theo Id (PHƯƠNG THỨC GetById)
        public Product GetById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.FirstOrDefault(p => p.Id == id);
            }
        }

        // 4. Thêm sản phẩm mới (Dùng bởi ProductService.Create)
        public void AddProduct(Product product)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        // 5. Cập nhật sản phẩm (Dùng bởi ProductService.Update)
        public void UpdateProduct(Product product)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        // 6. Xóa sản phẩm (Dùng bởi ProductService.Delete)
        public void DeleteProduct(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var productToDelete = context.Products.Find(id);
                if (productToDelete != null)
                {
                    context.Products.Remove(productToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}