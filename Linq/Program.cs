using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq
{
    class Program
    {
        public static void Main(string[] args)
        {
            //GetEmployee();
            //GetTypes();
            QueryXML();
        }


        private static void QueryXML()
        {
            
            //Accessing XML using LINQ
            XDocument doc = new XDocument(
                new XElement("Processes",
                from p in Process.GetProcesses()
                orderby p.ProcessName ascending
                select new XElement("Process", new XAttribute( "Name", p.ProcessName), new XAttribute("ID", p.Id))));

            Console.WriteLine(doc.Document.ToString());
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
