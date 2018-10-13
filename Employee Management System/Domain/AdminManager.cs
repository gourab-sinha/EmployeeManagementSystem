using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLeaveManagement;

namespace Domain
{
    public class AdminManager:Employee
    {
        public void RegisterEmployee(ref List<Employee> employeeList, ref SortedDictionary<string, List<string> > managerEmployee)
        {
            while (true)
            {
                Console.WriteLine("**************************************");
                Console.WriteLine("----------Admin Manager Menu----------");
                Console.WriteLine("**************************************");
                Console.WriteLine("OPTION #1: ADD EMPLOYEE DETAILS");
                Console.WriteLine("OPTION #2: VIEW EMPLOYEE DETAILS");
                Console.WriteLine("OPTION #3: UPDATE EMPLOYEE DETAILS");
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
                                AddEmp.NewEmployee(ref employeeList, ref managerEmployee);
                            }
                            break;
                        case 2:
                            Console.WriteLine("List of Employee ID");
                            if (employeeList.Capacity >= 1)
                            {
                                foreach (var employee in employeeList)
                                {
                                    Console.WriteLine(employee.MatchEmployee());
                                }
                                SearchEmployee seachEmp = new SearchEmployee();
                                seachEmp.SearchEmp(ref employeeList);
                            }
                            else
                            {
                                Console.WriteLine("No employee exist");
                            }
                            break;
                        case 3:
                            if(employeeList.Capacity >= 1)
                            {
                                int Flag = 1;
                                Console.WriteLine("Enter Employee ID whose details you want to update");
                                string employeeID = (new Employee()).SearchEmployee(Console.ReadLine());
                                foreach (var employee in employeeList)
                                {
                                    if(employeeID == employee.MatchEmployee())
                                    {
                                        employee.UpdateDetails(ref employeeList,ref managerEmployee);
                                        Flag = 2;
                                        break;
                                    }
                                }
                                if(Flag == 1)
                                {
                                    Console.WriteLine("No employee found");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No employee exist");
                            }
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
                catch (Exception e)
                {
                    Console.WriteLine(e.Source + e.Message);
                }
            }
        }
    }
}
