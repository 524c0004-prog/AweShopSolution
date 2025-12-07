using System.Web.Mvc;
using AweShop.DAL;
using AweShop.Models;

namespace AweShop.Web.Controllers
{
    public class AuthController : Controller
    {
        UserRepository repo = new UserRepository();

        // 1. Hiển thị form Đăng nhập
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // 2. Xử lý Đăng nhập
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = repo.CheckLogin(email, password);
            if (user != null)
            {
                // Lưu thông tin người dùng vào Session
                Session["User"] = user;
                Session["UserName"] = user.FirstName + " " + user.LastName;

                // Kiểm tra quyền
                if (user.Role == "Admin")
                {
                    // Nếu là Admin -> Sẽ chuyển sang trang Admin (Làm ở bước sau)
                    // Tạm thời cho về Home nhưng hiện thông báo
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Error = "Email hoặc mật khẩu không đúng!";
                return View();
            }
        }

        // 3. Hiển thị form Đăng ký
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // 4. Xử lý Đăng ký
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                repo.Register(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // 5. Đăng xuất
        public ActionResult Logout()
        {
            Session.Clear(); // Xóa hết session
            return RedirectToAction("Index", "Home");
        }
    }
}