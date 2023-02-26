﻿using _20T1080009.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080009.Web.Models {
    /// <summary>
    /// Lưu trữ kết quả tìm kiếm và phân trang của nhân viên
    /// </summary>
    public class EmployeeSearchOutput: PaginationSearchOutput {
        /// <summary>
        /// Dữ liệu đầu ra
        /// </summary>
        public List<Employee> Data { get; set; }
    }
}