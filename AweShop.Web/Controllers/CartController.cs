using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AweShop.BLL;
using AweShop.Models;

namespace AweShop.Web.Controllers
{
    public class CartController : Controller
    {
        private ProductService service = new ProductService();

        // Model placeholder cho thông tin thanh toán (Nếu cần truyền vào View Payment)
        public class PaymentInfo
        {
            public string CardholderName { get; set; }
            public string CardNumber { get; set; }
            public string ExpiryDate { get; set; }
            public string CVV { get; set; }
        }

        // 1. Lấy giỏ hàng từ Session
        private List<CartItem> GetCart()
        {
            var cart = Session["Cart"] as List<CartItem>;
            if (cart == null)
            {
                cart = new List<CartItem>();
                Session["Cart"] = cart;
            }
            return cart;
        }

        // 2. Thêm sản phẩm vào giỏ
        public ActionResult AddToCart(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Product.Id == id);

            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                var product = service.GetById(id);
                if (product != null)
                {
                    cart.Add(new CartItem { Product = product, Quantity = 1 });
                }
            }
            return RedirectToAction("Index");
        }

        // 3. Xóa sản phẩm khỏi giỏ
        public ActionResult RemoveFromCart(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Product.Id == id);
            if (item != null)
            {
                cart.Remove(item);
            }
            return RedirectToAction("Index");
        }

        // 4. Cập nhật số lượng sản phẩm trong giỏ hàng
        public ActionResult UpdateCart(int id, int newQuantity)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Product.Id == id);

            if (item != null)
            {
                if (newQuantity <= 0)
                {
                    cart.Remove(item);
                }
                else
                {
                    item.Quantity = newQuantity;
                }
            }
            return RedirectToAction("Index");
        }

        // 5. Hiển thị trang Giỏ hàng (Giao diện Cart)
        public ActionResult Index()
        {
            var cart = GetCart();
            ViewBag.TotalAmount = cart.Sum(x => x.TotalPrice);
            return View(cart);
        }

        // 6. Chức năng Mua ngay (Thêm vào giỏ và chuyển đến Checkout)
        public ActionResult BuyNow(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Product.Id == id);

            if (item == null)
            {
                var product = service.GetById(id);
                if (product != null)
                {
                    cart.Add(new CartItem { Product = product, Quantity = 1 });
                }
            }
            // Chuyển hướng NGAY LẬP TỨC đến trang Checkout (Shipping)
            return RedirectToAction("Checkout");
        }

        // 7. Checkout (GET) - Hiển thị trang điền thông tin Giao hàng (Shipping Detail)
        [HttpGet]
        public ActionResult Checkout()
        {
            var cart = GetCart();
            if (cart.Count == 0)
            {
                return RedirectToAction("Index");
            }
            ViewBag.TotalAmount = cart.Sum(x => x.TotalPrice);
            ViewBag.CartCount = cart.Count; // Thêm dòng này để truyền số lượng sản phẩm

            var shippingInfo = Session["ShippingInfo"] as Order;
            return View(shippingInfo ?? new Order()); // Nếu Session["ShippingInfo"] null, trả về Order mới
        }

        // 8. Checkout (POST) - Xử lý Lưu thông tin Giao hàng VÀ CHUYỂN HƯỚNG SANG PAYMENT
        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            var cart = GetCart();
            ViewBag.TotalAmount = cart.Sum(x => x.TotalPrice);
            ViewBag.CartCount = cart.Count; // Đảm bảo có Viewbag khi trả lại View

            if (ModelState.IsValid)
            {
                // LƯU Ý: Ở đây ta chỉ lưu thông tin Shipping vào Session
                Session["ShippingInfo"] = order;

                // CHUYỂN HƯỚNG SANG TRANG PAYMENT
                return RedirectToAction("Payment");
            }

            return View(order); // Nếu lỗi, hiển thị lại View Checkout (cùng với ValidationSummary)
        }

        // =======================================================
        // 9. PAYMENT (GET) - Hiển thị trang điền thông tin Thanh toán
        // =======================================================
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = GetCart();
            if (cart.Count == 0)
            {
                return RedirectToAction("Index");
            }
            // Có thể dùng ViewBag để truyền Tổng tiền
            ViewBag.TotalAmount = cart.Sum(x => x.TotalPrice);

            // Trả về Views/Cart/Payment.cshtml
            return View();
        }

        // 10. PAYMENT (POST) - Xử lý đặt hàng (Place Order)
        // 10. PAYMENT (POST) - Xử lý đặt hàng (Place Order)
        [HttpPost]
        public ActionResult Payment(PaymentInfo model)
        {
            var cart = GetCart();
            // Lấy thông tin khách hàng đã điền ở bước Checkout từ Session
            var shippingInfo = Session["ShippingInfo"] as Order;

            // --- KIỂM TRA ĐIỀU KIỆN ---
            if (cart == null || cart.Count == 0)
            {
                ModelState.AddModelError("", "Lỗi: Giỏ hàng trống.");
                return View(model);
            }

            if (shippingInfo == null)
            {
                ModelState.AddModelError("", "Lỗi: Thiếu thông tin giao hàng.");
                return View(model);
            }

            // --- XỬ LÝ LƯU ĐƠN HÀNG ---
            if (ModelState.IsValid)
            {
                try
                {
                    // 1. Gọi Database ra
                    using (var db = new AweShop.DAL.ApplicationDbContext())
                    {
                        // 2. Cập nhật thêm thông tin ngày giờ và trạng thái cho đơn hàng
                        shippingInfo.OrderDate = System.DateTime.Now;
                        shippingInfo.Status = "Pending"; // Mặc định là Chờ xử lý

                        // (Nếu muốn lưu chi tiết sản phẩm OrderDetail thì làm ở đây, nhưng tạm thời lưu Order trước đã)

                        // 3. Lưu Order vào bảng Orders
                        db.Orders.Add(shippingInfo);

                        // 4. LỆNH QUAN TRỌNG NHẤT: Lưu xuống SQL
                        db.SaveChanges();
                    }

                    // 5. Xóa Session sau khi đặt hàng thành công
                    Session["Cart"] = null;
                    Session["ShippingInfo"] = null;

                    // 6. Chuyển hướng
                    return RedirectToAction("OrderSuccess");
                }
                catch (System.Exception ex)
                {
                    // Nếu lỗi Database thì báo ra
                    ModelState.AddModelError("", "Lỗi lưu đơn hàng: " + ex.Message);
                }
            }

            // Nếu thất bại thì quay lại trang Payment
            ViewBag.TotalAmount = cart.Sum(x => x.TotalPrice);
            return View(model);
        }
        // 11. TRANG CẢM ƠN (Đã thêm vào để sửa lỗi 404)
        public ActionResult OrderSuccess()
        {
            return View();
        }
    }
}