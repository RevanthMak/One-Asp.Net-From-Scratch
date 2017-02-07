using System;
using System.Collections.Generic;

namespace Linq
{
    public class JoinExample
    {
        public static void Method1()
        {

            var Employees = new List<Employee>
        {
            new Employee {Id = 101, Name = "Name 1", StartDate = DateTime.Today },
            new Employee {Id = 102, Name = "Name 2", StartDate = DateTime.Now },
            new Employee {Id = 103, Name ="Name 3", StartDate = DateTime.UtcNow }
        };

            var Departments = new List<Department>
        {
            new Department {Id=101, Name = "Depart 1" },
            new Department {Id = 102, Name = "Depart 2" },
            new Department {Id = 103, Name = "Depart 3" }

        };
            
    
        }
            

    }
}
