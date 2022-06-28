using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project2021.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required", AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Fullname is required", AllowEmptyStrings = false)]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Email is required", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required", AllowEmptyStrings = false)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
