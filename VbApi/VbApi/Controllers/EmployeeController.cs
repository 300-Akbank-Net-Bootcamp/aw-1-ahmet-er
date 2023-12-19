using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VbApi.Validations;

namespace VbApi.Controllers
{
    public class Employee
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double HourlySalary { get; set; }
    }



    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController()
        {
        }

        [HttpPost]
        public Employee Post([FromBody] Employee value)
        {
            EmployeeValidator validator = new EmployeeValidator();
            validator.ValidateAndThrow(value);

            return value;
        }
    }
}
