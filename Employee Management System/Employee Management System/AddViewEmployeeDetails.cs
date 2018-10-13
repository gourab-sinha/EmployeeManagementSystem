using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System
{
    class AddViewEmployeeDetails
    {
        public void NewEmployee(ref List<EmployeeDetails> list)
        {
            EmployeeDetails EmpAdd = new EmployeeDetails();
            EmpAdd.CreateEmployee();
            list.Add(EmpAdd);
        }
        public void SearchEmp(ref List<EmployeeDetails> EmployeeList)
        {
            EmployeeDetails searchEmp = new EmployeeDetails();
            Console.WriteLine("Please Enter Employee ID whose details you want to see");
            string empID = searchEmp.searchEmployee(Console.ReadLine());
            if (EmployeeList.Capacity >= 1)
            {
                int EmployeePresent = 0;
                foreach (var item in EmployeeList)
                {
                    if (empID == item.MatchEmployee())
                    {
                        item.showEmployeeDetails();
                        EmployeePresent = 1;
                    }
                }
                if (EmployeePresent == 0)
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
