using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductMVC.Models
{
    public class Product
    {
        [Key]
        public int ProductId { set; get; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Enter Product name")]
        public string ProductName { set; get; }
        [Range(8,50,ErrorMessage ="Rate Should be between 8 to 50")]
        public decimal Rate { set; get; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Product Description")]
        public string Description { set; get; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Product  CategoryName")]
        public string CategoryName{set;get;}
    }
}