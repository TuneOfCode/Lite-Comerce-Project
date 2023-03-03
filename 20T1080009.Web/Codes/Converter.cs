using _20T1080009.DomainModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
        /// <summary>
        /// Hàm chuyển đổi từ kiểu object sang kiểu chuỗi
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static UserAccount CookieToUserAccount(string s) {
            try {
                return JsonConvert.DeserializeObject<UserAccount>(s);
            } catch {
                return null;
            }
        }
        /// <summary>
        /// Hàm chuyển đổi từ kiểu chuỗi sang kiểu số dấu chấm động
        /// </summary>
        /// <param name="s"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static Decimal? StringToDecimal(string s) {
            try {
                return Decimal.Parse(s, CultureInfo.InvariantCulture);
            } catch {
                return null;
            }
        }
        /// <summary>
        /// Hàm chuyển đổi từ kiểu chuỗi sang kiểu số nguyên
        /// </summary>
        /// <param name="s"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static int? StringToInteger(string s) {
            try {
                return int.Parse(s, CultureInfo.InvariantCulture);
            } catch {
                return null;
            }
        }
        /// <summary>
        /// Hàm chuyển đổi từ kiểu chuỗi sang kiểu đúng sai
        /// </summary>
        /// <param name="s"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool? StringToBoolean(string s) {
            try {
                return Convert.ToBoolean(s);
            } catch {
                return null;
            }
        }
    }
}