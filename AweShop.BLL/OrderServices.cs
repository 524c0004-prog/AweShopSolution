using System.Collections.Generic;
using System.Linq;
using AweShop.Models;
using AweShop.DAL; // Đảm bảo đã using DAL để gọi DbContext

namespace AweShop.BLL
{
    public class OrderService
    {
        // Khởi tạo DbContext (giống như bên ProductRepository/Service)
        private ApplicationDbContext db = new ApplicationDbContext();

        // Hàm lấy tất cả đơn hàng, sắp xếp đơn mới nhất lên đầu
        public List<Order> GetAllOrders()
        {
            return db.Orders.OrderByDescending(o => o.OrderDate).ToList();
        }
        // Hàm cập nhật trạng thái đơn hàng
        public void UpdateStatus(int orderId, string newStatus)
        {
            var order = db.Orders.Find(orderId);
            if (order != null)
            {
                // order.Status = newStatus; // <--- Cần đảm bảo Model Order có cột Status

                // NẾU Model Order của bạn CHƯA CÓ cột Status, bạn phải thêm vào Model trước.
                // Tạm thời mình giả định bạn chưa có, nên mình sẽ hướng dẫn thêm ở bước sau.
                db.SaveChanges();
            }
        }

    }

}