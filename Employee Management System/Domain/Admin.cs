using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLeaveManagement;

namespace Domain
{
    class Admin:Employee
    {
        public void AdminCall(ref List<Employee> EmployeeList,ref SortedDictionary<string, List<string> > managerEmployee)
        {
            while (true)
            {
                Console.WriteLine("**************************************");
                Console.WriteLine("---------------Admin Menu----------------");
                Console.WriteLine("**************************************");
                Console.WriteLine("OPTION #1: ADD EMPLOYEE DETAILS");
                Console.WriteLine("OPTION #2: VIEW EMPLOYEE DETAILS");
                Console.WriteLine("OPTION #3: CHANGE SCREEN SETTINGS");
                Console.WriteLine("OPTION #4: RETURN TO MAIN MENU");
                Console.WriteLine("OPTION #5: EXIT");
                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("How many Employee details you want to add");
                            int numberOfEmployee = Convert.ToInt32(Console.ReadLine());
                            for (int i = 1; i <= numberOfEmployee; i++)
                            {
                                AddEmployee AddEmp = new AddEmployee();
                                AddEmp.NewEmployee(ref EmployeeList,ref managerEmployee);
                            }
                            break;
                        case 2:
                            Console.WriteLine("List of Employee ID");
                            if (EmployeeList.Capacity >= 1)
                            {
                                foreach (var employee in EmployeeList)
                                {
                                    Console.WriteLine(employee.MatchEmployee());
                                }
                                SearchEmployee seachEmp = new SearchEmployee();
                                seachEmp.SearchEmp(ref EmployeeList);
                            }
                            else
                            {
                                Console.WriteLine("No employee exist");
                            }
                            break;
                        case 3:
                            Employee.ColorSet();
                            break;
                        case 4:
                            return;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Option not available");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
