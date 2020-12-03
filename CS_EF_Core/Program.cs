using System;
using System.Linq;

namespace CS_EF_Core
{
	class Program
	{
		static void Main(string[] args)
		{
			var ctx = new EFCoreDbContext();
			 
			try
			{
				// if the database is laready available then delete it
				ctx.Database.EnsureDeleted(); // not recommended in Production
											  // create database (No-Migrations are needed)
				ctx.Database.EnsureCreated();
				// Set address for student
				Address address = new Address()
				{
					 FloatNo="B604",
					 Area = "Bavdhan",
					 City="Nagpur",
					 State="Maharashtra"
				};

				Project project = new Project()
				{
					ProjectName = "Hospital Management System"
				};

				var student = new Student()
				{
					 //StudentId = 101,
					 StudentName ="Ajay",
					 Course = ".NET Core",
					 Address = address, // assign address
					 Project = project
				};
				student.SetEmail("ajay@myajay.com");
				student.SetMobile(7484987);
				ctx.Students.Add(student);
				ctx.SaveChanges();
			 

				foreach (Student std in ctx.Students.ToList())
				{
					Console.WriteLine($"{std.StudentId} {std.StudentName}" +
						$"{std.Course} {std.GetEmail()} {std.GetMobile()}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error Occured {ex.Message}");
			}

			Console.ReadLine();
		}
	}





}
