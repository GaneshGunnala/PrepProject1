using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrepProject.Data;
using PrepProject.Models.DTOs;
using PrepProject.Models.Entities;

namespace PrepProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        public EmployeesController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees() {
            var allEmployees = dBContext.Employees.ToList();
            return Ok(allEmployees);
        }

        [HttpGet] //, Route("{id: guid}")]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeByID(Guid id)
        {
            var employee = dBContext.Employees.Find(id);
            if(employee is null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDTO addEmployeeDTO) {

            var employeeObj = new Employee()
            {
                Name = addEmployeeDTO.Name,
                Email = addEmployeeDTO.Email,
                Phone = addEmployeeDTO.Phone,
                Salary = addEmployeeDTO.Salary
            };
            dBContext.Employees.Add(employeeObj);
            dBContext.SaveChanges();
            return Ok(employeeObj);
        }

        [HttpPut] 
        [Route("{id:guid}")]
        public IActionResult UpdateEmployeeByID(Guid id, UpdateEmployeeDTO employeeDTO)
        {
            var employee = dBContext.Employees.Find(id);
            if (employee is null) return NotFound();

            employee.Name = employeeDTO.Name;
            employee.Email = employeeDTO.Email; 
            employee.Phone = employeeDTO.Phone;
            employee.Salary = employeeDTO.Salary;

            dBContext.SaveChanges();

            return Ok(employee);
        }


    }
}
