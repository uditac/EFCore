using EFCoreMysql.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMysql.Models.Response
{
    public class ProjectViewModel
    {
        public int ProjectId { get; }

        public string ProjectName { get; }

        public string ProjectDescription { get;}

        public List<string> EmployeeNames { get; }

        public ProjectViewModel(Project project)
        {
            ProjectId = project.ProjectId;
            ProjectName = project.ProjectName;
            ProjectDescription = project.ProjectDescription.Value;
            EmployeeNames = project.EmployeeProjects.Select(x => x.Employee.FirstName).ToList();
        }
    }
}
