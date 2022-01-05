using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMysql.Domain
{
    public class EmployeeProject
    {
       
            public int EmployeeId { get; set; }
            public Employee Employee { get; set; }
            public int ProjectId { get; set; }
            public Project Project { get; set; }
        
    }
}
