using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20T1080009.DomainModels;
using _20T1080009.DataLayers;
using System.Configuration;
using _20T1080009.DataLayers.SQLServer;

namespace _20T1080009.BusinessLayers {
    /// <summary>
    /// Cung cấp các chức năng nghiệp vụ xử lý dữ liệu chung liên quan đến:
    /// Quốc gia, Nhà cung cấp, Khách hàng, Người giao hàng, Nhân viên, Loại hàng.
    /// - class static: 
    /// + dùng các thành phần bên trong mà không phải khởi tạo
    /// + có contructor nhưng khác: tự động gọi lần đầu tiên và phải khai báo từ khoá static 
    /// + contructor: không có access modify và không có tham số
    /// </summary>
    public static class CommonDataService {

        private static readonly ICountryDAL countryDB;
        private static readonly ICommonDAL<Supplier> supplierDB;
        private static readonly ICommonDAL<Category> categoryDB;
        private static readonly ICommonDAL<Customer> customerDB;
        private static readonly ICommonDAL<Employee> employeeDB;
        private static readonly ICommonDAL<Shipper> shipperDB;

        /// <summary>
        /// ctor
        /// </summary>
        static CommonDataService() {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            countryDB = new DataLayers.SQLServer.CountryDAL(connectionString);
            supplierDB = new DataLayers.SQLServer.SupplierDAL(connectionString);
            categoryDB = new DataLayers.SQLServer.CategoryDAL(connectionString);
            customerDB = new DataLayers.SQLServer.CustomerDAL(connectionString);
            employeeDB = new DataLayers.SQLServer.EmployeeDAL(connectionString);
            shipperDB = new DataLayers.SQLServer.ShipperDAL(connectionString);
        }

        #region Xử lý liên quan đến quốc gia
        /// <summary>
        /// Lấy danh sách quốc gia
        /// </summary>
        /// <returns></returns>
        public static List<Country> ListOfCountries() {
            return countryDB.List().ToList();
        }
        #endregion
    }
}
