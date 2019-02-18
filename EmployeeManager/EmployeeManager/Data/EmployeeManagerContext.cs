using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManager.Models;

namespace EmployeeManager.Models
{
    public class EmployeeManagerContext : DbContext
    {
        public EmployeeManagerContext (DbContextOptions<EmployeeManagerContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeManager.Models.Employee> Employee { get; set; }

        public DbSet<EmployeeManager.Models.User> User { get; set; }
    }
}
