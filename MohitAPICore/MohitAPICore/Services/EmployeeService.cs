using MohitAPICore.Contract;
using MohitAPICore.Models;

namespace MohitAPICore.Services
{
    public class EmployeeService : IEmployee
    {
        private EmployeeDBOperation _empdb;
        public EmployeeService(EmployeeDBOperation empdb)
        {
            _empdb = empdb;
        }
        public List<Employee> GetEmployees()
        {
            return _empdb.GetEmployees();
        }
        public Employee GetEmployeebyID(int id)
        {
            return _empdb.GetEmployeeById(id);
        }
        public void AddEmployee(Employee empObj)
        {
            _empdb.AddEmployee(empObj);
        }
        public void UpdateEmployee(Employee empObj)
        {
            _empdb.UpdateEmployee(empObj);
        }
        public void DeleteEmployee(int id)
        {
            _empdb.DeleteEmployee(id);
        }
    }
}
