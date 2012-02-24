using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookShop.Models
{
	[Serializable()]
	public class SearchKeyword
	{
		private int id; 
		private string keyword = String.Empty;
		private int searchCount;

		public SearchKeyword() { }

		public int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}


		public string Keyword
		{
			get { return this.keyword; }
			set { this.keyword = value; }
		}		
		
		public int SearchCount
		{
			get { return this.searchCount; }
			set { this.searchCount = value; }
		}		
		
	}
}
