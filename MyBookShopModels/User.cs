
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookShop.Models
{

	[Serializable()]
	public class User
	{

		private int id; 
		private UserState userState; 
		private UserRole userRole; 
		private string loginId = String.Empty;
		private string loginPwd = String.Empty;
		private string name = String.Empty;
		private string address = String.Empty;
		private string phone = String.Empty;
		private string mail = String.Empty;

		public User() { }
		

		public int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public UserState UserState
		{
			get { return this.userState; }
			set { this.userState = value; }
		}		

		public UserRole UserRole
		{
			get { return this.userRole; }
			set { this.userRole = value; }
		}		

		public string LoginId
		{
			get { return this.loginId; }
			set { this.loginId = value; }
		}		

		public string LoginPwd
		{
			get { return this.loginPwd; }
			set { this.loginPwd = value; }
		}		

		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}		
		
		public string Address
		{
			get { return this.address; }
			set { this.address = value; }
		}		

		public string Phone
		{
			get { return this.phone; }
			set { this.phone = value; }
		}		

		public string Mail
		{
			get { return this.mail; }
			set { this.mail = value; }
		}		
		
	}
}
