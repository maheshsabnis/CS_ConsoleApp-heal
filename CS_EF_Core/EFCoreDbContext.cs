using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS_EF_Core
{
	public class EFCoreDbContext: DbContext
	{
		public DbSet<Student> Students { get; set; }
		 
		/// <summary>
		/// DEfine the Connection String
		/// </summary>
		/// <param name="optionsBuilder"></param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.
				UseSqlServer("Data Source=.;Initial Catalog=EfCoreDemoDb;Integrated Security =SSPI");
		}
		/// <summary>
		/// Define a Fluent Mapping (Flexible-Mapping) of Entity with Table Object
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// map the private properties to the Table columns
			// make sure that the private properties
			// can have get/set with public wrapper methods

			// _Email will map with Email Column
			modelBuilder.Entity<Student>()
					   .Property("Email") // Property from Entity class map with table
					   .HasField("Email"); // The private Field in Entity class
			modelBuilder.Entity<Student>()
				.Property("MobileNo")
				.HasField("MobileNo");

			// set the mapping between Stuent and the Address class
			// Student has one Address
			// This will modify the
			// Student Table by adding
			// new columns for Address
			// as like
			// Address_FlatNo, Address_Are, Address_State, Address_City
			modelBuilder.Entity<Student>()
				.OwnsOne(a => a.Address);
			// generate the Project table
			modelBuilder.Entity<Student>()
				.OwnsOne(a => a.Project)
				.ToTable("Project");

		}
	}
}
