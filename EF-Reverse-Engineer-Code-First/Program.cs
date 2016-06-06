using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EF_Reverse_Engineer_Code_First.models;

namespace EF_Reverse_Engineer_Code_First
{
    class Program
    {
        static void Main(string[] args)
        {

            //Introduction to EF
            //LinqQuery();


            //Query with EF
            //QueryWithEntity_AllEntities();
            //QueryWithEntity_FilterWithWhere();
            //QueryWithEntity_FindWithPrimaryKey();


            //Add Entities
            //addEntity();

            //updateEntity();

            deleteEntity();
        }



        public static void LinqQuery() {
            Console.WriteLine("Query syntax ");

            Console.WriteLine("Returns All Employees ");
            Console.WriteLine("");
            using (NorthwindContext db = new NorthwindContext())
            {
                var employees = from e in db.Employees
                                select e;

                foreach (Employee e in employees)
                {
                    Console.WriteLine("{0} {1} {2}", e.FirstName.PadRight(20), e.LastName.PadRight(20), e.Title.PadRight(20));
                }
            }
            Console.WriteLine("");


            Console.WriteLine("Returns Employee with last name king");
            Console.WriteLine("");
            using (NorthwindContext db = new NorthwindContext())
            {
                var employees = from e in db.Employees
                                where e.LastName == "King"
                                select e;

                foreach (Employee e in employees)
                {
                    Console.WriteLine("{0} {1} {2}", e.FirstName.PadRight(20), e.LastName.PadRight(20), e.Title.PadRight(20));
                }
            }
            Console.WriteLine("");


            Console.WriteLine("Method syntax");

            Console.WriteLine("Returns All Employees", "");
            Console.WriteLine("");
            using (NorthwindContext db = new NorthwindContext())
            {
                var employees = db.Employees;

                foreach (Employee e in employees)
                {
                    Console.WriteLine("{0} {1} {2}", e.FirstName.PadRight(20), e.LastName.PadRight(20), e.Title.PadRight(20));
                }
            }
            Console.WriteLine("");

            Console.WriteLine("Employee with last name King", "");
            Console.WriteLine("");
            using (NorthwindContext db = new NorthwindContext())
            {
                var employees = db.Employees
                               .Where(employee => employee.LastName == "King");

                foreach (Employee e in employees)
                {
                    Console.WriteLine("{0} {1} {2}", e.FirstName.PadRight(20), e.LastName.PadRight(20), e.Title.PadRight(20));
                }
            }
            Console.WriteLine("");
        }


        public static void QueryWithEntity_AllEntities()
        {


            Console.WriteLine("Select All Employees ");
            Console.WriteLine("");

            Console.WriteLine("Query Syntax ");
            Console.WriteLine("");

            using (NorthwindContext db = new NorthwindContext())
            {
                var employees = from e in db.Employees
                                select e;

                foreach (Employee e in employees)
                {
                    Console.WriteLine("{0} {1} {2}", e.FirstName.PadRight(20), e.LastName.PadRight(20), e.Title.PadRight(20));
                }
            }
            Console.WriteLine("");


            Console.WriteLine("Method syntax");
            Console.WriteLine("");
            using (NorthwindContext db = new NorthwindContext())
            {
                var employees = db.Employees;

                foreach (Employee e in employees)
                {
                    Console.WriteLine("{0} {1} {2}", e.FirstName.PadRight(20), e.LastName.PadRight(20), e.Title.PadRight(20));
                }
            }
            Console.WriteLine("");

        }
        public static void QueryWithEntity_FilterWithWhere()
        {


            Console.WriteLine("Select All Employees ");
            Console.WriteLine("");

            Console.WriteLine("Query Syntax ");
            Console.WriteLine("");

            using (NorthwindContext db = new NorthwindContext())
            {
                var employees = from e in db.Employees
                                where e.FirstName.StartsWith("A")
                                select e;

                foreach (Employee e in employees)
                {
                    Console.WriteLine("{0} {1} {2}", e.FirstName.PadRight(20), e.LastName.PadRight(20), e.Title.PadRight(20));
                }
            }
            Console.WriteLine("");


            Console.WriteLine("Method syntax");
            Console.WriteLine("");
            using (NorthwindContext db = new NorthwindContext())
            {
                var employees = db.Employees
                                .Where(e => e.FirstName.StartsWith("A"));
                    

                foreach (Employee e in employees)
                {
                    Console.WriteLine("{0} {1} {2}", e.FirstName.PadRight(20), e.LastName.PadRight(20), e.Title.PadRight(20));
                }
            }
            Console.WriteLine("");

        }
    
