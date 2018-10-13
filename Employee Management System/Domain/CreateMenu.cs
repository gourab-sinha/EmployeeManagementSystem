using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLeaveManagement;

namespace Domain
{
    public class CreateMenu
    {
        public void EMSMenu()
        {
            SortedDictionary<string, List<string>> managerEmployee = new SortedDictionary<string, List<string>>();
            List<Employee> EmployeeList = new List<Employee>();
            while (true)
            {
                try
                {
                    Console.WriteLine("**************************************");
                    Console.WriteLine("---------------EMS Menu----------------");
                    Console.WriteLine("**************************************");
                    Console.WriteLine("OPTION #1: ADMIN MANAGER");
                    Console.WriteLine("OPTION #2: ADMIN");
                    Console.WriteLine("OPTION #3: MANAGER");
                    Console.WriteLine("OPTION #4: HR");
                    Console.WriteLine("OPTION #5: EMPLOYEE");
                    Console.WriteLine("OPTION #6: RETURN");
                    Console.WriteLine("OPTION #7: EXIT");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            AdminManager adminCall = new AdminManager();
                            adminCall.RegisterEmployee(ref EmployeeList,ref managerEmployee);
                            //ADMIN MANAGER
                            break;
                        case 2:
                            //ADMIN
                            break;
                        case 3:
                            //MANAGER
                            Manager listEmployee = new Manager();
                            listEmployee.ManagerCallFromEmployee(ref EmployeeList,ref managerEmployee);
                            break;
                        case 4:
                            //HR
                            //Admin hrMenu = new Admin();
                            //hrMenu.HRCreateMenu(ref EmployeeList);
                            break;
                        case 5:
                            EmployeeClass employeeCheck = new EmployeeClass();
                            employeeCheck.Authentication(ref EmployeeList);
                            break;
                        case 6:
                            return;
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Option Not Available");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Source);
                }
            }
        }
    }
}
