using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project2021.ViewModels
{
    public class ProductCreateViewModel
    {
        [Key]

        [DisplayName("Product Code")]
        [Required(ErrorMessage = "Product Code is required")]
        public string ProductCode { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }

        [DisplayName("Product Price")]
        [Required(ErrorMessage = "Product Price is required")]
        public int ProductPrice { get; set; }

        [DisplayName("Product Image")]
        public IFormFile ProductImage { get; set; }
    }
}
