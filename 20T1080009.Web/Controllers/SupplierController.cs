using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20T1080009.Web.Controllers {
    public class SupplierController : Controller {
        // GET: Supplier

        /// <summary>
        /// Đọc dữ liệu 
        /// </summary>
        /// <returns>Trả về giao diện</returns>
        public ActionResult Index() {
            ViewBag.Title = "Quản lý nhà cung cấp";
            return View();
        }
        /// <summary>
        /// Bổ sung dữ liệu
        /// </summary>
        /// <returns></returns>
        public ActionResult Create() {
            ViewBag.Title = "Bổ sung nhà cung cấp";
            return View("Edit");
        }
        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit() {
            ViewBag.Title = "Cập nhật nhà cung cấp";
            return View();
        }
        /// <summary>
        /// Xoá dữ liệu
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete() {
            return View();
        }
    }
}