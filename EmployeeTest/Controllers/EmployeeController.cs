using EmployeeTest.DataAccessLayer.Repository;
using EmployeeTest.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace EmployeeTest.Controllers
{
    public class EmployeeController : ApiController
    {
        private IEmployeeRepository<Employee> _repo = null;

        public EmployeeController(IEmployeeRepository<Employee> repo)
        {
            _repo = repo;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet]
        public Employee Get(int id)
        {
            return _repo.GetEmployeeById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post(Employee emp)
        {
            _repo.AddEmployee(emp);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put(Employee emp)
        {
            _repo.UpdateEmployee(emp);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id)
        {
            _repo.DeleteEmployee(id);
        }
    }
}