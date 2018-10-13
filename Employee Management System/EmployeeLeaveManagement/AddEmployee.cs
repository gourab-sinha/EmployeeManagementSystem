using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveManagement
{
    public class AddEmployee
    {
        public void NewEmployee(ref List<Employee> list,ref SortedDictionary<string, List<string>> managerEmployee)
        {
            Employee newEmpName = new Employee();
            Console.WriteLine("Enter First Name (e.g Gourab)");
            string nameFirst = newEmpName.AcceptName(Console.ReadLine());
            Console.WriteLine("Enter Last Name (e.g Gourab)");
            string nameLast = newEmpName.AcceptName(Console.ReadLine());
            Employee newEmployee = new Employee(nameFirst,nameLast);
            newEmployee.AcceptEmployeeDetails(ref list, ref managerEmployee);
            list.Add(newEmployee);
        }
    }
}
