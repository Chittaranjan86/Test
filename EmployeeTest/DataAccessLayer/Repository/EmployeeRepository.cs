using Dapper;
using EmployeeTest.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EmployeeTest.DataAccessLayer.Repository
{
    public class EmployeeRepository<T> : IEmployeeRepository<T> where T : class
    {
        public int AddEmployee(Employee emp)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))
            {
                string sqlQuery = "Insert Into Employee Values(" + emp.FirstName + ", " + emp.LastName + ");";
                int rowsAffected = db.Execute(sqlQuery, emp);
                return rowsAffected;
            }
        }

        public bool DeleteEmployee(int empId)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))
            {
                string sqlQuery = "Delete from Employee “WHERE Id = " + empId;
                int rowsAffected = db.Execute(sqlQuery);
                return !(rowsAffected == 0);
            }
        }

        public IList<Employee> GetAllEmployees()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))
            {
                return db.Query<Employee>("Select Id, FirstName, LastName From Employee").ToList();
            }
        }

        public Employee GetEmployeeById(int Id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))
            {
                string sqlQuery = "Select Id, FirstName, LastName From Employee where Id =" + Id;

                return db.QuerySingleOrDefault<Employee>(sqlQuery);
            }
        }

        public bool UpdateEmployee(Employee emp)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))
            {
                string sqlQuery = "UPDATE Employee SET FirstName =" + emp.FirstName + ", LastName = " + emp.LastName +  "WHERE Id = "+ emp.Id;
                int rowsAffected = db.Execute(sqlQuery, emp);
                return (rowsAffected ==1);
            }
        }
    }
}