using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _20T1080009.DomainModels;
using _20T1080009.BusinessLayers;
using System.Reflection;
using System.Web.Services.Protocols;
using _20T1080009.Web.Models;

namespace _20T1080009.Web.Controllers {
    public class SupplierController : Controller {
        private const int PAGE_SIZE = 8;
        private const string SESSION_CONDITION = "SupplierCondition";
        /// <summary>
        /// Đọc dữ liệu 
        /// </summary>
        /// <returns>Trả về giao diện</returns>
        public ActionResult Index() { // int page = 1, string searchValue = ""
            ViewBag.Title = "Quản lý nhà cung cấp";
            //int rowCount = 0;
            //var data = CommonDataService.ListOfSuppliers(page, PAGE_SIZE, searchValue, out rowCount);

            //ViewBag.Page = page;
            //ViewBag.TotalPages = Math.Ceiling((double)rowCount / PAGE_SIZE);
            //ViewBag.RowCount = rowCount;
            //ViewBag.SearchValue = searchValue;
            //return View(data);
            Models.PaginationSearchInput condition = new Models.PaginationSearchInput() {
                Page = 1,
                PageSize = PAGE_SIZE,
                SearchValue = ""
            };
            if (Session[SESSION_CONDITION] != null) {
                // lỗi runtime nếu chạy mà bị lỗi
                //condition = (Models.PaginationSearchInput) Session[SESSION_CONDITION];
                // NÊN DÙNG khi lỗi không trả về lỗi mà trả về giá trị là null
                condition = Session[SESSION_CONDITION] as Models.PaginationSearchInput;
            }
            return View(condition);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public ActionResult Search(Models.PaginationSearchInput condition) {
            int rowCount = 0;
            var data = CommonDataService.ListOfSuppliers(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);
            Models.SupplierSearchOutput result = new Models.SupplierSearchOutput() {
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
        /// Bổ sung dữ liệu
        /// </summary>
        /// <returns></returns>
        public ActionResult Create() {
            ViewBag.Title = "Bổ sung nhà cung cấp";
            var data = new Supplier() {
                SupplierID = 0
            };
            return View("Edit", data);
        }
        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0) {
            ViewBag.Title = "Cập nhật nhà cung cấp";
            if (id <= 0) 
                return RedirectToAction("Index");
            var data = CommonDataService.GetSupplier(id);
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
        public ActionResult Save(Supplier data) {
            if (string.IsNullOrWhiteSpace(data.SupplierName)){
                ModelState.AddModelError(nameof(data.SupplierName), "Tên không được để trống");
            }
            if (string.IsNullOrWhiteSpace(data.ContactName)) {
                ModelState.AddModelError(nameof(data.ContactName), "Tên giao dịch không được để trống");
            }
            if (string.IsNullOrWhiteSpace(data.Country)) {
                ModelState.AddModelError(nameof(data.Country), "Vui lòng chọn quốc gia");
            }

            data.Address = data.Address ?? "";
            data.Phone = data.Phone ?? "";
            data.City = data.City ?? "";
            data.PostalCode = data.PostalCode ?? "";

            if (!ModelState.IsValid) {
                ViewBag.Title = data.SupplierID == 0 ? "Bổ sung nhà cung cấp" : "Cập nhật nhà cung cấp";
                return View("Edit", data);
            }

            if (data.SupplierID == 0) {
                CommonDataService.AddSupplier(data);
            } else {
                CommonDataService.UpdateSupplier(data);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Xoá dữ liệu
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id = 0) {
            if (id <= 0)
                return RedirectToAction("Index");
            if (Request.HttpMethod == "POST") {
                CommonDataService.DeleteSupplier(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetSupplier(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }
    }
}