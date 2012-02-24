using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyBookShop.Models;

namespace MyBookShop.DAL
{
    public static class OrderService
    {
        public static Order AddOrder(Order order)
        {
            string sql =
                "INSERT Orders (OrderDate, UserId, TotalPrice)" +
                "VALUES (@OrderDate, @UserId, @TotalPrice)";

            sql += " ; SELECT @@IDENTITY";

            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserId", order.User.Id), //FK
					new SqlParameter("@OrderDate", order.OrderDate),
					new SqlParameter("@TotalPrice", order.TotalPrice)
				};

                int newId = DBHelper.GetScalar(sql, para);
                return GetOrderById(newId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static void DeleteOrder(Order order)
        {
            DeleteOrderById(order.Id);
        }

        public static void DeleteOrderById(int id)
        {
            string sql = "DELETE Orders WHERE Id = @Id";

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

        public static void ModifyOrder(Order order)
        {
            string sql =
                "UPDATE Orders " +
                "SET " +
                    "UserId = @UserId, " + //FK
                    "OrderDate = @OrderDate, " +
                    "TotalPrice = @TotalPrice " +
                "WHERE Id = @Id";


            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Id", order.Id),
					new SqlParameter("@UserId", order.User.Id), //FK
					new SqlParameter("@OrderDate", order.OrderDate),
					new SqlParameter("@TotalPrice", order.TotalPrice)
				};

                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }

        public static IList<Order> GetAllOrders()
        {
            string sqlAll = "SELECT * FROM Orders";
            return GetOrdersBySql(sqlAll);
        }

        public static Order GetOrderById(int id)
        {
            string sql = "SELECT * FROM Orders WHERE Id = @Id";

            int userId;

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    Order order = new Order();

                    order.Id = (int)reader["Id"];
                    order.OrderDate = (DateTime)reader["OrderDate"];
                    order.TotalPrice = (decimal)reader["TotalPrice"];
                    userId = (int)reader["UserId"]; //FK

                    reader.Close();

                    order.User = UserService.GetUserById(userId);

                    return order;
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


        private static IList<Order> GetOrdersBySql(string safeSql)
        {
            List<Order> list = new List<Order>();

            try
            {
                DataTable table = DBHelper.GetDataSet(safeSql);

                foreach (DataRow row in table.Rows)
                {
                    Order order = new Order();

                    order.Id = (int)row["Id"];
                    order.OrderDate = (DateTime)row["OrderDate"];
                    order.TotalPrice = (decimal)row["TotalPrice"];
                    order.User = UserService.GetUserById((int)row["UserId"]); //FK

                    list.Add(order);
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        private static IList<Order> GetOrdersBySql(string sql, params SqlParameter[] values)
        {
            List<Order> list = new List<Order>();

            try
            {
                DataTable table = DBHelper.GetDataSet(sql, values);

                foreach (DataRow row in table.Rows)
                {
                    Order order = new Order();

                    order.Id = (int)row["Id"];
                    order.OrderDate = (DateTime)row["OrderDate"];
                    order.TotalPrice = (decimal)row["TotalPrice"];
                    order.User = UserService.GetUserById((int)row["UserId"]); //FK

                    list.Add(order);
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
