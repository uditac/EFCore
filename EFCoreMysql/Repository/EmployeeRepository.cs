using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMysql.Models;
using EFCoreMysql.DBContexts;

namespace EFCoreMysql.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployee(string firstname,string lastname,string address ,string email);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyDBContext _dbContext;
        public EmployeeRepository(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> CreateEmployee(string firstname, string lastname, string address, string email)
        {
            Employee newEmployee = Employee.Create(firstname, lastname, address, email).Value;
            await _dbContext.AddAsync<Employee>(newEmployee);

            return newEmployee;
        }
    }
}
