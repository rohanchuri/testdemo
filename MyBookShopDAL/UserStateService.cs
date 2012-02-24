using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyBookShop.Models;

namespace MyBookShop.DAL
{
	public static class UserStateService
	{
        /// <summary>
        /// È¡µÃÄ¬ÈÏ×´Ì¬
        /// </summary>
        /// <returns></returns>
        public static UserState GetNormalUserState()
        {
            return GetUserStateById(1);
        }

        public static UserState AddUserState(UserState userState)
        {
            string sql =
                "INSERT UserStates (Name)" +
                "VALUES (@Name)";

            sql += " ; SELECT @@IDENTITY";

            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Name", userState.Name)
				};

                int newId = DBHelper.GetScalar(sql, para);
                return GetUserStateById(newId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static void DeleteUserState(UserState userState)
        {
            DeleteUserStateById(userState.Id);
        }

        public static void DeleteUserStateById(int id)
        {
            string sql = "DELETE UserStates WHERE Id = @Id";

            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Id", id)
				};

                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        public static void DeleteUserStateByName(string name)
        {
            string sql = "DELETE UserStates WHERE Name = @Name";

            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Name", name)
				};

                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        public static void ModifyUserState(UserState userState)
        {
            string sql =
                "UPDATE UserStates " +
                "SET " +
                    "Name = @Name " +
                "WHERE Id = @Id";


            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Id", userState.Id),
					new SqlParameter("@Name", userState.Name)
				};

                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }

        public static IList<UserState> GetAllUserStates()
        {
            string sqlAll = "SELECT * FROM UserStates";
            return GetUserStatesBySql(sqlAll);
        }

        public static UserState GetUserStateById(int id)
        {
            string sql = "SELECT * FROM UserStates WHERE Id = @Id";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    UserState userState = new UserState();

                    userState.Id = (int)reader["Id"];
                    userState.Name = (string)reader["Name"];

                    reader.Close();

                    return userState;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static UserState GetUserStateByName(string name)
        {
            string sql = "SELECT * FROM UserStates WHERE Name = @Name";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Name", name));
                if (reader.Read())
                {
                    UserState userState = new UserState();

                    userState.Id = (int)reader["Id"];
                    userState.Name = (string)reader["Name"];

                    reader.Close();

                    return userState;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private static IList<UserState> GetUserStatesBySql(string safeSql)
        {
            List<UserState> list = new List<UserState>();

            try
            {
                DataTable table = DBHelper.GetDataSet(safeSql);

                foreach (DataRow row in table.Rows)
                {
                    UserState userState = new UserState();

                    userState.Id = (int)row["Id"];
                    userState.Name = (string)row["Name"];

                    list.Add(userState);
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        private static IList<UserState> GetUserStatesBySql(string sql, params SqlParameter[] values)
        {
            List<UserState> list = new List<UserState>();

            try
            {
                DataTable table = DBHelper.GetDataSet(sql, values);

                foreach (DataRow row in table.Rows)
                {
                    UserState userState = new UserState();

                    userState.Id = (int)row["Id"];
                    userState.Name = (string)row["Name"];

                    list.Add(userState);
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
		

	}
}
