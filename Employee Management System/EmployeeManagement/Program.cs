using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using EmployeeLeaveManagement;
using Domain;

namespace EmployeeManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                try
                {
                    Console.WriteLine("***********************************");
                    Console.WriteLine("---------------Main Menu-----------");
                    Console.WriteLine("***********************************");
                    Console.WriteLine("#1: Employee Management System");
                    Console.WriteLine("#2: Company Mangement System");
                    Console.WriteLine("#3: Client Mangement System");
                    Console.WriteLine("#4: Exit");
                    switch(Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            CreateMenu employeeMenu = new CreateMenu();
                            employeeMenu.EMSMenu();
                            break;
                        case 2:
                            CompanyMangementSystem displayCompany = new CompanyMangementSystem();
                            displayCompany.CompanyMangement();
                            break;
                        case 3:
                            ClientManagementSystem clientMangement = new ClientManagementSystem();
                            clientMangement.ClientMangement();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Option not available");
                            break;
                    }

                }
                catch(Exception)
                {
            
                    Console.WriteLine("Invalid input");
                }

            }
           
        }
    }
}
