using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20T1080009.DomainModels {
    /// <summary>
    /// Loại hàng
    /// </summary>
    public class Category {
        /// <summary>
        /// Mã loại hàng
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// Tên loại hàng
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Chi tiết loại hàng
        /// </summary>
        public string Description { get; set; }
    }
}
