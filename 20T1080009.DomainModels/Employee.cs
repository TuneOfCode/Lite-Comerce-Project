using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20T1080009.DomainModels {
    /// <summary>
    /// Nhân viên
    /// </summary>
    public class Employee {
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Họ và tên đệm
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Ngày tháng năm sinh
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Ảnh nhân viên
        /// </summary>
        public string Photo { get; set; }  
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Địa chỉ email
        /// </summary>
        public string Email { get; set; }
    }
}
