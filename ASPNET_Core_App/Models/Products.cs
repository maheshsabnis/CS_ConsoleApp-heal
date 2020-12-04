using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNET_Core_App.Models
{
    public partial class Products
    {
        public int ProductRowId { get; set; }
        [Required(ErrorMessage = "Product Id is required")]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Manufacturer is required")]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Category Row Id is required")]
        public int CategoryRowId { get; set; }
        public int Price { get; set; }

        public virtual Categories CategoryRow { get; set; }
    }
}
