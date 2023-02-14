using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20T1080009.Web.Controllers {
    public class EmployeeController : Controller {
        // GET: Employee

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            ViewBag.Title = "Quản lý nhân viên";
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create() {
            ViewBag.Title = "Bổ sung nhân viên";
            return View("Edit");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit() {
            ViewBag.Title = "Cập nhật nhân viên";
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete() {
            ViewBag.Title = "Xoá nhân viên";
            return View();
        }
    }
}