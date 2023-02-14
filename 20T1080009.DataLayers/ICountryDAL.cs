using _20T1080009.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20T1080009.DataLayers {
    /// <summary>
    /// Định nghĩa phép xử lý dữ liệu liên quan đến quốc gia
    /// </summary>
    public interface ICountryDAL {
        /// <summary>
        /// Lấy danh sách quốc gia
        /// </summary>
        /// <returns></returns>
        IList<Country> List();
    }
}
