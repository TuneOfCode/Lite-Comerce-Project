using _20T1080009.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080009.Web.Models {
    /// <summary>
    /// Lưu trữ kết quả tìm kiếm và phân trang của loại hàng
    /// </summary>
    public class CategorySearchOutput: PaginationSearchOutput {
        /// <summary>
        /// Dữ liệu đầu ra
        /// </summary>
        public List<Category> Data { get; set; }
    }
}