using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ASPNET_Core_App.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryRowId { get; set; }
        [Required(ErrorMessage ="Category Id is required")]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Base Price is required")]
        public int BasePrice { get; set; }
        [Required(ErrorMessage = "Sub Category Name is required")]
        public string SubCategoryName { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
