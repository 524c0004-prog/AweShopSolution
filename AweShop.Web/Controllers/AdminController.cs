// File: AweShop.Web/Controllers/AdminController.cs

using System.Web.Mvc;
using AweShop.BLL;
using AweShop.Models;

namespace AweShop.Web.Controllers
{
    public class AdminController : Controller
    {
        ProductService service = new ProductService();
        OrderService orderService = new OrderService();

        // 1. Dashboard: Hiện danh sách sản phẩm và tổng số lượng
        public ActionResult Dashboard()
        {
            // Kiểm tra xem có phải Admin không? (Bảo mật đơn giản)
            var user = Session["User"] as User;
            if (user == null || user.Role != "Admin")
            {
                return RedirectToAction("Login", "Auth");
            }

            // --- THAY ĐỔI TẠI ĐÂY ---

            // 1. Lấy tổng số lượng sản phẩm (đã thêm vào Service)
            int productCount = service.GetTotalProductCount();

            // 2. Truyền số lượng này sang View bằng ViewBag
            ViewBag.ProductCount = productCount;

            // 3. Vẫn truyền danh sách sản phẩm để hiển thị chi tiết bên dưới
            return View(service.GetAllProducts());
        }

        // 2. Trang Thêm mới (GET)
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Orders()
        {
            // Kiểm tra Admin (Copy lại logic bảo mật)
            var user = Session["User"] as User;
            if (user == null || user.Role != "Admin")
            {
                return RedirectToAction("Login", "Auth");
            }

            // Lấy danh sách đơn hàng từ Service
            var orders = orderService.GetAllOrders();

            // Trả về View kèm dữ liệu
            return View(orders);
        }

        // 3. Xử lý Thêm mới (POST)
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                // Nếu người dùng không nhập link ảnh, gán ảnh mặc định
                if (string.IsNullOrEmpty(p.ImageUrl)) p.ImageUrl = "/Images/default.png"; // Nên dùng link nội bộ thay vì placehold

                service.Create(p);
                return RedirectToAction("Dashboard");
            }
            return View(p);
        }

        // 4. Xóa sản phẩm
        public ActionResult Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction("Dashboard");
        }

        // BỔ SUNG: 5. Trang Sửa sản phẩm (GET)
        public ActionResult Edit(int id)
        {
            var product = service.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // BỔ SUNG: 6. Xử lý Sửa sản phẩm (POST)
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                service.Update(p);
                return RedirectToAction("Dashboard");
            }
            return View(p);
        }
    }
}