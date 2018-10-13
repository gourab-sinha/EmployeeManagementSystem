using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using EmployeeLeaveManagement;

namespace EmployeeManagement
{
    interface IInformation
    {
        void DisplayInfo();
        void AcceptInfo();
        string GetNumber(string number);
        string SearchDetails();
    }
    class Company : IInformation
    {
        protected string companyName;
        private string companyAddress;
        private string numberOfEmployee;
        private string domainOfCompany;
        public string GetNumber(string numberOfEmployee)
        {
            string pattern = @"^([1-9]|[1-9][0-9]{2,4})$";
            Match match = Regex.Match(numberOfEmployee, pattern);
            if (match.Success)
            {
                return numberOfEmployee;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Invalid format!!\nPlease enter number of employee (e.g 500)");
            Console.ResetColor();
            return GetNumber(Console.ReadLine());

        }
        public void AcceptInfo()
        {
            Employee companyNameObj = new Employee();
            Console.WriteLine("Enter company name");
            companyName = companyNameObj.AcceptName(Console.ReadLine());
            Console.WriteLine("Enter company address:");
            companyAddress = Console.ReadLine();
            Console.WriteLine("Enter number of employee:");
            numberOfEmployee = GetNumber(Console.ReadLine());
            Console.WriteLine("Enter domain of the company:");
            domainOfCompany = companyNameObj.AcceptName(Console.ReadLine());
        }
        public void DisplayInfo()
        {
            Employee.ColorSet();
            Console.BackgroundColor = Employee.backgroundColor;
            Console.ForegroundColor = Employee.fontColor;
            Console.WriteLine("Company Name: " + companyName);
            Console.WriteLine("Company Addres: " + companyAddress);
            Console.WriteLine("Company Employee No: " + numberOfEmployee);
            Console.WriteLine("Company Domain: " + domainOfCompany);
            Console.ResetColor();
        }
        public string SearchDetails()
        {
            return companyName;
        }
    }
}