using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace RemoteEmployeeService.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("HRManager23Cnn")
        {

        }

        public DbSet<Models.Employee> Employees { get; set; }
    }
}