using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class EmployeeRepo
    {
        public IEnumerable<Employee> GetAll()
        {
            return Emp;
        }

        List<Employee> Emp = new List<Employee>
        {
            new Employee { Id = 1, Name = "Name 1", StartDate = DateTime.Now},
            new Employee { Id = 2, Name = "Name 2", StartDate = DateTime.Now},
            new Employee { Id = 3, Name = "Name 3", StartDate = DateTime.Now},
            new Employee { Id = 4, Name = "Name 4", StartDate = DateTime.Now},
        };
    }
}
