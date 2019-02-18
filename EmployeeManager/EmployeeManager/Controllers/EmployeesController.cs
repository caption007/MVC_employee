using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManager.Models;
using Microsoft.Extensions.Options;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Http;

namespace EmployeeManager.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeManagerContext _context;
        public SizeSet pageset;
        public static string Way = "ID";

        public EmployeesController(EmployeeManagerContext context,IOptions<SizeSet> PageSize)
        {  
            _context = context;
            pageset = PageSize.Value;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string SreachOptions, string SearchString,  string currentSort, int ?page , string Reverse = "ASC",string SortOrder="ID")
        {
            
            ViewData["reverse"] = Reverse;
            ViewData["CurrentSort"] = SortOrder;

            ViewData["SreachOptions"] = SreachOptions;
            ViewData["SearchString"] = SearchString;
            

            ViewData["IDSortParm"] = "ID" ;
            ViewData["FirstNameSortParm"]=  "FirstName" ;
            ViewData["LastNameSortParm"] = "LastName";
            ViewData["GenderSortParm"] =  "Gender";
            ViewData["BirthdaySortParm"] =  "Birthday";
            ViewData["AddressSortParm"] =  "Address" ;
            ViewData["PhoneNumberSortParm"] =  "PhoneNumber";
            ViewData["DepartmentSortParm"] =  "Department" ;
            ViewData["EmailSortParm"] = "Email";
          
            IQueryable<Employee> Employee = from E in _context.Employee
                         select E;
           

            if (!string.IsNullOrEmpty(SreachOptions) &&!string.IsNullOrEmpty(SearchString))
            {
                switch (SreachOptions)
                {
                    case "EmployeeId":
                        Employee = Employee.Where(s => s.ID.ToString() == SearchString);
                        break;
                    case "EmlpoyeeFirstName":
                        Employee = Employee.Where(x => x.FirstName.Contains(SearchString));
                        break;
                    case "EmployeeLastName":
                        Employee = Employee.Where(x => x.LastName.Contains(SearchString));
                        break;
                }
            }
            if (currentSort == SortOrder) {
                //HttpContext.Session.SetString("way", Way);
                //ViewData["reverse"] = Reverse == "ASC" ? "DESC" : "ASC";
                Reverse = Reverse == "ASC" ? "DESC" : "ASC";
            }
            else
            {
                //ViewData["reverse"] = Reverse = "ASC";
                currentSort =  SortOrder;
            }

            
            Employee = Employee.OrderBy($"{SortOrder} {Reverse}");
            ViewData["Nowreverse"] = Reverse;


            ViewData["reverse"] = Reverse;
            return View(await PaginatedList<Employee>.CreateAsync(Employee.AsNoTracking(), page ?? 1,pageset.PageSize));
            
        }
        

        [AcceptVerbs("Get","Post")]
        public IActionResult VerifyEmail(string email,int ID)
        {
            if (User_VerifyEmail(email,ID))
            {
                return Json($"Email {email} is already in use.");
            }
            return Json(true);
        }

        private bool User_VerifyEmail(string email,int ID)
        {
            return _context.Employee.Any(e => e.Email == email&&e.ID!=ID);
        }
        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Gender,Birthday,Address,PhoneNumber,Department,Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Gender,Birthday,Address,PhoneNumber,Department,Email")] Employee employee)
        {
            if (id != employee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.ID == id);
        }


        
    }
}
