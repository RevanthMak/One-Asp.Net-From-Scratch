using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Linq
{
    class Program
    {
        public static void Main(string[] args)
        {
            //GetEmployee();
            //GetTypes();
            //QueryXML();
            //SimpleEmployeeQueries();
            //ExampleOfSelectMany();
            JoinsExample();
        }

        private static void JoinsExample()
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
            new Department {Id = 104, Name = "Depart 3" }

        };

            var query =
                from d in Departments
                join e in Employees on d.Id equals e.Id
                select new
                {
                    DepartmentId = d.Id,
                    EmployeeName = e.Name
                };

            //Extension Method Syntax
            //Group Join 
            var query2 =
                Departments.GroupJoin(
                    Employees,
                    e => e.Id,
                    d => d.Id,
                    (eg, d) => new
                    {
                        DepartmentId = d, 
                        EmployeeName = eg
                    }
                    );

             
        }

        private static void ExampleOfSelectMany()
        {
            string[] x =
            {
                "X is an example of y", 
                "X is not the real number it's just a character"
            };

            var Output = (from data in x
                          from word in data.Split(' ')
                          select word
                           ).Distinct();

            //Look for the difference
            var Output2 = x.Select(p => p.Split(' ').Distinct());
            var Output3 = x.SelectMany(p => p.Split(' ').Distinct());

        }

        private static void SimpleEmployeeQueries()
        {
            //Comprehension Query 
            var result =
                from e in new EmployeeRepo().GetAll()
                where e.Id < 3
                orderby e.Id ascending, e.Name descending
                select e;

            //Extension Method Query
            var result2 =
                new EmployeeRepo().GetAll()
                    .Where(e => e.Id < 3)
                    .OrderByDescending(e => e.Id)
                    .OrderBy(e => e.Name);
            
            print(result);
            print(result2);
            Console.ReadLine();
        }

        static void print(IEnumerable<Employee> x )
        {
            foreach(Employee emp in x)
            {
                Console.WriteLine(emp.Name);
            }
        }

        private static void QueryXML()
        {
            
            //Accessing XML using LINQ
            XDocument doc = new XDocument(
                new XElement("Processes",
                from p in Process.GetProcesses()
                orderby p.ProcessName ascending
                select new XElement("Process", new XAttribute( "Name", p.ProcessName), new XAttribute("ID", p.Id))));

            //Console.WriteLine(doc.Document.ToString());
            //Console.Read();

            //Querying XML
            IEnumerable<int> docdata = from e in doc.Descendants("Process")
                                       where e.Attribute("Name").Value == "devenv"
                                       orderby (int)e.Attribute("ID") ascending
                                       select (int)e.Attribute("ID");

            foreach(int i in docdata)
            {
                Console.WriteLine(i);
            }
            Console.Read();
        }

        private static void GetTypes()
        {
            //Linq to Objects 
            IEnumerable<string> types = from t in Assembly.GetExecutingAssembly().GetTypes()
                                        where t.IsPublic
                                        select t.FullName;

            foreach(string c in types)
            {
                Console.WriteLine(c);
            }
        }

        private static void GetEmployee()
        {
            List<Employee> Data = new List<Employee>
            {
                new Employee { Id = 1, Name= "Name 1", StartDate = new DateTime(2000, 10, 4)},
                new Employee { Id = 2, Name= "Name 2", StartDate = new DateTime(2012, 5, 29)} ,
                new Employee { Id = 3, Name= "Name 3", StartDate = new DateTime(2008, 11, 3)}
            };

            IEnumerable<Employee> details = from e in Data
                                            where e.StartDate.Year < 2010
                                            orderby e.Name ascending
                                            select e;

            //Example for differed execution with lazy operators 
            Data.Add(new Employee { Id = 4, Name = "Name 4", StartDate = new DateTime(2001, 7, 15) });

            foreach (Employee m in details)
            {
                Console.WriteLine("The details got from database are {0}, {1}. {2}", m.Id, m.Name, m.StartDate.Year);
            }

            Console.ReadLine();
        }


    }
}
