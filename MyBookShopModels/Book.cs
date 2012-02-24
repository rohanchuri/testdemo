using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookShop.Models
{
	[Serializable()]
	public class Book
	{
		private int id; 
		private Publisher publisher; 
		private Category category; 
		private string title = String.Empty;
		private string author = String.Empty;
		private DateTime publishDate;
		private string iSBN = String.Empty;
		private int wordsCount;
		private decimal unitPrice;
		private string contentDescription = String.Empty;
		private string aurhorDescription = String.Empty;
		private string editorComment = String.Empty;
		private string tOC = String.Empty;
		private int clicks;
        private int votes = 0;
        private int totalRating = 0;

		public Book() { }
		
		public int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public Publisher Publisher
		{
			get { return this.publisher; }
			set { this.publisher = value; }
		}		

		public Category Category
		{
			get { return this.category; }
			set { this.category = value; }
		}		

		public string Title
		{
			get { return this.title; }
			set { this.title = value; }
		}		

		public string Author
		{
			get { return this.author; }
			set { this.author = value; }
		}		

		public DateTime PublishDate
		{
			get { return this.publishDate; }
			set { this.publishDate = value; }
		}		

		public string ISBN
		{
			get { return this.iSBN; }
			set { this.iSBN = value; }
		}		

		public int WordsCount
		{
			get { return this.wordsCount; }
			set { this.wordsCount = value; }
		}		

		public decimal UnitPrice
		{
			get { return this.unitPrice; }
			set { this.unitPrice = value; }
		}		

		public string ContentDescription
		{
			get { return this.contentDescription; }
			set { this.contentDescription = value; }
		}		

		public string AurhorDescription
		{
			get { return this.aurhorDescription; }
			set { this.aurhorDescription = value; }
		}		

		public string EditorComment
		{
			get { return this.editorComment; }
			set { this.editorComment = value; }
		}		

		public string TOC
		{
			get { return this.tOC; }
			set { this.tOC = value; }
		}		

		public int Clicks
		{
			get { return this.clicks; }
			set { this.clicks = value; }
		}

        public int Votes
        {
            get { return votes; }
            set { votes = value; }
        }

        public int TotalRating
        {
            get { return totalRating; }
            set { totalRating = value; }
        }

        public double AverageRating
        {
            get
            {
                if (this.Votes >= 1)
                    return ((double)this.TotalRating / (double)this.Votes);
                else
                    return 0.0;
            }
        }
	}
}
