﻿using _20T1080009.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20T1080009.DataLayers.SQLServer {
    /// <summary>
    /// Cài đặt cho tài khoản nhân viên
    /// </summary>
    public class EmployeeAccountDAL : _BaseDAL, IUserAccountDAL {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public EmployeeAccountDAL(string connectionString) : base(connectionString) {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public UserAccount Authorize(string userName, string password) {
            UserAccount data = null;
            using (var connection = OpenConnection()) {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Employees WHERE Email=@Email AND Password=@Password";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", userName);
                cmd.Parameters.AddWithValue("@Password", password);

                using (var dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)) {
                    if (dbReader.Read()) {
                        data = new UserAccount() {
                            UserID = Convert.ToString(dbReader["EmployeeID"]),
                            UserName = Convert.ToString(dbReader["Email"]),
                            FullName = $"{dbReader["FirstName"]} {dbReader["LastName"]}",
                            Email = Convert.ToString(dbReader["Email"]),
                            Password = "",
                            RoleNames = ""
                        };
                    }
                    dbReader.Close();
                };
                connection.Close();
            };
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ChangePassword(string userName, string oldPassword, string newPassword) {
            throw new NotImplementedException();
        }
    }
}