        public static void QueryWithEntity_FindWithPrimaryKey()
        {


            Console.WriteLine("Select All Employees ");
            Console.WriteLine("");


            Console.WriteLine("Method syntax");
            Console.WriteLine("");
            using (NorthwindContext db = new NorthwindContext())
            {
                var employee = db.Employees.Find(1);

                Console.WriteLine("{0} {1} {2}", employee.FirstName.PadRight(20), employee.LastName.PadRight(20), employee.Title.PadRight(20));
            }
            Console.WriteLine("");


            Console.WriteLine("Query Syntax ");
            Console.WriteLine("");

    
            using (NorthwindContext db = new NorthwindContext())
            {
                var employees = from e in db.Employees
                where e.EmployeeID == 1
                select e;

                foreach (Employee e in employees)
                {
                    Console.WriteLine("{0} {1} {2}", e.FirstName.PadRight(20), e.LastName.PadRight(20), e.Title.PadRight(20));
                }
            }
            Console.WriteLine("");




        }


        public static void addEntity()
        {

            Employee newEmployee = new Employee();
            newEmployee.FirstName = "Sachin";
            newEmployee.LastName = "Tendulkar";
            using (NorthwindContext db = new NorthwindContext())
            {
                db.Employees.Add(newEmployee);
                db.SaveChanges();
            }

            //Using Entry
            Employee newEmployee1 = new Employee();
            newEmployee1.FirstName = "Rahul";
            newEmployee1.LastName = "Dravid";
            using (NorthwindContext db = new NorthwindContext())
            {
                db.Entry(newEmployee1).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }



        }


        public static void updateEntity()
        {
            Employee emp;

            //Connected
            using (NorthwindContext db = new NorthwindContext())
            {
                emp=  db.Employees.Where(e => e.EmployeeID == 1).FirstOrDefault() ;
                emp.Title = "Manager";
                db.SaveChanges();
            }


            //disconnected
            using (NorthwindContext db = new NorthwindContext())
            {
                emp = db.Employees.Where(e => e.EmployeeID == 2).FirstOrDefault();
            }

            emp.Title = "Manager";
            using (NorthwindContext dbctx = new NorthwindContext())
            {
                dbctx.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                dbctx.SaveChanges();
            }

        }



        public static void deleteEntity()
        {
            Employee emp;

            ////Connected
            //using (NorthwindContext db = new NorthwindContext())
            //{
            //    emp = db.Employees.Where(e => e.EmployeeID == 11).FirstOrDefault();
            //    db.Employees.Remove(emp);
            //    db.SaveChanges();
            //}


            ////disconnected
            //using (NorthwindContext db = new NorthwindContext())
            //{
            //    emp = db.Employees.Where(e => e.EmployeeID == 12).FirstOrDefault();
            //}

            //using (NorthwindContext dbctx = new NorthwindContext())
            //{
            //    dbctx.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            //    dbctx.SaveChanges();
            //}



            //using (NorthwindContext dbctx = new NorthwindContext())
            //{
            //    dbctx.Employees.Attach(emp);
            //    dbctx.Employees.Remove(emp);
            //    dbctx.SaveChanges();
            //}


            //emp = new Employee();
            //emp.EmployeeID = 13;
            //using (NorthwindContext dbctx = new NorthwindContext())
            //{
            //    dbctx.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            //    dbctx.SaveChanges();
            //}


        }


    }
}
