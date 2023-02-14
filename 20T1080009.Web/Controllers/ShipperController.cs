using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20T1080009.Web.Controllers {
    public class ShipperController : Controller {
        // GET: Shipper

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            ViewBag.Title = "Quản lý người giao hàng";
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create() {
            ViewBag.Title = "Bổ sung người giao hàng";
            return View("Edit");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit() {
            ViewBag.Title = "Cập nhật người giao hàng";
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete() {
            ViewBag.Title = "Xoá người giao hàng";
            return View();
        }
    }
}