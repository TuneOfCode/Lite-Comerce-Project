using _20T1080009.BusinessLayers;
using _20T1080009.DomainModels;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace _20T1080009.Web.Controllers {
    [Authorize]
    public class ShipperController : Controller {
        private const int PAGE_SIZE = 5;
        private const string SESSION_CONDITION = "ShipperCondition";
        /// <summary>
        /// Nhận dữ liệu đầu vào
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            ViewBag.Title = "Quản lý người giao hàng";
            Models.PaginationSearchInput condition = new Models.PaginationSearchInput() {
                Page = 1,
                PageSize = PAGE_SIZE,
                SearchValue = ""
            };
            if (Session[SESSION_CONDITION] != null) {
                condition = Session[SESSION_CONDITION] as Models.PaginationSearchInput;
            }
            return View(condition);
        }
        /// <summary>
        /// Trang hiển thị dữ liệu đầu ra
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public ActionResult Search(Models.PaginationSearchInput condition) {
            int rowCount = 0;
            var data = CommonDataService.ListOfShippers(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);
            Models.ShipperSearchOutput result = new Models.ShipperSearchOutput() {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };
            Session[SESSION_CONDITION] = condition;
            return View(result);
        }
        /// <summary>
        /// Tạo người giao hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult Create() {
            ViewBag.Title = "Bổ sung người giao hàng";
            var data = new Shipper() {
                ShipperID = 0
            };
            return View("Edit", data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id=0) {
            ViewBag.Title = "Cập nhật người giao hàng";
            if (id <= 0)
                return RedirectToAction("Index");
            var data = CommonDataService.GetShipper(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }
        /// <summary>
        /// Lưu dữ liệu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Shipper data) {
            if (string.IsNullOrWhiteSpace(data.ShipperName)) {
                ModelState.AddModelError(nameof(data.ShipperName), "Tên người giao hàng không được để trống");
            }
            if (string.IsNullOrWhiteSpace(data.Phone)) {
                ModelState.AddModelError(nameof(data.Phone), "Số điện thoại của người giao hàng không được để trống");
            }
            if (!ModelState.IsValid) {
                ViewBag.Title = data.ShipperID == 0 ? "Bổ sung người giao hàng" : "Cập nhật người giao hàng";
                return View("Edit", data);
            }
            if (data.ShipperID == 0) {
                CommonDataService.AddShipper(data);
            } else {
                CommonDataService.UpdateShipper(data);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Xoá người giao hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id=0) {
            ViewBag.Title = "Xoá người giao hàng";
            if (id <= 0)
                return RedirectToAction("Index");
            if (Request.HttpMethod == "POST") {
                CommonDataService.DeleteShipper(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetShipper(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }
    }
}