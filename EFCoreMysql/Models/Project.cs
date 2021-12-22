using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

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

        public Description ProjectDescription { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }


    public class Description : ValueObject
    {
        public string Value { get; }
        private Description(string value)
        {
            Value = value;
        }

        public static Result<Description> Create(string input)
        {


            string address = input.Trim();

            if (address.Length > 500)
                return Result.Failure<Description>("value is too long");

            if (Regex.IsMatch(address, @"[A-Za-z0-9'\.\-\s\,]") == false)
                return Result.Failure<Description>("Value is invalid");


            return Result.Success(new Description(address));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
