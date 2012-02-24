using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookShop.Models
{
	[Serializable()]
	public class OrderBook
	{

		private int id; 
		private Book book; 
		private Order order; 
		private int quantity;
		private decimal unitPrice;

		
		public OrderBook() { }

		public int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public Book Book
		{
			get { return this.book; }
			set { this.book = value; }
		}		
		
		public Order Order
		{
			get { return this.order; }
			set { this.order = value; }
		}		
		

		public int Quantity
		{
			get { return this.quantity; }
			set { this.quantity = value; }
		}		

		public decimal UnitPrice
		{
			get { return this.unitPrice; }
			set { this.unitPrice = value; }
		}		
		
	}
}
