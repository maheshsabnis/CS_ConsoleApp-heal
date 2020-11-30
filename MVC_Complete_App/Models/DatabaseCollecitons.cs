using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Complete_App.Models
{
	public class Categories : List<Category>
	{
		public Categories()
		{
			Add(new Category() {CategoryRowId=1,CategoryId="Cat1",CategoryName="ECT",BasePrice=100 });
			Add(new Category() { CategoryRowId = 2, CategoryId = "Cat2", CategoryName = "ECL", BasePrice = 30 });
			Add(new Category() { CategoryRowId = 3, CategoryId = "Cat3", CategoryName = "FOD", BasePrice = 20 });
			Add(new Category() { CategoryRowId = 4, CategoryId = "Cat4", CategoryName = "MIS", BasePrice = 100 });
		}
	}

	public class Products : List<Product>
	{
		public Products()
		{
			Add(new Product() {ProductRowId=11,ProductName="Laptop",
				Manufacturer="HP", Description="Gaming",Price=34000,CategoryRowId=1 });
			Add(new Product()
			{
				ProductRowId = 12,
				ProductName = "Iron",
				Manufacturer = "Bajaj",
				Description = "Home Appl",
				Price = 3400,
				CategoryRowId = 2
			});
			Add(new Product()
			{
				ProductRowId = 13,
				ProductName = "Biscuts",
				Manufacturer = "Parle",
				Description = "Energy",
				Price = 30,
				CategoryRowId = 3
			});
			Add(new Product()
			{
				ProductRowId = 14,
				ProductName = "Oil",
				Manufacturer = "KP",
				Description = "Calories",
				Price = 340,
				CategoryRowId = 4
			});
			Add(new Product()
			{
				ProductRowId = 15,
				ProductName = "Laptop",
				Manufacturer = "HP",
				Description = "Gaming",
				Price = 34000,
				CategoryRowId = 1
			});
			Add(new Product()
			{
				ProductRowId = 16,
				ProductName = "Laptop",
				Manufacturer = "HP",
				Description = "Gaming",
				Price = 34000,
				CategoryRowId = 2
			});
			Add(new Product()
			{
				ProductRowId = 17,
				ProductName = "Laptop",
				Manufacturer = "HP",
				Description = "Gaming",
				Price = 34000,
				CategoryRowId = 3
			});
			Add(new Product()
			{
				ProductRowId = 18,
				ProductName = "fLOWER",
				Manufacturer = "HP",
				Description = "Gaming",
				Price = 50,
				CategoryRowId = 4
			});
		}
	}
}