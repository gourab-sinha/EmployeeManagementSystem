using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLeaveManagement;

namespace Domain
{
    class Manager:Employee
    {
        public void ManagerCallFromEmployee(ref List<Employee> employeeList,ref SortedDictionary<string, List<string>> managerEmployee)
        {
            while (true)
            {
                Console.WriteLine("**************************************");
                Console.WriteLine("----------------Manager Menu----------");
                Console.WriteLine("**************************************");
                Console.WriteLine("OPTION #1: LEAVE APPROVE");
                Console.WriteLine("OPTION #2: LEAVE REJECT");
                Console.WriteLine("OPTION #3: LEAVE PENDING");
                Console.WriteLine("OPTION #4: RETURN TO MAIN MENU");
                Console.WriteLine("OPTION #5: EXIT");
                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            ListOfEmployee(1,ref employeeList, ref managerEmployee);
                            break;
                        case 2:
                            ListOfEmployee(2, ref employeeList, ref managerEmployee);
                            break;
                        case 3:
                            ListOfEmployee(2, ref employeeList, ref managerEmployee);
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Option not available");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
        public void ListOfEmployee(int DoUpdate,ref List<Employee> EmployeeList,ref SortedDictionary<string, List<string>> managerEmployee)
        {
            Console.WriteLine("");
            foreach (var employeeUnderManger in managerEmployee)
            {
                Console.WriteLine("Manager ID: " + employeeUnderManger.Key);
                foreach (var employee in employeeUnderManger.Value)
                {
                    foreach (var employeestatus in EmployeeList)
                    {
                        if(employee == employeestatus.MatchEmployee())
                        {
                            Console.WriteLine(employeestatus.CheckLeaveStatus());
                            if(DoUpdate == 1)
                            {
                                employeestatus.LeaveApprove();
                            }
                            else if(DoUpdate == 2)
                            {
                                employeestatus.LeaveRejected();
                            }
                            else if(DoUpdate == 3)
                            {
                                employeestatus.LeavePending();
                            }
                        }
                    }
                }
            }
        }
    }
}
