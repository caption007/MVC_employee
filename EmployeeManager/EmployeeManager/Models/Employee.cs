using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Employee
    {
        public int ID { get; set; }
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$",ErrorMessage = "input [A-Z]+[a-zA-Z]")]
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "input [A-Z]+[a-zA-Z]")]
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        
        [Required] 
        public string Gender { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        [RegularExpression(@"^1[358]\d{9}$",ErrorMessage ="input 1（3/5/8）XXXXXXXXX")]
        public long PhoneNumber { get; set; }
        public string Department { get; set; }

        [EmailAddress]
        [Remote(action:"VerifyEmail",controller:"Employees",AdditionalFields ="ID")]
        public string Email { get; set; }
    }
}
