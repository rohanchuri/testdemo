
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyBookShop.Models;

namespace MyBookShop.DAL
{
	public static class UserRoleService
	{
        public static UserRole AddUserRole(UserRole userRole)
		{
            string sql =
				"INSERT UserRoles (Name)" +
				"VALUES (@Name)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Name", userRole.Name)
				};
				
                int newId = DBHelper.GetScalar(sql, para);
				return GetUserRoleById(newId);
            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                return null;
            }
		}
		
        public static void DeleteUserRole(UserRole userRole)
		{
			DeleteUserRoleById( userRole.Id );
		}

        public static void DeleteUserRoleById(int id)
		{
            string sql = "DELETE UserRoles WHERE Id = @Id";

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
		
        public static void DeleteUserRoleByName(string name)
		{
            string sql = "DELETE UserRoles WHERE Name = @Name";

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
		
        public static void ModifyUserRole(UserRole userRole)
        {
            string sql =
                "UPDATE UserRoles " +
                "SET " +
	                "Name = @Name " +
                "WHERE Id = @Id";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Id", userRole.Id),
					new SqlParameter("@Name", userRole.Name)
				};

				DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
				throw e;
            }

        }		

        public static IList<UserRole> GetAllUserRoles()
        {
            string sqlAll = "SELECT * FROM UserRoles";
			return GetUserRolesBySql( sqlAll );
        }
		
        public static UserRole GetUserRoleById(int id)
        {
            string sql = "SELECT * FROM UserRoles WHERE Id = @Id";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    UserRole userRole = new UserRole();

					userRole.Id = (int)reader["Id"];
					userRole.Name = (string)reader["Name"];

                    reader.Close();
					
                    return userRole;
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
		
        public static UserRole GetUserRoleByName(string name)
        {
            string sql = "SELECT * FROM UserRoles WHERE Name = @Name";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Name", name));
                if (reader.Read())
                {
                    UserRole userRole = new UserRole();

					userRole.Id = (int)reader["Id"];
					userRole.Name = (string)reader["Name"];

                    reader.Close();

                    return userRole;
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
		
		
		
		
        private static IList<UserRole> GetUserRolesBySql( string safeSql )
        {
            List<UserRole> list = new List<UserRole>();

			try
			{
				DataTable table = DBHelper.GetDataSet( safeSql );
				
				foreach (DataRow row in table.Rows)
				{
					UserRole userRole = new UserRole();
					
					userRole.Id = (int)row["Id"];
					userRole.Name = (string)row["Name"];
	
					list.Add(userRole);
				}
	
				return list;
			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
		
        private static IList<UserRole> GetUserRolesBySql( string sql, params SqlParameter[] values )
        {
            List<UserRole> list = new List<UserRole>();

			try
			{
				DataTable table = DBHelper.GetDataSet( sql, values );
				
				foreach (DataRow row in table.Rows)
				{
					UserRole userRole = new UserRole();
					
					userRole.Id = (int)row["Id"];
					userRole.Name = (string)row["Name"];
	
					list.Add(userRole);
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
