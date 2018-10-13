using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EmployeeLeaveManagement;

namespace EmployeeManagement
{
    class ClientInfo: IInformation
    {
        private string clientName;
        private string clientAddress;
        private string clientNumber;
        private const string countryCode = "+1";
        private string clientCompany;
        public ClientInfo()
        {
            AcceptInfo();
        }
        public string GetNumber(string number)
        {
            string pattern = @"^([1-9][0-9]{9})$";
            Match match = Regex.Match(number, pattern);
            if (match.Success)
            {
                return number;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Invalid format!!\nPlease enter contact number (e.g 8946065442)");
            Console.ResetColor();
            return GetNumber(Console.ReadLine());
        }
        public void DisplayInfo()
        {
            Employee.ColorSet();
            Console.BackgroundColor = Employee.backgroundColor;
            Console.ForegroundColor = Employee.fontColor;
            Console.WriteLine("Company Name: " + clientName);
            Console.WriteLine("Company Addres: " + clientAddress);
            Console.WriteLine("Company Employee No: " + clientNumber);
            Console.WriteLine("Company Domain: " + clientCompany);
            Console.ResetColor();
        }
        public void AcceptInfo()
        {
            Employee clientEntry = new Employee();
            Console.WriteLine("Enter client name");
            clientName = clientEntry.AcceptName(Console.ReadLine());
            Console.WriteLine("Enter client address:");
            clientAddress = Console.ReadLine();
            Console.WriteLine("Enter client contact number:");
            clientNumber = countryCode + GetNumber(Console.ReadLine());
            Console.WriteLine("Enter client company:");
            clientCompany = clientEntry.AcceptName(Console.ReadLine());
        }
        public string SearchDetails()
        {
            return clientName;
        }
    }
}
