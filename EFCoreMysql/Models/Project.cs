using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace EFCoreMysql.Models
{
    public class Project
    {

        protected Project() { }

        private Project(string projectName, Description description)
        {
            ProjectName = projectName;
            ProjectDescription = description;
        }

        public static Result<Project> Create(string ProjectName, string description)
        {
            if (ProjectName == null)
                throw new ArgumentNullException("ProjectName should not be null");
    

            return Result.Success(new Project(ProjectName,Description.Create(description).Value));
        }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public Description ProjectDescription { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }


    public class Description : ValueObject
    {
        protected Description() { }
        public string Value { get; }
        private Description(string value)
        {
            Value = value;
        }

        public static Result<Description> Create(string input)
        {

            string description = input.Trim();

            if (description.Length > 500)
                return Result.Failure<Description>("value is too long");

            return Result.Success(new Description(description));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
