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

        #region Xử lý liên quan đến nhà cung cấp
       /// <summary>
       /// Tìm kiếm, lấy danh sách nhà cung cấp dưới dạng phân trang
       /// </summary>
       /// <param name="page">Trang cần hiển thị</param>
       /// <param name="pageSize">Số dòng trên mỗi trang (0 nếu không phân trang)</param>
       /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
       /// <param name="rowCount">Tham số đầu ra: số dòng dữ liệu tìm được</param>
       /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(int page, int pageSize, string searchValue, out int rowCount) {
            rowCount = supplierDB.Count(searchValue);
            return supplierDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Tìm kiếm, lấy danh sách nhà cung cấp dưới dạng không phân trang
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(string searchValue = "") {
            return supplierDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin nhà cung cấp dựa vào mã
        /// </summary>
        /// <param name="supplierId">Mã của nhà cung cấp cần lấy thông tin</param>
        /// <returns></returns>
        public static Supplier GetSupplier(int supplierID) {
            return supplierDB.Get(supplierID);
        }
        /// <summary>
        /// Bổ sung nhà cung cấp. Hàm trả về nhà cung cấp được bổ sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddSupplier(Supplier data) {
            return supplierDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(Supplier data) {
            return supplierDB.Update(data);
        }
        /// <summary>
        /// Xoá một nhà cung cấp theo mã
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(int supplierID) {
            return supplierDB.Delete(supplierID);
        }
        /// <summary>
        /// Kiểm tra xem nhà cung cấp có dữ liệu liên quan hay không?
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static bool InUsedSupplier(int supplierID) {
            return supplierDB.InUsed(supplierID);
        }
        #endregion

        #region Xử lý liên quan đến khách hàng
        /// <summary>
        /// Tìm kiếm, lấy danh sách khách hàng dưới dạng phân trang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <param name="rowCount">Tham số đầu ra: số dòng dữ liệu tìm được</param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(int page, int pageSize, string searchValue, out int rowCount) { 
            rowCount = customerDB.Count(searchValue);
            return customerDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Tìm kiếm, lấy danh sách khách hàng dưới dạng không phân trang
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(string searchValue) {
            return customerDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin khách hàng dựa vào mã
        /// </summary>
        /// <param name="customerID">Mã của khách hàng cần lấy thông tin</param>
        /// <returns></returns>
        public static Customer GetCustomer(int customerID) {
            return customerDB.Get(customerID);
        }
        /// <summary>
        /// Bổ sung khách hàng. Hàm trả về khách hàng được bổ sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCustomer(Customer data) {
            return customerDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCustomer(Customer data) {
            return customerDB.Update(data);
        }
        /// <summary>
        /// Xoá một khách hàng theo mã
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool DeleteCustomer(int customerID) {
            return customerDB.Delete(customerID);
        }
        /// <summary>
        /// Kiểm tra xem khách hàng có dữ liệu liên quan hay không?
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool InUsedCustomer(int customerID) {
            return customerDB.InUsed(customerID);
        }
        #endregion

        #region Xử lý liên quan đến người giao hàng
        /// <summary>
        /// Tìm kiếm, lấy danh sách người giao hàng dưới dạng phân trang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <param name="rowCount">Tham số đầu ra: số dòng dữ liệu tìm được</param>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(int page, int pageSize, string searchValue, out int rowCount) {
            rowCount = shipperDB.Count(searchValue);
            return shipperDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Tìm kiếm, lấy danh sách người giao hàng dưới dạng không phân trang
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(string searchValue) {
            return shipperDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin người giao hàng dựa vào mã
        /// </summary>
        /// <param name="shipperID">Mã của người giao hàng cần lấy thông tin</param>
        /// <returns></returns>
        public static Shipper GetShipper(int shipperID) {
            return shipperDB.Get(shipperID);
        }
        /// <summary>
        /// Bổ sung người giao hàng. Hàm trả về người giao hàng được bổ sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddShipper(Shipper data) {
            return shipperDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateShipper(Shipper data) {
            return shipperDB.Update(data);
        }
        /// <summary>
        /// Xoá một người giao hàng theo mã
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static bool DeleteShipper(int shipperID) {
            return shipperDB.Delete(shipperID);
        }
        /// <summary>
        /// Kiểm tra xem người giao hàng có dữ liệu liên quan hay không?
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static bool InUsedShipper(int shipperID) {
            return shipperDB.InUsed(shipperID);
        }
        #endregion

        #region Xử lý liên quan đến nhân viên
        /// <summary>
        /// Tìm kiếm, lấy danh sách nhân viên dưới dạng phân trang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <param name="rowCount">Tham số đầu ra: số dòng dữ liệu tìm được</param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(int page, int pageSize, string searchValue, out int rowCount) {
            rowCount = employeeDB.Count(searchValue);
            return employeeDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Tìm kiếm, lấy danh sách nhân viên dưới dạng không phân trang
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(string searchValue) {
            return employeeDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin nhân viên dựa vào mã
        /// </summary>
        /// <param name="employeeID">Mã của nhân viên cần lấy thông tin</param>
        /// <returns></returns>
        public static Employee GetEmployee(int employeeID) {
            return employeeDB.Get(employeeID);
        }
        /// <summary>
        /// Bổ sung nhân viên. Hàm trả về nhân viên được bổ sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddEmployee(Employee data) {
            return employeeDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateEmployee(Employee data) {
            return employeeDB.Update(data);
        }
        /// <summary>
        /// Xoá một nhân viên theo mã
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static bool DeleteEmployee(int employeeID) {
            return employeeDB.Delete(employeeID);
        }
        /// <summary>
        /// Kiểm tra xem nhân viên có dữ liệu liên quan hay không?
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static bool InUsedEmployee(int employeeID) {
            return employeeDB.InUsed(employeeID);
        }
        #endregion

        #region Xử lý liên quan đến loại hàng
        /// <summary>
        /// Tìm kiếm, lấy danh sách loại hàng dưới dạng phân trang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <param name="rowCount">Tham số đầu ra: số dòng dữ liệu tìm được</param>
        /// <returns></returns>
        public static List<Category> ListOfCategories(int page, int pageSize, string searchValue, out int rowCount) {
            rowCount = categoryDB.Count(searchValue);
            return categoryDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Tìm kiếm, lấy danh sách loại hàng dưới dạng không phân trang
        /// </summary>
        /// <param name="searchValue">Giá trị tìm kiếm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <returns></returns>
        public static List<Category> ListOfCategories(string searchValue) {
            return categoryDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin loại hàng dựa vào mã
        /// </summary>
        /// <param name="categoryID">Mã của loại hàng cần lấy thông tin</param>
        /// <returns></returns>
        public static Category GetCategory(int categoryID) {
            return categoryDB.Get(categoryID);
        }
        /// <summary>
        /// Bổ sung loại hàng. Hàm trả về loại hàng được bổ sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCategory(Category data) {
            return categoryDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin loại hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCategory(Category data) {
            return categoryDB.Update(data);
        }
        /// <summary>
        /// Xoá một loại hàng theo mã
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static bool DeleteCategory(int categoryID) {
            return categoryDB.Delete(categoryID);
        }
        /// <summary>
        /// Kiểm tra xem loại hàng có dữ liệu liên quan hay không?
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static bool InUsedCategory(int categoryID) {
            return categoryDB.InUsed(categoryID);
        }
        #endregion
    }
}
