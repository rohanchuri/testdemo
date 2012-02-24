using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyBookShop.Models;

namespace MyBookShop.DAL
{
    public static partial class OrderBookService
    {
        /// <summary>
        /// 添加订单中的图书
        /// </summary>
        /// <param name="order"></param>
        public static void AddOrderBook(OrderBook order)
        {
            string sql =
                "INSERT OrderBook (OrderID, BookID, Quantity,UnitPrice)" +
                " VALUES (@OrderID, @BookID, @Quantity,@UnitPrice)";

            SqlParameter[] para = new SqlParameter[]
            {
				new SqlParameter("@OrderID", order.Order.Id), 
				new SqlParameter("@BookID", order.Book.Id), 
                new SqlParameter("@Quantity", order.Quantity),   
                new SqlParameter("@UnitPrice", order.UnitPrice)    
			};

            DBHelper.ExecuteCommand(sql, para);
        }

        /// <summary>
        /// 通过id获取订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<OrderBook> GetDetailOrderById(int id)
        {
            List<OrderBook> list = new List<OrderBook>();
            string sql = "SELECT * FROM OrderBook WHERE OrderID = @OrderID";

            DataTable table = DBHelper.GetDataSet(sql, new SqlParameter("@OrderID", id));
            foreach (DataRow dr in table.Rows)
            {
                OrderBook book = new OrderBook();

                book.Id = (int)dr["Id"];
                book.Order =OrderService.GetOrderById((int)dr["OrderID"]) ;
                book.Quantity = (int)dr["Quantity"];
                book.UnitPrice = (decimal)dr["UnitPrice"];
                book.Book = BookService.GetBookById((int)dr["BookID"]);
                list.Add(book);
            }
            return list;

        }

    }
}
