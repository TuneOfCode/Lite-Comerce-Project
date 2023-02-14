using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20T1080009.DomainModels {
    /// <summary>
    /// Nhà cung cấp
    /// </summary>
    public class Supplier {
        /// <summary>
        /// Mã nhà cung cấp
        /// </summary>
        public int SupplierID { get; set; }
        /// <summary>
        /// Tên nhà cung cấp
        /// </summary>
        public string SupplierName { get; set;}
        /// <summary>
        /// Tên liên hệ
        /// </summary>
        public string ContactName { get; set;}
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set;}
        /// <summary>
        /// Thành phố
        /// </summary>
        public string City { get; set;}
        /// <summary>
        /// Mã bưu chính
        /// </summary>
        public string PostalCode { get; set;}
        /// <summary>
        /// Tên nước
        /// </summary>
        public string Country { get; set;}
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string Phone { get; set;}
    }
}
