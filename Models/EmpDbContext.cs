using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpCrud.Models
{
    public class EmpDbContext:IdentityDbContext<ApplicationUser>
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
