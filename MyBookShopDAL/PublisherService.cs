
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyBookShop.Models;

namespace MyBookShop.DAL
{
	public static class PublisherService
	{
        public static Publisher AddPublisher(Publisher publisher)
		{
            string sql =
				"INSERT Publishers (Name)" +
				"VALUES (@Name)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Name", publisher.Name)
				};
				
                int newId = DBHelper.GetScalar(sql, para);
				return GetPublisherById(newId);
            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                return null;
            }
		}
		
        public static void DeletePublisher(Publisher publisher)
		{
			DeletePublisherById( publisher.Id );
		}

        public static void DeletePublisherById(int id)
		{
            string sql = "DELETE Publishers WHERE Id = @Id";

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
		
        public static void DeletePublisherByName(string name)
		{
            string sql = "DELETE Publishers WHERE Name = @Name";

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
		
        public static void ModifyPublisher(Publisher publisher)
        {
            string sql =
                "UPDATE Publishers " +
                "SET " +
	                "Name = @Name " +
                "WHERE Id = @Id";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Id", publisher.Id),
					new SqlParameter("@Name", publisher.Name)
				};

				DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
				throw e;
            }

        }		

        public static IList<Publisher> GetAllPublishers()
        {
            string sqlAll = "SELECT * FROM Publishers";
			return GetPublishersBySql( sqlAll );
        }
		
        public static Publisher GetPublisherById(int id)
        {
            string sql = "SELECT * FROM Publishers WHERE Id = @Id";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    Publisher publisher = new Publisher();

					publisher.Id = (int)reader["Id"];
					publisher.Name = (string)reader["Name"];

                    reader.Close();
					
                    return publisher;
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
		
        public static Publisher GetPublisherByName(string name)
        {
            string sql = "SELECT * FROM Publishers WHERE Name = @Name";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Name", name));
                if (reader.Read())
                {
                    Publisher publisher = new Publisher();

					publisher.Id = (int)reader["Id"];
					publisher.Name = (string)reader["Name"];

                    reader.Close();

                    return publisher;
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
		
		
		
		
        private static IList<Publisher> GetPublishersBySql( string safeSql )
        {
            List<Publisher> list = new List<Publisher>();

			try
			{
				DataTable table = DBHelper.GetDataSet( safeSql );
				
				foreach (DataRow row in table.Rows)
				{
					Publisher publisher = new Publisher();
					
					publisher.Id = (int)row["Id"];
					publisher.Name = (string)row["Name"];
	
					list.Add(publisher);
				}
	
				return list;
			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
		
        private static IList<Publisher> GetPublishersBySql( string sql, params SqlParameter[] values )
        {
            List<Publisher> list = new List<Publisher>();

			try
			{
				DataTable table = DBHelper.GetDataSet( sql, values );
				
				foreach (DataRow row in table.Rows)
				{
					Publisher publisher = new Publisher();
					
					publisher.Id = (int)row["Id"];
					publisher.Name = (string)row["Name"];
	
					list.Add(publisher);
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
