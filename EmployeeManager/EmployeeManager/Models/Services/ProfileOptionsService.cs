using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models.Services
{
    public class ProfileOptionsService
    {
        public List<string> ListGenders()
        {
            // keeping this simple
            return new List<string>() { "Female", "Male" };
        }
        public List<string> ListDepartment()
        {
            // keeping this simple
            return new List<string>() { "Develop", "Test", "Manag" };
        }
        public List<string> SreachOptions(){
            return new List<string>() { "EmployeeId", "EmlpoyeeFirstName", "EmployeeLastName" };
        }
    }
}
