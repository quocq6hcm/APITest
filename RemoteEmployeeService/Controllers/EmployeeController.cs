using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RemoteEmployeeService.Controllers
{
    public class EmployeeController : ApiController
    {
        Models.EmployeeContext _db = new Models.EmployeeContext();
        public IHttpActionResult GetEmployeeList()
        {

            return Ok(_db.Employees);
        }

        public IHttpActionResult PostEmployee(Models.Employee e)
        {
            _db.Employees.Add(e);
            _db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult GetEmployee(int id)
        {
            return Ok(_db.Employees.SingleOrDefault(e => e.EmployeeID.Equals(id)));
        }
        public IHttpActionResult PutEmployee(Models.Employee e)
        {
            Models.Employee temp = _db.Employees.SingleOrDefault(a => a.EmployeeID.Equals(e.EmployeeID));
            temp.EmployeeName = e.EmployeeName;
            temp.Address = e.Address;
            temp.Email = e.Email;

            _db.SaveChanges();
            return Ok();
        }
    }
}
