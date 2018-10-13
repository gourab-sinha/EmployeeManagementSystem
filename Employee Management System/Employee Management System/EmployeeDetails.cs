using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Employee_Management_System
{

    class EmployeeDetails
    {
        private string employeeId;
        private string employeeFirstName;
        private string employeeLastName;
        private string employeeAddress1;
        private string employeeAddress2;
        private string age;
        private string employeeSalary;
        private string employeeMobileNo;
        private string employeeDOJ;
        private string employeePreLoc;
        static ConsoleColor fontColor = ConsoleColor.White;
        static ConsoleColor backgroundColor = ConsoleColor.Blue;
        private string GetId(string employeeId)
        {
            int Flag = 0;
            if (employeeId[0] == 'E' && employeeId.Length == 4)
            {
                for (int i = 1; i < employeeId.Length; i++)
                {
                    if ((int)employeeId[i] < 48 || (int)employeeId[i] > 57)
                    {
                        Flag = 1;
                        break;
                    }
                }
                if (Flag == 0)
                    return employeeId;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Wrong ID Format!!\nPlease Enter Employee ID (e.g E100):");
            Console.ResetColor();
            return GetId(Console.ReadLine());
        }
        private string GetNames(string names) // Take Names and validate
        {
            int Flag = 0;
            if ((names.Length <= 30) && (names.All(char.IsLetter) == true) && (names[0] >= 65 && names[0] <= 90))
            {
                if (names.Length == 1)
                    Flag = 1;
                for (int i = 1; i < names.Length; i++)
                {
                    if (names[i] >= 97 && names[i] <= 122)
                    {
                        Flag = 1;
                    }
                }
            }
            if (Flag == 1)
            {
                return names;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please Enter name. Name length should be less than 30 and Pascal case (e.g: Gourab)");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.ResetColor();
            return GetNames(Console.ReadLine());
        }
        private string GetAge(string employeeDOB) // Calculate age and verify age is above 18 or not
        {
            string[] formats = { "MM/dd/yyyy" };
            DateTime parsedDateTime;
            bool correctDateFormat = DateTime.TryParseExact(employeeDOB, formats, new CultureInfo("en-US"),
                                           DateTimeStyles.None, out parsedDateTime);
            if (correctDateFormat == true)
            {
                string[] dob = (parsedDateTime.ToString("MM/dd/yyyy")).Split('-');
                int mm = Convert.ToInt32(dob[0]);
                int dd = Convert.ToInt32(dob[1]);
                int yyyy = Convert.ToInt32(dob[2]);
                DateTime today = DateTime.Today;
                string[] currDate = (today.ToString("MM/dd/yyyy")).Split('-');
                int currMM = Convert.ToInt32(currDate[0]);
                int currDD = Convert.ToInt32(currDate[1]);
                int currYYYY = Convert.ToInt32(currDate[2]);
                if (currDD - dd < 0)
                {
                    dd = currDD + 30 - dd;
                    currMM -= 1;
                }
                else
                {
                    dd = currDD - dd;
                }
                if (currMM - mm < 0)
                {
                    mm = currMM + 12 - mm;
                    currYYYY -= 1;
                }
                else
                {
                    mm = currMM - mm;
                }
                yyyy = currYYYY - yyyy;
                if (yyyy >= 18)
                {
                    return (yyyy + " years " + mm + " months " + dd + " days");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Employee Age should be greater than or equal to 18");
                    Console.ResetColor();
                    return GetAge(Console.ReadLine());

                }
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Date format not matched\n" +
                "Possible Cases: 1. Beyond days in a month\n2. DD/MM/YYYY\n" +
                "Please enter DOB in MM/DD/YYYY Format");
            Console.ResetColor();
            return GetAge(Console.ReadLine());
        }
        private string GetSalary(string salary) // Salary check
        {
            string pattern = @"^([1-9][0-9]{4}|[1-9][0-9]{3}|[1-9][[0-9]{2})$";
            Match result = Regex.Match(salary, pattern);
            if(result.Success)
            {
                return salary;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please enter valid salary (e.g: 16000)");
            Console.ResetColor();
            return GetSalary(Console.ReadLine());
        }
        private string GetMobileNo(string employeeMobileNo) // Mobile number validation
        {
            string pattern = @"^\+([1-9]|[1-9][0-9]|[1-3][0-9][0-9])\s[1-9][0-9]{9}$";
            Match result = Regex.Match(employeeMobileNo, pattern);
            if (result.Success)
            {
                return employeeMobileNo;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Wrong Mobile No format!!");
            Console.WriteLine("Please Enter Mobile No (e.g +91 8946065442)");
            Console.ResetColor();
            return GetMobileNo(Console.ReadLine());
        }
        private string GetDOJ(string employeeDOJ) //DOJ validation
        {
            string[] formats = { "MM/dd/yyyy" };
            DateTime parsedDateTime;
            bool correctDateFormat = DateTime.TryParseExact(employeeDOJ, formats, new CultureInfo("en-US"),
                                           DateTimeStyles.None, out parsedDateTime);
            if(correctDateFormat == true)
            {
                return employeeDOJ + ", " + parsedDateTime.DayOfWeek.ToString();
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please enter valid DOJ(e.g MM/DD/YYYY)");
            Console.ResetColor();
            return GetDOJ(Console.ReadLine());
        }
        private string GetPreferredLoc() //returns Preferred Location
        {
            while (true)
            {
                Console.WriteLine("Please Select from List\n");
                Console.WriteLine("**************************");
                Console.WriteLine("#1. Bengaluru");
                Console.WriteLine("#2. Chennai");
                Console.WriteLine("#3. Delhi");
                Console.WriteLine("#4. Gurgram");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        return "Bengaluru";
                    case 2:
                        return "Chennai";
                    case 3:
                        return "Delhi";
                    case 4:
                        return "Gurgram";
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid option");
                        Console.ResetColor();
                        break;
                }
            }
        }
        private static ConsoleColor chooseColor()
        {
            while (true)
            {
                Console.WriteLine("#1. RED");
                Console.WriteLine("#2. GREEN");
                Console.WriteLine("#3. BLACK");
                Console.WriteLine("#4. WHITE");
                Console.WriteLine("#5. BLUE");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Successfully set to RED");
                        return ConsoleColor.Red;
                    case 2:
                        Console.WriteLine("Successfully set to GREEN");
                        return ConsoleColor.Green;
                    case 3:
                        Console.WriteLine("Successfully set to BLACK");
                        return ConsoleColor.Black;
                    case 4:
                        Console.WriteLine("Successfully set to WHITE");
                        return ConsoleColor.White;
                    case 5:
                        Console.WriteLine("Successfully set to BLUE");
                        return ConsoleColor.Blue;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Please choose valid option");
                        Console.ResetColor();
                        break;
                }
            }
        }
        public void CreateEmployee() // Creates New Employee
        {
            Console.WriteLine("Please Enter Employee ID (e.g E104):");
            employeeId = GetId(Console.ReadLine());
            Console.WriteLine("Please Enter Employee First Name:");
            employeeFirstName = GetNames(Console.ReadLine());
            Console.WriteLine("Please Enter Employee Last Name:");
            employeeLastName = GetNames(Console.ReadLine());
            Console.WriteLine("Please Enter Employee Address1:");
            employeeAddress1 = Console.ReadLine();
            Console.WriteLine("Please Enter Employee Address2:");
            employeeAddress2 = Console.ReadLine();
            Console.WriteLine("Please Enter Employee DOB in MM/DD/YYYY format:");
            age = GetAge(Console.ReadLine());
            Console.WriteLine("Please Enter Employee Salary:");
            employeeSalary = GetSalary(Console.ReadLine());
            Console.WriteLine("Please Enter Employee Mobile No(e.g +91 8946065442):");
            employeeMobileNo = GetMobileNo(Console.ReadLine());
            Console.WriteLine("Please Enter Employee DOJ in MM/DD/YYYY:");
            employeeDOJ = GetDOJ(Console.ReadLine());
            Console.WriteLine("Please Enter Preferred Location");
            employeePreLoc = GetPreferredLoc();
        }
        public void showEmployeeDetails() // Show Details of employee
        {
            //Console.WriteLine("Please choose background color");
            Console.BackgroundColor = backgroundColor;
            //Console.WriteLine("Please choose font color");
            Console.ForegroundColor = fontColor;
            Console.WriteLine(employeeId + ":" + employeeFirstName + " " + employeeLastName);
            Console.WriteLine(employeeAddress1);
            Console.WriteLine(age);
            Console.WriteLine("Salary INR " + employeeSalary);
            Console.WriteLine(employeeMobileNo);
            Console.WriteLine("Joined: " + employeeDOJ);
            Console.ResetColor();
        }
        public string searchEmployee(string empID)
        {
            return GetId(empID);
        }
        public string MatchEmployee()
        {
            return employeeId;
        }
        public static void ColorSet()
        {
            Console.WriteLine("Please choose font color");
            fontColor = chooseColor();
            Console.WriteLine("Please choose background color");
            backgroundColor = chooseColor();
        }
    }
}
