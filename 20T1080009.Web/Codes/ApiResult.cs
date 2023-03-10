using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080009.Web {
    /// <summary>
    /// 
    /// </summary>
    public class ApiResult {
        /// <summary>
        /// 0: thất bại, 1 thành công
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// Thông báo lỗi nếu có
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Dữ liệu bổ sung trả về
        /// </summary>
        public string DataPlus { get; set; }
        /// <summary>
        /// Trả về khi thành công bao gồm mã, thông báo, dữ liệu trả về
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ApiResult Success(object data = null) {
            return new ApiResult { Code = 1, Message = "", Data = data };
        }
        /// <summary>
        /// Trả về khi thành công bao gồm mã, thông báo, dữ liệu trả về, dữ liệu trả về bổ sung
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataPlus"></param>
        /// <returns></returns>
        public static ApiResult Success(object data = null, string dataPlus = null) {
            return new ApiResult { Code = 1, Message = "", Data = data, DataPlus = dataPlus };
        }
        /// <summary>
        /// Trả về khi thất bại bao gồm mã, thông báo
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ApiResult Fail(string msg) {
            return new ApiResult { Code = 0, Message = msg };

        }
    }
}