using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace EFCoreMysql.Domain
{
    public class Employee :Entity
    {
        protected Employee() { }

        private Employee(string firstname, string lastname, Address address, Email email)
        {
            FirstName = firstname;
            Lastname = lastname;
            Address = address;
            Email = email;
        }
      

        public static Result<Employee> Create(string firstname, string lastname, string address, string email)
        {
            if(firstname== null)
                throw new ArgumentNullException("First Name should not be null");
            if(lastname == null)
                throw new ArgumentNullException("Last Name should not be null");

            if(email == null)
                throw new ArgumentNullException("Email should not be null");

            return Result.Success(new Employee(firstname, lastname, Address.Create(address).Value, Email.Create(email).Value));

        }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public Address Address { get; set; }

        public Email Email { get; set; }

        public virtual  ICollection<EmployeeProject> EmployeeProjects { get; set; }



    }


    public class Email : ValueObject
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Result<Email> Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Result.Failure<Email>("Value is Required");

            string email = input.Trim();

            if (email.Length > 150)
                return Result.Failure<Email>("value is too long");

            if (Regex.IsMatch(email, @"¨^(.+.)@(.+)$") == false)
                return Result.Failure<Email>("Value is invalid");


            return Result.Success(new Email(email));
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }


    public class Address : ValueObject
    {
        public string Value { get; }
        private Address(string value)
        {
            Value = value;
        }

        public static Result<Address> Create(string input)
        {


            string address = input.Trim();

            if (address.Length > 250)
                return Result.Failure<Address>("value is too long");

            if (Regex.IsMatch(address, @"[A-Za-z0-9'\.\-\s\,]") == false)
                return Result.Failure<Address>("Value is invalid");


            return Result.Success(new Address(address));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
