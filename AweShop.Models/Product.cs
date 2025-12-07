using System;

namespace AweShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }      // Tên SP: Iphone 17...
        public string Category { get; set; }  // Danh mục: Smartphone...
        public decimal Price { get; set; }    // Giá
        public string ImageUrl { get; set; }  // Link ảnh
    }
}