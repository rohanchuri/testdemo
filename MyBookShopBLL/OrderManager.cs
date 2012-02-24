using System;
using System.Collections.Generic;
using System.Text;
using MyBookShop.DAL;
using MyBookShop.Models;

namespace MyBookShop.BLL
{

    public static class OrderManager
    {
        public static Order AddOrder(Order order)
        {
            return OrderService.AddOrder(order);
        }

        public static void DeleteOrder(Order order)
        {
            OrderService.DeleteOrder(order);
        }

        public static void DeleteOrderById(int id)
        {
            OrderService.DeleteOrderById(id);
        }

		public static void ModifyOrder(Order order)
        {
            OrderService.ModifyOrder(order);
        }
        
        public static IList<Order> GetAllOrders()
        {
            return OrderService.GetAllOrders();
        }

        public static Order GetOrderById(int id)
        {
            return OrderService.GetOrderById(id);
        }

    }
}
