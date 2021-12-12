using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using scaleable_web_api.DTO;

namespace scaleable_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static readonly Employee[] employees = new[]
        {
            new Employee
            {
                Id = 1,
                Name = "Caner",
                Surname = "Öncü",
                Title = "Software Engineer"
            }
        };

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }
    }
}