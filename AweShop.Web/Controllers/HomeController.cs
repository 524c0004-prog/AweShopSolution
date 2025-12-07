using System.Web.Mvc;
using AweShop.BLL; // Gọi Business Logic Layer

namespace AweShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private ProductService service = new ProductService();
        public ActionResult ProductsByCategory(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                // Nếu không có tên danh mục, chuyển về trang chủ
                return RedirectToAction("Index");
            }

            // Lọc sản phẩm bằng cách gọi hàm trong Service/Repository
            var products = service.GetProductsByCategory(categoryName);

            ViewBag.Title = categoryName; // Đặt tiêu đề cho trang
            return View("Index", products); // Dùng lại View Index để hiển thị
        }
        public ActionResult Index()
        {
            var model = service.GetAllProducts();
            return View(model);
        }

        // Các hàm About, Contact cứ để nguyên cũng được
    }
}