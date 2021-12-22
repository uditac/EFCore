using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMysql.Models
{
    public class Employee
    {
        //public Employee()
        //{
        //    this.Projects = new HashSet<Project>();
        //}
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public virtual  ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
