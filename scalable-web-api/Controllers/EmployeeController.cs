using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Business;
using Common.Model;

namespace scalable_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeBusiness employeeBusiness)
        {
            _logger = logger;
            _employeeBusiness = employeeBusiness;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeBusiness.GetEmployees();
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _employeeBusiness.GetEmployeesById(id);
        }
    }
}