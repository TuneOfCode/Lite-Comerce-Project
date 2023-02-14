using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20T1080009.Web.Controllers {
    public class CategoryController : Controller {
        // GET: Category

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            ViewBag.Title = "Quản lý loại hàng";
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create() {
            ViewBag.Title = "Bổ sung loại hàng";
            return View("Edit");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit() {
            ViewBag.Title = "Cập nhật loại hàng";
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete() {
            ViewBag.Title = "Xoá loại hàng";
            return View();
        }
    }
}