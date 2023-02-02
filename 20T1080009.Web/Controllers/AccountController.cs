using System.Web.Mvc;

namespace _20T1080009.Web.Controllers {
    public class AccountController : Controller {
        // GET: Account
        public ActionResult Index() {
            return View();
        }
        /// <summary>
        /// Trang đăng nhập vào hệ thống
        /// </summary>
        /// <returns></returns>
        public ActionResult Login() {
            return View();
        }
    }
}