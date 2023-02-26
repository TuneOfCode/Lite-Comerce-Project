using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace _20T1080009.Web {
    /// <summary>
    /// Lớp cung cấp các hàm chuyển đổi dữ kiểu kiểu
    /// </summary>
    public class Converter {
        /// <summary>
        /// Hàm chuyển đổi từ kiểu chuỗi sang kiểu ngày tháng năm
        /// </summary>
        /// <param name="s"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DateTime? DMYStingToDateTime(string s, string format="d/M/yyyy") { 
            try { 
                return DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
            } catch {
                return null;
            }
        }
    }
}