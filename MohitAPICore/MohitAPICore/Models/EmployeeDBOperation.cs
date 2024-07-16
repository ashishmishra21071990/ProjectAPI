
using Microsoft.EntityFrameworkCore;

namespace MohitAPICore.Models
{
    public class EmployeeDBOperation
    {
        private EmployeeDbContext _empContext;
        public EmployeeDBOperation(EmployeeDbContext empContext)
        {
            _empContext = empContext;
        }
        public List<Employee> GetEmployees()
        {
            return _empContext.Employees.ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            return _empContext.Employees.Find(id);
        }
        public void AddEmployee(Employee empObj)
        {
            _empContext.Add(empObj);
            _empContext.SaveChanges();
        }
        public void UpdateEmployee(Employee empObj)
        {
            _empContext.Entry(empObj).State = EntityState.Modified;
            _empContext.SaveChanges();
        }
        public void DeleteEmployee(int id)
        {
            var emp = _empContext.Employees.Find(id);
            if (emp != null)
            {
                _empContext.Remove(emp);
                _empContext.SaveChanges();
            }
        }
    }
}
