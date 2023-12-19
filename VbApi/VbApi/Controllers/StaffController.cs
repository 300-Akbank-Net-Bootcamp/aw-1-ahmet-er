using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VbApi.Validations;

namespace VbApi.Controllers
{
    public class Staff
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public decimal? HourlySalary { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        public StaffController()
        {
        }

        [HttpPost]
        public Staff Post([FromBody] Staff value)
        {
            StaffValidator validator = new StaffValidator();
            validator.ValidateAndThrow(value);

            return value;
        }
    }
}
