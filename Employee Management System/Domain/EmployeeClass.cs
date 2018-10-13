using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLeaveManagement;
namespace Domain
{
    interface ILeaveFunctionality
    {
        void EmployeeApplication(Employee employee,ref List<Employee> employeeList);
        void Authentication(ref List<Employee> employeeList);
        //void ApplyLeave(ref Employee employee);
        //void ViewLeaveBalance(ref Employee employee);
        //void CancelLeave(ref Employee employee);
        //void CurrentLeaveStatus(ref Employee employeeList);
    };
    class EmployeeClass:Employee,ILeaveFunctionality
    {
        public void EmployeeApplication(Employee employee,ref List<Employee> employeeList)
        {
            while(true)
            {
                try
                {
                    Console.WriteLine("OPTION #1: Apply Leave");
                    Console.WriteLine("OPTION #2: Cancel Leave");
                    Console.WriteLine("OPTION #3: Leave Status");
                    Console.WriteLine("OPTION #4: View Leaves Balance");
                    Console.WriteLine("OPTION #5: Manager Details");
                    Console.WriteLine("OPTION #6: Exit");
                    switch(Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            employee.LeaveApplied();
                            break;
                        case 2:
                            employee.LeaveCancel();
                            break;
                        case 3:
                            Console.WriteLine("Status:" + employee.CheckLeaveStatus());
                            break;
                        case 4:
                            Console.WriteLine(employee.LeaveBalance());
                            break;
                        case 5:
                            string managerID = employee.SearchEmployee(Console.ReadLine());
                            int Flag = 1;
                            foreach (var employees in employeeList)
                            {
                                if(managerID == employees.MatchEmployee() && employees.EmployeeRole() == "Manager")
                                {
                                    employees.DisplayEmployeeDetails();
                                    Flag = 2;
                                }
                            }
                            if(Flag == 1)
                            {
                                Console.WriteLine("Manager with " + managerID);
                            }
                            break;
                        case 6:
                            return;
                        default:
                            Console.WriteLine("Option is not available");
                            break;
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Invalid input");
                }
            }
            
        }
        public void Authentication(ref List<Employee> employeeList)
        {
            if (employeeList.Capacity >= 1)
            {
                Employee searchEmpID = new Employee();
                Console.WriteLine("Enter Employee ID:");
                string employeeID = searchEmpID.SearchEmployee(Console.ReadLine());
                Console.WriteLine("Enter Password:");
                string employeePassword = Console.ReadLine();
                foreach (var employee in employeeList)
                {
                    if (employeeID == employee.MatchEmployee() && (employee.ReturnPassword() == employeePassword || employee.passwordUpdate == false))
                    {
                        if(employee.passwordUpdate == false)
                            employee.SetPassword();
                        EmployeeApplication(employee,ref employeeList);
                    }
                }
            }
        }
    }
}
