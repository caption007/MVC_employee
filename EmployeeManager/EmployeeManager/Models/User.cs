using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]*$",ErrorMessage ="only number")]
        public int UserId { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "only number")]
        public int userpassword { get; set; }
    }

}
