using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MohitAPICore.Models;
using MohitAPICore.Contract;

namespace MohitAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return _employee.GetEmployees();
        }

        [HttpGet("{id}")]
        public Employee GetEmployeeById(int id)
        {
            return _employee.GetEmployeebyID(id);
        }

        [HttpPost]
        public void AddEmployee(Employee empObj)
        {
            _employee.AddEmployee(empObj);
        }

        [HttpPut]
        public void UpdateEmployee(Employee empObj)
        {
            _employee.UpdateEmployee(empObj);
        }

        [HttpDelete("{id}")]
        public void DeleteEmployee(int id)
        {
            _employee.DeleteEmployee(id);
        }
    }
}
