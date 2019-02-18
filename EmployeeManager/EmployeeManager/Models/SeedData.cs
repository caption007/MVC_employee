using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManager.Models
{
    public class SeedData
    {
        public static void Initalize(IServiceProvider serviceProvider)
        {
            using (var context =new EmployeeManagerContext(serviceProvider.GetRequiredService<DbContextOptions<EmployeeManagerContext>>()))
            {
                if (context.Employee.Any())
                {
                    return;
                }
                context.Employee.AddRange(
                    new Employee
                    {
                        ID = 3,
                        FirstName = "Li",
                        LastName = "junfeng",
                        Gender = "M",
                        Birthday = DateTime.Parse("1996/07/14"),
                        Address = "hangzhoudainzi1110",
                        PhoneNumber = 12345678900,
                        Department="d",
                        Email="lee@perficiemnt.com"
                    },
                    new Employee
                    {
                        ID = 4,
                        FirstName = "li",
                        LastName = "junfeng",
                        Gender = "M",
                        Birthday = DateTime.Parse("1996/07/14"),
                        Address = "hangzhoudainzi1110",
                        PhoneNumber = 12345678900,
                        Department = "d",
                        Email = "lee@perficiemnt.com"
                    },
                    new Employee
                    {
                        ID = 5,
                        FirstName = "Li",
                        LastName = "Junfeng",
                        Gender = "M",
                        Birthday = DateTime.Parse("1996/07/14"),
                        Address = "hangzhoudainzi1110",
                        PhoneNumber = 12345678900,
                        Department = "d",
                        Email = "lee@perficiemnt.com"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
