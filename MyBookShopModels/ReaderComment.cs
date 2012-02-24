
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookShop.Models
{
	[Serializable()]
	public class ReaderComment
	{

		private string readerName; 
		private Book book; 
		private int id;
		private string title = String.Empty;
		private string comment = String.Empty;
		private DateTime date;

		public ReaderComment() { }
		

		public string ReaderName
		{
			get { return this.readerName; }
			set { this.readerName = value; }
		}

		public Book Book
		{
			get { return this.book; }
			set { this.book = value; }
		}		
		

		public int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}		
		

		public string Title
		{
			get { return this.title; }
			set { this.title = value; }
		}		
		

		public string Comment
		{
			get { return this.comment; }
			set { this.comment = value; }
		}		
		

		public DateTime Date
		{
			get { return this.date; }
			set { this.date = value; }
		}		
		
	}
}
