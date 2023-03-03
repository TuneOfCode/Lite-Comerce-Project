using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using _20T1080009.BusinessLayers;
using _20T1080009.DomainModels;

namespace _20T1080009.Web {
    /// <summary>
    ///  Lớp chức năng lựa chọn
    /// </summary>
    public static class SelectListHelper {
        /// <summary>
        /// Lấy danh sách quốc gia
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Countries() {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() {
                Value = "",
                Text = "--Chọn quốc gia--"
            });
            foreach (var item in CommonDataService.ListOfCountries()) {
                list.Add(new SelectListItem() {
                    Value = item.CountryName,
                    Text = item.CountryName
                });
            }
            return list;
        }
        /// <summary>
        /// Lấy danh sách loại hàng
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Categories() {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() {
                Value = "0",
                Text = "--Chọn loại hàng--"
            });
            foreach (var item in CommonDataService.ListOfCategories("")) {
                list.Add(new SelectListItem() {
                    Value = item.CategoryID.ToString(),
                    Text = item.CategoryName
                });
            }
            return list;
        }
        /// <summary>
        /// Lấy danh sách nhà cung cấp
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Suppliers() {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() {
                Value = "0",
                Text = "--Chọn nhà cung cấp--"
            });
            foreach (var item in CommonDataService.ListOfSuppliers("")) {
                list.Add(new SelectListItem() {
                    Value = item.SupplierID.ToString(),
                    Text = item.SupplierName
                });
            }
            return list;
        }
    }
}