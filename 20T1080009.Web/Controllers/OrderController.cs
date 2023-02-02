using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20T1080009.Web.Controllers {
    public class OrderController : Controller {
        // GET: Order

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            return View();
        }

        /// <summary>
        /// Thêm đơn hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult Create() {
            return View();
        }
    }
}