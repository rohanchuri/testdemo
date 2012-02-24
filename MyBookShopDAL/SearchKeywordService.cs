
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyBookShop.Models;

namespace MyBookShop.DAL
{
	public static class SearchKeywordService
	{
        public static SearchKeyword AddSearchKeyword(SearchKeyword searchKeyword)
		{
            string sql =
				"INSERT SearchKeywords (Keyword, SearchCount)" +
				"VALUES (@Keyword, @SearchCount)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Keyword", searchKeyword.Keyword),
					new SqlParameter("@SearchCount", searchKeyword.SearchCount)
				};
				
                int newId = DBHelper.GetScalar(sql, para);
				return GetSearchKeywordById(newId);
            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                return null;
            }
		}
		
        public static void DeleteSearchKeyword(SearchKeyword searchKeyword)
		{
			DeleteSearchKeywordById( searchKeyword.Id );
		}

        public static void DeleteSearchKeywordById(int id)
		{
            string sql = "DELETE SearchKeywords WHERE Id = @Id";

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
		
        public static void ModifySearchKeyword(SearchKeyword searchKeyword)
        {
            string sql =
                "UPDATE SearchKeywords " +
                "SET " +
	                "Keyword = @Keyword, " +
	                "SearchCount = @SearchCount " +
                "WHERE Id = @Id";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Id", searchKeyword.Id),
					new SqlParameter("@Keyword", searchKeyword.Keyword),
					new SqlParameter("@SearchCount", searchKeyword.SearchCount)
				};

				DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
				throw e;
            }

        }		

        public static IList<SearchKeyword> GetAllSearchKeywords()
        {
            string sqlAll = "SELECT * FROM SearchKeywords";
			return GetSearchKeywordsBySql( sqlAll );
        }
		
        public static SearchKeyword GetSearchKeywordById(int id)
        {
            string sql = "SELECT * FROM SearchKeywords WHERE Id = @Id";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    SearchKeyword searchKeyword = new SearchKeyword();

					searchKeyword.Id = (int)reader["Id"];
					searchKeyword.Keyword = (string)reader["Keyword"];
					searchKeyword.SearchCount = (int)reader["SearchCount"];

                    reader.Close();
					
                    return searchKeyword;
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
		
        private static IList<SearchKeyword> GetSearchKeywordsBySql( string safeSql )
        {
            List<SearchKeyword> list = new List<SearchKeyword>();

			try
			{
				DataTable table = DBHelper.GetDataSet( safeSql );
				
				foreach (DataRow row in table.Rows)
				{
					SearchKeyword searchKeyword = new SearchKeyword();
					
					searchKeyword.Id = (int)row["Id"];
					searchKeyword.Keyword = (string)row["Keyword"];
					searchKeyword.SearchCount = (int)row["SearchCount"];
	
					list.Add(searchKeyword);
				}
	
				return list;
			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
		
        private static IList<SearchKeyword> GetSearchKeywordsBySql( string sql, params SqlParameter[] values )
        {
            List<SearchKeyword> list = new List<SearchKeyword>();

			try
			{
				DataTable table = DBHelper.GetDataSet( sql, values );
				
				foreach (DataRow row in table.Rows)
				{
					SearchKeyword searchKeyword = new SearchKeyword();
					
					searchKeyword.Id = (int)row["Id"];
					searchKeyword.Keyword = (string)row["Keyword"];
					searchKeyword.SearchCount = (int)row["SearchCount"];
	
					list.Add(searchKeyword);
				}
	
				return list;
			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
			
        }

        /// <summary>
        /// 根据关键字内容获得关键字对象
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static SearchKeyword GetKeyword(string keyword)
        {
            string sql = "SELECT * FROM SearchKeywords WHERE keyword = @keyword";

            using (SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@keyword", keyword)))
            {
                if (reader.Read())
                {
                    SearchKeyword searchKeyword = new SearchKeyword();
                    searchKeyword.Id = (int)reader["Id"];
                    searchKeyword.Keyword = (string)reader["Keyword"];
                    searchKeyword.SearchCount = (int)reader["SearchCount"];
                    reader.Close();
                    return searchKeyword;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }
	}
}
