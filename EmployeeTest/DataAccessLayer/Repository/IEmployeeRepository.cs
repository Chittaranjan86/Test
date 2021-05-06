using EmployeeTest.Models;
using System.Collections.Generic;

namespace EmployeeTest.DataAccessLayer.Repository
{
    public interface IEmployeeRepository<T> where T : class
    {
        IList<Employee> GetAllEmployees();
        Employee GetEmployeeById(int Id);
        int AddEmployee(Employee emp);
        bool UpdateEmployee(Employee emp);
        bool DeleteEmployee(int Id);
    }
}