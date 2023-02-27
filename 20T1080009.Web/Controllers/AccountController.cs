using _20T1080009.BusinessLayers;
using _20T1080009.DomainModels;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web.Security;

namespace _20T1080009.Web.Controllers {
    [Authorize]
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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
            // chuyển dữ liệu về string để đưa vào trong cookie
            var data = JsonConvert.SerializeObject(userAccount);
            // Ghi cookie cho phiên đăng nhập
            FormsAuthentication.SetAuthCookie(data, false);
            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangePassword() {
            ViewBag.Title = "Thay đổi mật khẩu";
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangePassword(string userName = "", string oldPassword = "", string newPassword = "") {
            ViewBag.OldPassword = oldPassword ?? "";
            if (string.IsNullOrWhiteSpace(userName) 
                || string.IsNullOrWhiteSpace(oldPassword) 
                || string.IsNullOrWhiteSpace(newPassword)) {
                ModelState.AddModelError("", "Thông tin không đầy đủ");
                return View();
            }

            bool isChangePassword = UserAccountService.ChangePasword(AccountTypes.Employee, userName, oldPassword, newPassword);
            if (!isChangePassword) {
                ModelState.AddModelError("", "Thay đổi mật khẩu thất bại");
                return View();
            }
            //ViewBag.messageSuccess = "Thay đổi mật khẩu thành công";
            //return View();
            //return RedirectToAction("Index", "Home");
            return RedirectToAction("Logout");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout() {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}