using System;

namespace AweShop.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        // Tính thành tiền = Giá * Số lượng
        public decimal TotalPrice => Product.Price * Quantity;
    }
}
