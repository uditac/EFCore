using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMysql.Models
{
    public class Project
    {
        //public Project()
        //{
        //    this.Employees = new HashSet<Employee>();
        //}
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
    }
