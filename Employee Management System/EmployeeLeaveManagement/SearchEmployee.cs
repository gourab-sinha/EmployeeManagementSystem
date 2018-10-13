using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveManagement
{
    public class SearchEmployee
    {
        enum EmployeeStatus { employeeExist = 1, employeeNotExist = 2};
        public void SearchEmp(ref List<Employee> EmployeeList)
        {
            Employee searchEmp = new Employee();
            Console.WriteLine("Please Enter Employee ID whose details you want to see");
            string empID = searchEmp.SearchEmployee(Console.ReadLine());
            if (EmployeeList.Capacity >= 1)
            {
                int EmployeePresent = 0;
                foreach (var item in EmployeeList)
                {
                    if (empID == item.MatchEmployee())
                    {
                        item.DisplayEmployeeDetails();
                        EmployeePresent = 1;
                    }
                }
                if (EmployeePresent == (int)EmployeeStatus.employeeNotExist)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Employee does not exist");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No employee exists");
                Console.ResetColor();
            }
        }
    }
}
