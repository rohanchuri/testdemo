
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyBookShop.Models;

namespace MyBookShop.DAL
{
	public static class CategoryService
	{
        public static Category AddCategory(Category category)
		{
            string sql =
				"INSERT Categories (Name)" +
				"VALUES (@Name)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Name", category.Name)
				};
				
                int newId = DBHelper.GetScalar(sql, para);
				return GetCategoryById(newId);
            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                return null;
            }
		}
		
        public static void DeleteCategory(Category category)
		{
			DeleteCategoryById( category.Id );
		}

        public static void DeleteCategoryById(int id)
		{
            string sql = "DELETE Categories WHERE Id = @Id";

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
		
        public static void DeleteCategoryByName(string name)
		{
            string sql = "DELETE Categories WHERE Name = @Name";

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
		
        public static void ModifyCategory(Category category)
        {
            string sql =
                "UPDATE Categories " +
                "SET " +
	                "Name = @Name " +
                "WHERE Id = @Id";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Id", category.Id),
					new SqlParameter("@Name", category.Name)
				};

				DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
				throw e;
            }

        }		

        public static IList<Category> GetAllCategories()
        {
            string sqlAll = "SELECT * FROM Categories";
			return GetCategoriesBySql( sqlAll );
        }
		
        public static Category GetCategoryById(int id)
        {
            string sql = "SELECT * FROM Categories WHERE Id = @Id";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    Category category = new Category();

					category.Id = (int)reader["Id"];
					category.Name = (string)reader["Name"];

                    reader.Close();
					
                    return category;
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
                throw e;
            }
        }
		
        public static Category GetCategoryByName(string name)
        {
            string sql = "SELECT * FROM Categories WHERE Name = @Name";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Name", name));
                if (reader.Read())
                {
                    Category category = new Category();

					category.Id = (int)reader["Id"];
					category.Name = (string)reader["Name"];

                    reader.Close();

                    return category;
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

        private static IList<Category> GetCategoriesBySql( string safeSql )
        {
            List<Category> list = new List<Category>();

			try
			{
				DataTable table = DBHelper.GetDataSet( safeSql );
				
				foreach (DataRow row in table.Rows)
				{
					Category category = new Category();
					
					category.Id = (int)row["Id"];
					category.Name = (string)row["Name"];
	
					list.Add(category);
				}
	
				return list;
			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
		
        private static IList<Category> GetCategoriesBySql( string sql, params SqlParameter[] values )
        {
            List<Category> list = new List<Category>();

			try
			{
				DataTable table = DBHelper.GetDataSet( sql, values );
				
				foreach (DataRow row in table.Rows)
				{
					Category category = new Category();
					
					category.Id = (int)row["Id"];
					category.Name = (string)row["Name"];
	
					list.Add(category);
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
