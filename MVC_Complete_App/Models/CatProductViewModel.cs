using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Complete_App.Models
{
	public class CatProductViewModel
	{
		public Category Category { get; set; }
		public List<Product> Products { get; set; }
	}
}