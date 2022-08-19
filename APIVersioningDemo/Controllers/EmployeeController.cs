using APIVersioningDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVersioningDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetEmployeeV1([FromRoute] int id)
        {
            var emp = new EmployeeV1 { 
                Id = id,
                Name = "Employee Name - " + id,
                Email = "employee" + id + "@email.com"
            };

            return Ok(emp);
        }

        [HttpGet("{id}")]
        [MapToApiVersion("2")]
        public IActionResult GetEmployeeV2([FromRoute] int id)
        {
            var emp = new EmployeeV2
            {
                Id = id,
                EmployeeName = "Employee Name - " + id,
                EmployeeEmail = "employee" + id + "@email.com"
            };

            return Ok(emp);
        }
    }
}

