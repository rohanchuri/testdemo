using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookShop.Models
{
	[Serializable()]
	public class Order
	{
		private int id; 
		private User user; 
		private DateTime orderDate;
		private decimal totalPrice;

		public Order() { }
		

		public int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public User User
		{
			get { return this.user; }
			set { this.user = value; }
		}		
		

		public DateTime OrderDate
		{
			get { return this.orderDate; }
			set { this.orderDate = value; }
		}		
		

		public decimal TotalPrice
		{
			get { return this.totalPrice; }
			set { this.totalPrice = value; }
		}		
		
	}
}
