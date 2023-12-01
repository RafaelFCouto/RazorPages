using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemoApp.Data;
using RazorPagesDemoApp.Models.Domain;
using RazorPagesDemoApp.Models.ViewModels;

namespace RazorPagesDemoApp.Pages.Employees
{
    public class AddModel : PageModel
    {

        private readonly RazorPagesDemoDbContext _dbContext;
        public AddModel(RazorPagesDemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }





        [BindProperty]
        public AddEmployeeViewModel AddEmployeeRequest { get; set; }

        public void OnGet()
        {
            

        }

        public IActionResult OnPost() 
        {
            // Convert View Model to DomainModel


            var employeeDomainModel = new Employee
            {
                Name = AddEmployeeRequest.Name,
                Email = AddEmployeeRequest.Email,
                Salary = AddEmployeeRequest.Salary,
                DateOfBirth = AddEmployeeRequest.DateOfBirth,
                Department = AddEmployeeRequest.Department
            };

            _dbContext.Employees.Add(employeeDomainModel);
            _dbContext.SaveChanges();

            ViewData["Message"] = "Employee created successsfully!";

            return RedirectToPage("/Employees/Add");

            return Page();
        }
    }
}
