using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project2021.ViewModels
{
    public class ProductEditViewModel:ProductCreateViewModel
    {
        public int Id { get; set; }

        public string ExistingImagePath { get; set; }
    }
}
