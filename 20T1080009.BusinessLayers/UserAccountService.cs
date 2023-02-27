using _20T1080009.DataLayers;
using _20T1080009.DomainModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20T1080009.BusinessLayers {
    /// <summary>
    /// Các chức năng nghiệp vụ liên quan đến tài khoản
    /// </summary>
    public static class UserAccountService {
        /// <summary>
        /// 
        /// </summary>
        private static IUserAccountDAL employeeAccountDB;
        /// <summary>
        /// 
        /// </summary>
        private static IUserAccountDAL customerAccountDB;
        /// <summary>
        /// 
        /// </summary>
        static UserAccountService() {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            employeeAccountDB = new DataLayers.SQLServer.EmployeeAccountDAL(connectionString);
            customerAccountDB = new DataLayers.SQLServer.CustomerAccountDAL(connectionString);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        public static UserAccount Authorize(AccountTypes accountType, string userName, string password) {
            if (accountType == AccountTypes.Employee)
                return employeeAccountDB.Authorize(userName, password);
            else
                return customerAccountDB.Authorize(userName, password);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountType"></param>
        /// <param name="userName"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static bool ChangePasword(AccountTypes accountType, string userName, string oldPassword, string newPassword) {
            if (accountType == AccountTypes.Employee)
                return employeeAccountDB.ChangePassword(userName, oldPassword, newPassword);
            else
                return customerAccountDB.ChangePassword(userName, oldPassword, newPassword);
        }
    }
}
