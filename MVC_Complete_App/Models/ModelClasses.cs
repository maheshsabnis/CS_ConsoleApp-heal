using System.Collections.Generic;
// namespace that contains classes for defining the 
// Rules for DataValidations and Primary Identity Kesy
// use the Validation Attribute classes  from  DataAnnotations namespace
// and define validation Rule on Properties of Model classe
// e.g. Required, StringLength, RegularExpression, Compare, etc.
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MVC_Complete_App.Models
{
    public class Category
    {
        /// <summary>
        /// The CategoryRowId will be Primary Identity Key when the database is generated
        /// </summary>
        [Key]
        public int CategoryRowId { get; set; }
        
        [Required(ErrorMessage ="Category Id is Must")]
        [StringLength(50, ErrorMessage ="Category Id can be 50 characters max")]
        [Remote("CheckIfCategoryIdExist", "Category")]
        public string CategoryId { get; set; }
        
        [Required(ErrorMessage = "Category Name is Must")]
        [StringLength(200, ErrorMessage = "Category Name can be 200 characters max")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Sub Category Name is Must")]
        [StringLength(200, ErrorMessage = "Sub Category Name can be 200 characters max")]
        public string SubCategoryName { get; set; }

        [Required(ErrorMessage ="Base Price is Must")]
       
        public int BasePrice { get; set; }
        // This is One-to-Many Relationship i.e. One Category Have multiple Products
        public virtual ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        /// <summary>
        /// The ProductRowId will be Primary Identity Key when the database is generated
        /// </summary>
        [Key]
        public int ProductRowId { get; set; }
        
        [Required(ErrorMessage = "Product Id is Must")]
        [StringLength(50, ErrorMessage = "Product Id can be 50 characters max")]
        public string ProductId { get; set; }
       
        [Required(ErrorMessage = "Product Name is Must")]
        [StringLength(200, ErrorMessage = "Product NAme can be 200 characters max")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Manufacturer  is Must")]
        [StringLength(300, ErrorMessage = "Manufacturer can be 300 characters max")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Description is Must")]
        [StringLength(500, ErrorMessage = "Description can be 500 characters max")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is Must")]
        // apply the custom dataannotation validator
       // [NumericNonNegative(ErrorMessage = "Price cannot be -ve")]
        public int Price { get; set; }

        // This will be generated as Foreign Key when the Database is generated
        [Required(ErrorMessage = "Category id is Must")]
        //[ForeignKey("CategoryRowId")]
        public int CategoryRowId { get; set; }
        // Referential Integrity
        public virtual Category Category { get; set; }
    }
}