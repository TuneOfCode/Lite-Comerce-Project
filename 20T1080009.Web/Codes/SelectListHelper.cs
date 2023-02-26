using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}