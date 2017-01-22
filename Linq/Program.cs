using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        public static void Main(string[] args)
        {
            IEnumerable<Employee> Data = new List<Employee>
            {
                new Employee { Id = 1, Name= "Name 1", StartDate = new DateTime(2000, 10, 4)},
                new Employee { Id = 2, Name= "Name 2", StartDate = new DateTime(2012, 5, 29)} ,
                new Employee { Id = 3, Name= "Name 3", StartDate = new DateTime(2008, 11, 3)}
            };

            IEnumerable<Employee> details = from e in Data
                                            where e.StartDate.Year < 2010
                                            orderby e.Name ascending
                                            select e;

            foreach(Employee m in details)
            {
                Console.WriteLine("The details got from database are {0}, {1}. {2}", m.Id,m.Name,m.StartDate.Year);
            }

            Console.ReadLine();
        }

        

    }
}
