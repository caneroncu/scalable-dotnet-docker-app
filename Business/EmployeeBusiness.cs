using System.Collections.Generic;
using System.Linq;
using Common.Model;

namespace Business
{
    // TODO repository to real data & Redis caching
    public interface IEmployeeBusiness
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeesById(int id);
    }

    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEnumerable<Employee> _employees = new[]
        {
            new Employee
            {
                Id = 1,
                Name = "Caner",
                Surname = "Öncü",
                Title = "Software Engineer"
            }
        };

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }

        public Employee GetEmployeesById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
