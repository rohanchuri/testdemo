using System;
using System.Collections.Generic;
using System.Text;
using MyBookShop.DAL;
using MyBookShop.Models;

namespace MyBookShop.BLL
{
    public static partial class OrderBookManager
    {

        /// <summary>
        /// 添加订单中的图书
        /// </summary>
        /// <param name="order"></param>
        public static void AddOrderBook(OrderBook order)
        {
            OrderBookService.AddOrderBook(order);
        }
        /// <summary>
        /// 获得订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<OrderBook> GetDetailOrderById(int id)
        {
            return OrderBookService.GetDetailOrderById(id);
        }
    }
}
