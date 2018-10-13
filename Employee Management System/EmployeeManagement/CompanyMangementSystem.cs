using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLeaveManagement;

namespace EmployeeManagement
{
    class CompanyMangementSystem
    {
        public enum Checkcompany { companyPresent = 1, companyAbsent = 2 };
        public void CompanyMangement()
        {
            List<Company> CompanyList = new List<Company>();
            while (true)
            {
                Console.WriteLine("**************************************");
                Console.WriteLine("------------------Menu----------------");
                Console.WriteLine("**************************************");
                Console.WriteLine("OPTION #1: ADD COMPANY DETAILS");
                Console.WriteLine("OPTION #2: VIEW COMPANY DETAILS");
                Console.WriteLine("OPTION #3: CHANGE SCREEN SETTINGS");
                Console.WriteLine("OPTION #4: RETURN TO MAIN MENU");
                Console.WriteLine("OPTION #5: EXIT");
                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("How many company details you want to add");
                            int numberOfEmployee = Convert.ToInt32(Console.ReadLine());
                            for (int i = 1; i <= numberOfEmployee; i++)
                            {
                                Company newCompany = new Company();
                                newCompany.AcceptInfo();
                                CompanyList.Add(newCompany);
                            }
                            break;
                        case 2:
                            if (CompanyList.Capacity >= 1)
                            {
                                int companystatus = 0;
                                Console.WriteLine("Enter company name");
                                string searchCompany = Console.ReadLine();
                                foreach (var company in CompanyList)
                                {
                                    if (searchCompany == company.SearchDetails())
                                    {
                                        company.DisplayInfo();
                                        companystatus = 1;
                                    }
                                    if (companystatus == (int)Checkcompany.companyPresent)
                                    {
                                        break;
                                    }
                                }
                                if (companystatus == (int)Checkcompany.companyAbsent)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Company does not exist");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("No company details available");
                                Console.ResetColor();
                            }
                            break;
                        case 3:
                            Employee.ColorSet();
                            break;
                        case 4:
                            return;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("There is no option");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
