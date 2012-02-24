using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyBookShop.Models;

namespace MyBookShop.DAL
{
    public static class UserService
    {
        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static User AddUser(User user)
        {
            string sql =
                "INSERT Users (LoginId, LoginPwd, Name, Address, Phone, Mail, UserRoleId, UserStateId)" +
                "VALUES (@LoginId, @LoginPwd, @Name, @Address, @Phone, @Mail, @UserRoleId, @UserStateId)";
            sql += " ; SELECT @@IDENTITY";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@UserStateId", user.UserState.Id),    //FK
				new SqlParameter("@UserRoleId", user.UserRole.Id),      //FK
				new SqlParameter("@LoginId", user.LoginId),
				new SqlParameter("@LoginPwd", user.LoginPwd),
				new SqlParameter("@Name", user.Name),
				new SqlParameter("@Address", user.Address),
				new SqlParameter("@Phone", user.Phone),
				new SqlParameter("@Mail", user.Mail)
			};
            int newId = DBHelper.GetScalar(sql, para);
            return GetUserById(newId);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user"></param>
        public static void DeleteUser(User user)
        {
            DeleteUserById(user.Id);
        }
        /// <summary>
        /// 根据id删除用户
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteUserById(int id)
        {
            string sql = @"DELETE Orders where UserId=@Id
            DELETE Users WHERE Id = @Id";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
            DBHelper.ExecuteCommand(sql, para);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        public static void ModifyUser(User user)
        {
            string sql =
                "UPDATE Users " +
                "SET " +
                    "UserStateId = @UserStateId, " + //FK
                    "UserRoleId = @UserRoleId, " + //FK
                    "LoginId = @LoginId, " +
                    "LoginPwd = @LoginPwd, " +
                    "Name = @Name, " +
                    "Address = @Address, " +
                    "Phone = @Phone, " +
                    "Mail = @Mail " +
                "WHERE Id = @Id";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", user.Id),
				new SqlParameter("@UserStateId", user.UserState.Id), //FK
				new SqlParameter("@UserRoleId", user.UserRole.Id), //FK
				new SqlParameter("@LoginId", user.LoginId),
				new SqlParameter("@LoginPwd", user.LoginPwd),
				new SqlParameter("@Name", user.Name),
				new SqlParameter("@Address", user.Address),
				new SqlParameter("@Phone", user.Phone),
				new SqlParameter("@Mail", user.Mail)
			};
            DBHelper.ExecuteCommand(sql, para);
        }
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public static IList<User> GetAllUsers()
        {
            string sqlAll = "SELECT * FROM Users";
            return GetUsersBySql(sqlAll);
        }
        /// <summary>
        /// 根据id查询单个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetUserById(int id)
        {
            string sql = "SELECT * FROM Users WHERE Id = @Id";
            int userStateId;
            int userRoleId;
            using (SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id)))
            {
                if (reader.Read())
                {
                    User user = new User();
                    user.Id = (int)reader["Id"];
                    user.LoginId = (string)reader["LoginId"];
                    user.LoginPwd = (string)reader["LoginPwd"];
                    user.Name = (string)reader["Name"];
                    user.Address = (string)reader["Address"];
                    user.Phone = (string)reader["Phone"];
                    user.Mail = (string)reader["Mail"];
                    userStateId = (int)reader["UserStateId"]; //FK
                    userRoleId = (int)reader["UserRoleId"]; //FK
                    reader.Close();
                    user.UserState = UserStateService.GetUserStateById(userStateId);
                    user.UserRole = UserRoleService.GetUserRoleById(userRoleId);
                    return user;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }
        /// <summary>
        /// 根据登录名查询用户
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static User GetUserByLoginId(string loginId)
        {
            string sql = "SELECT * FROM Users WHERE LoginId = @LoginId";
            int userStateId;
            int userRoleId;
            using (SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@LoginId", loginId)))
            {
                if (reader.Read())
                {
                    User user = new User();

                    user.Id = (int)reader["Id"];
                    user.LoginId = (string)reader["LoginId"];
                    user.LoginPwd = (string)reader["LoginPwd"];
                    user.Name = (string)reader["Name"];
                    user.Address = (string)reader["Address"];
                    user.Phone = (string)reader["Phone"];
                    user.Mail = (string)reader["Mail"];
                    userStateId = (int)reader["UserStateId"];
                    userRoleId = (int)reader["UserRoleId"];
                    reader.Close();
                    user.UserState = UserStateService.GetUserStateById(userStateId);
                    user.UserRole = UserRoleService.GetUserRoleById(userRoleId);

                    return user;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }
        /// <summary>
        /// 依据sql语句查询用户
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        private static IList<User> GetUsersBySql(string safeSql)
        {
            List<User> list = new List<User>();

            using (DataTable table = DBHelper.GetDataSet(safeSql))
            {
                foreach (DataRow row in table.Rows)
                {
                    User user = new User();

                    user.Id = (int)row["Id"];
                    user.LoginId = (string)row["LoginId"];
                    user.LoginPwd = (string)row["LoginPwd"];
                    user.Name = (string)row["Name"];
                    user.Address = (string)row["Address"];
                    user.Phone = (string)row["Phone"];
                    user.Mail = (string)row["Mail"];
                    user.UserState = UserStateService.GetUserStateById((int)row["UserStateId"]); //FK
                    user.UserRole = UserRoleService.GetUserRoleById((int)row["UserRoleId"]); //FK

                    list.Add(user);
                }

                return list;
            }
        }
        /// <summary>
        /// 根据sql及相关参数查询用户
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        private static IList<User> GetUsersBySql(string sql, params SqlParameter[] values)
        {
            List<User> list = new List<User>();

            using (DataTable table = DBHelper.GetDataSet(sql, values))
            {
                foreach (DataRow row in table.Rows)
                {
                    User user = new User();

                    user.Id = (int)row["Id"];
                    user.LoginId = (string)row["LoginId"];
                    user.LoginPwd = (string)row["LoginPwd"];
                    user.Name = (string)row["Name"];
                    user.Address = (string)row["Address"];
                    user.Phone = (string)row["Phone"];
                    user.Mail = (string)row["Mail"];
                    user.UserState = UserStateService.GetUserStateById((int)row["UserStateId"]); //FK
                    user.UserRole = UserRoleService.GetUserRoleById((int)row["UserRoleId"]); //FK

                    list.Add(user);
                }
                return list;
            }
        }

    }
}
