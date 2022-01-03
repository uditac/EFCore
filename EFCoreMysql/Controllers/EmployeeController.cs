using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMysql.Repository;
using EFCoreMysql.Models;

namespace EFCoreMysql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateEmployee(string firstname, string lastname, string address, string email)
        {
            Employee employee = new Employee();
            return Ok(employee);
        }


    }
}
