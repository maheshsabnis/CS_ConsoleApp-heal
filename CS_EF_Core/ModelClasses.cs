using System;
using System.Collections.Generic;
using System.Text;

namespace CS_EF_Core
{
	public class Student
	{
		public int StudentId { get; set; }
		public string StudentName { get; set; }
		public string Course { get; set; }
		private string Email;

		public void SetEmail(string email)
		{
			Email = email;
		}
		public string GetEmail()
		{
			return Email;
		}
		private int MobileNo;
		public void SetMobile(int mobile)
		{
			MobileNo = mobile;
		}
		public int GetMobile()
		{
			return MobileNo;
		}
		// Student Has address
		public Address Address { get; set; }
		// Student creates project
		public Project Project { get; set; }
	}

	public class Address
	{
		public string FloatNo { get; set; }
		public string Area { get; set; }
		public string City { get; set; }
		public string State { get; set; }
	}

	public class Project
	{
		public int ProjectId { get; set; }
		public string ProjectName { get; set; }
	}

}
