using _20T1080009.BusinessLayers;
using _20T1080009.DomainModels;
using System.Web.Mvc;
using System.Web.Security;

namespace _20T1080009.Web.Controllers {
    public class AccountController : Controller {
        public ActionResult Index() {
            return View();
        }
        /// <summary>
        /// Trang đăng nhập vào hệ thống
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous] // cho phép login sẽ vào được
        [HttpGet]
        public ActionResult Login() {
            return View();
        }
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string userName = "", string password = "") {
            ViewBag.UserName = userName ?? "";
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password)) {
                ModelState.AddModelError("", "Thông tin không đầy đủ");
                return View();  
            }

            UserAccount userAccount = UserAccountService.Authorize(AccountTypes.Employee, userName, password);
            if (userAccount == null) {
                ModelState.AddModelError("", "Đăng nhập thất bại");
                return View();
            }

            // Ghi cookie cho phiên đăng nhập
            FormsAuthentication.SetAuthCookie(userAccount.UserName, false);
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Logout() {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}