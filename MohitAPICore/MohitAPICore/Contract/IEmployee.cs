using MohitAPICore.Models;

namespace MohitAPICore.Contract
{
    public interface IEmployee
    {
        List<Employee> GetEmployees();
        Employee GetEmployeebyID(int id);
        void AddEmployee(Employee empObj);
        void UpdateEmployee(Employee empObj);
        void DeleteEmployee(int id);
    }
}
