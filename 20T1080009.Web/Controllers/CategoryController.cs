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
    public class CategoryController : Controller {
        private const int PAGE_SIZE = 5;
        private const string SESSION_CONDITION = "CategoryCondition";
        private const string ERROR_MESSAGE = "ErrorMessage";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            ViewBag.Title = "Quản lý loại hàng";
            //int rowCount = 0;
            //var data = CommonDataService.ListOfCategories(page, PAGE_SIZE, searchValue, out rowCount);

            //ViewBag.Page = page;
            //ViewBag.TotalPages = Math.Ceiling((double)rowCount / PAGE_SIZE);
            //ViewBag.RowCount = rowCount;
            //ViewBag.SearchValue = searchValue;
            Models.PaginationSearchInput condition = new Models.PaginationSearchInput() {
                Page = 1,
                PageSize= PAGE_SIZE,
                SearchValue = ""
            };
            // trường hợp có session
            if (Session[SESSION_CONDITION] != null) {
                condition = Session[SESSION_CONDITION] as Models.PaginationSearchInput;
            }
            ViewBag.ErrorMessage = TempData[ERROR_MESSAGE] ?? "";
            return View(condition);
        }

        public ActionResult Search(Models.PaginationSearchInput condition) {
            int rowCount = 0;
            var data = CommonDataService.ListOfCategories(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);
            Models.CategorySearchOutput
                result = new Models.CategorySearchOutput() {
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
        ///  Tạo loại hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult Create() {
            ViewBag.Title = "Bổ sung loại hàng";
            var data = new Category() {
                CategoryID = 0
            };
            return View("Edit", data);
        }
        /// <summary>
        /// Cập nhật loại hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0) {
            ViewBag.Title = "Cập nhật loại hàng";
            if (id <= 0)
                return RedirectToAction("Index");
            var data = CommonDataService.GetCategory(id);
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
        public ActionResult Save(Category data) {
            if (string.IsNullOrWhiteSpace(data.CategoryName)) {
                //ModelState.AddModelError(nameof(data.CategoryName), "Tên loại hàng không được để trống");
                TempData[ERROR_MESSAGE] = "Tên loại hàng không được để trống";
                return RedirectToAction("Index");
            }
            data.Description = data.Description ?? "";
            if (!ModelState.IsValid) {
                ViewBag.Title = data.CategoryID == 0 ? "Bổ sung loại hàng" : "Cập nhật loại hàng";
                return View("Edit", data);
            }
            if (data.CategoryID == 0) {
                CommonDataService.AddCategory(data);
            } else {
                CommonDataService.UpdateCategory(data);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        ///  Xoá loại hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id = 0) {
            ViewBag.Title = "Xoá loại hàng";
            if (id <= 0)
                return RedirectToAction("Index");
            if (Request.HttpMethod == "POST") {
                CommonDataService.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetCategory(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }
    }
}