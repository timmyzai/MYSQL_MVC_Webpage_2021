using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace MVC_Project2021.Models
{
    public class Product
    {
        [Key]

        public int Id { get; set; }

        [DisplayName("Product Code")]
        [Required]
        public string ProductCode { get; set; }

        [DisplayName("Product Name")]
        [Required]
        public string ProductName { get; set; }

        [DisplayName("Product Price")]
        [Required]
        public int ProductPrice { get; set; }

        [DisplayName("Product Image")]
        [Required]
        public string ProductImage { get; set; }
    }
}
