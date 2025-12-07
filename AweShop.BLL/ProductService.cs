using System.Collections.Generic;
using System.Linq; // Cần thiết để sử dụng .Count()
using AweShop.DAL;
using AweShop.Models;

namespace AweShop.BLL
{
    public class ProductService
    {
        // Khởi tạo Repository đã dùng Database
        private ProductRepository repo = new ProductRepository();

        public List<Product> GetAllProducts()
        {
            return repo.GetProducts();
        }

        // 🌟 SỬA LỖI CS1061: Đổi GetProductById thành GetById
        public Product GetById(int id)
        {
            return repo.GetById(id);
        }

        public void Create(Product p)
        {
            repo.AddProduct(p);
        }

        public void Update(Product p)
        {
            repo.UpdateProduct(p);
        }

        public void Delete(int id)
        {
            repo.DeleteProduct(id);
        }

        // 🌟 SỬA LỖI CS1061: Tính số lượng bằng cách lấy tất cả và đếm (.Count())
        public int GetTotalProductCount()
        {
            return repo.GetProducts().Count();
        }

        // Lấy sản phẩm theo Category
        public List<Product> GetProductsByCategory(string categoryName)
        {
            // Logic nghiệp vụ (Business Logic) có thể được đặt tại đây nếu cần
            return repo.GetProductsByCategory(categoryName);
        }
        // Hàm này dùng để demo Unit Test (Kiểm tra giá nhập vào có hợp lệ không)
        public bool IsPriceValid(decimal price)
        {
            // Quy tắc: Giá phải lớn hơn 0 và nhỏ hơn 1 tỷ
            if (price <= 0) return false;
            if (price >= 1000000000) return false;
            return true;
        }
    }
}