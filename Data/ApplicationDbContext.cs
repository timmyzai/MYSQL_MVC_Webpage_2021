using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Project2021.Models;

namespace MVC_Project2021.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                    
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
    }
}
