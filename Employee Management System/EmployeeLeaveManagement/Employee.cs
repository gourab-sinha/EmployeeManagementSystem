using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace EmployeeLeaveManagement
{
    public class Employee
    {
        private readonly string employeeId;
        private readonly string employeeEmailAdd;
        private string employeePassword;
        private string employeeFirstName;
        private string employeeLastName;
        private string employeeAddress1;
        private string employeeAddress2;
        private string employeeAge;
        private string employeeSalary;
        private string employeeMobileNo;
        private string employeeDOJ;
        private string employeePreLoc;
        private string employeeLevel;
        private string employeeRole;
        private string employeeLeaveStatus = "";
        private string employeeUnderManagerID = "";
        private static int employeeLeaveBalance = 5;
        public static ConsoleColor fontColor = ConsoleColor.White;
        public static ConsoleColor backgroundColor = ConsoleColor.Blue;
        public bool passwordUpdate = false;
        static int employeeNo = 0;
        public enum EmployeeIDrange { ten = 10, nine = 9, ninetynine = 99, thousand = 1000, asciiLower = 48, asciiHigh = 57};
        public enum EmployeeIDLength { four = 4};
        public enum LevelEmployee { L1=1, L2, L3A, L3B, L4A, L4B, L4C, L5A, L5B, L5C, L6A, L6B, L6C, L7 };
        public enum RoleEmployee { AdminManager = 1, Admin, Manager, Employee, HumanResource};
        public enum LeaveStatusEmployee { Applied = 1, Approve, Rejected, Cancelled, Pending };
        public string EmployeeRole()
        {
            return employeeRole;
        }
        public int LeaveBalance()
        {
            return employeeLeaveBalance;
        }
        public void LeaveApplied()
        {
            employeeLeaveStatus = LeaveStatusEmployee.Applied.ToString();
            Console.WriteLine("Successfully applied for leave");
        }
        public void LeaveApprove()
        {
            if(employeeLeaveBalance - 1 >= 0)
            {
                Console.WriteLine("SET TO APPROVE");
                employeeLeaveStatus = LeaveStatusEmployee.Approve.ToString();
                employeeLeaveBalance -= 1;
            }
            else
            {
                Console.WriteLine("Insufficient leave balance:");
                employeeLeaveStatus = LeaveStatusEmployee.Rejected.ToString();
                Console.WriteLine("#1: REJECT");
                Console.WriteLine("#2: PENDING");
                string pattern = @"^[1|2]$";
                while(true)
                {
                    string pass = Console.ReadLine();
                    Match match = Regex.Match(pass, pattern);
                    if(match.Success)
                    {
                        if(Convert.ToInt32(pass) == 1)
                        {
                            LeaveRejected();
                            Console.WriteLine("SET TO REJECTED");
                            break;
                        }
                        if(Convert.ToInt32(pass) == 2)
                        {
                            LeavePending();
                            Console.WriteLine("SET TO PENDING");
                            break;
                        }
                    }
                    Console.WriteLine("Not a valid option");
                    Console.WriteLine("PLEASE SELECT 1 FOR REJECT | 2 FOR PENDING");
                }
            }
        }
        public void LeaveRejected()
        {
            Console.WriteLine("Rejected leave application");
            employeeLeaveStatus = LeaveStatusEmployee.Rejected.ToString();
        }
        public void LeaveCancel()
        {
            Console.WriteLine("Successfully cancelled leave applicaton");
            employeeLeaveStatus = LeaveStatusEmployee.Cancelled.ToString();
        }
        public void LeavePending()
        {
            employeeLeaveStatus = LeaveStatusEmployee.Pending.ToString();
        }
        public string CheckLeaveStatus()
        {
            return employeeLeaveStatus;
        }
        public void UpdateLeaveBalance()
        {
            employeeLeaveBalance = 5;
        }
        public Employee()
        {
            
        }
        public Employee(string employeeFirst, string employeeLast)
        {
            employeeFirstName = employeeFirst;
            employeeLastName = employeeLast;
            employeeEmailAdd = employeeFirst + "." + employeeLast[0] + "@odessainc.com";
            if (employeeNo < (int)EmployeeIDrange.ten)
            {
                employeeId += 'E' + "00" + employeeNo;
                employeeNo += 1;
            }
            else if (employeeNo > (int)EmployeeIDrange.nine && employeeNo < (int)EmployeeIDrange.ninetynine)
            {
                employeeId += 'E' + '0' + employeeNo;
                employeeNo += 1;
            }
            else if (employeeNo > (int)EmployeeIDrange.ninetynine && employeeNo < (int)EmployeeIDrange.thousand)
            {
                employeeId += 'E' + employeeNo;
                employeeNo += 1;
            }
            employeePassword = GetEmployeePassword();
            //Console.WriteLine(employeeEmailAdd);
        }
        //private void generateEmployeeEmailAdd(string employeeFirstName, string employeeLastName)
        //{
        //    Employee setEmail = new Employee(employeeFirstName, employeeLastName);
        //}
        private string GetEmployeePassword()
        {
            employeePassword = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8);
            return employeePassword;
        }
        private string ValidatePassword(string password)
        {
            string pattern = @"^[a-zA-Z][\w]*$";
            Match match = Regex.Match(password, pattern);
            if (match.Success)
                return password;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Password must be in alphanumeric:");
            Console.ResetColor();
            return ValidatePassword(Console.ReadLine());
        }
        public void GetPassword()
        {
            employeePassword = ValidatePassword(Console.ReadLine());
        }
        public void UpdateDetails(ref List<Employee> employeeList, ref SortedDictionary<string, List<string> > managerEmployee)
        {
            Console.WriteLine("Enter first name");
            employeeFirstName = GetNames(Console.ReadLine());
            Console.WriteLine("Enter last name");
            employeeLastName = GetNames(Console.ReadLine());
            AcceptEmployeeDetails(ref employeeList, ref managerEmployee);
        }
        public void ForgetPassword()
        {
            employeePassword = "";
        }
        public void SetPassword()
        {
            employeePassword = ValidatePassword(Console.ReadLine());
            passwordUpdate = true;
        }
        private string GetId(string employeeId)
        {
            string pattern = @"^([E][0-9]{3})$";
            Match match = Regex.Match(employeeId, pattern);
            if (match.Success)
            {
                return employeeId;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Wrong ID Format!!\nPlease Enter Employee ID (e.g E100):");
            Console.ResetColor();
            return GetId(Console.ReadLine());
        }
        public enum NameLength { smallname = 1,maxLimit = 30, capLetterLow = 65, capLetterHigh = 90, smallLetterLow = 97, smallLeterHigh = 122};
        public enum CorrectFormat { formatright = 1};
        private string GetNames(string names) // Take Names and validate
        {
            string pattern = @"^[A-Z][a-z]{1,30}$";
            Match match = Regex.Match(names, pattern);
            if(match.Success)
            {
                return names;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please Enter name. Name length should be less than 30 and Pascal case (e.g: Gourab)");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.ResetColor();
            return GetNames(Console.ReadLine());
        }
        public string AcceptName(string Name)
        {
            return GetNames(Name);
        }
        public string ReturnPassword()
        {
            return employeePassword;
        }
        public enum AgeCondition { daymonthLess = 0, adult = 18};
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
                if (currDD - dd < (int)AgeCondition.daymonthLess)
                {
                    dd = currDD + 30 - dd;
                    currMM -= 1;
                }
                else
                {
                    dd = currDD - dd;
                }
                if (currMM - mm < (int)AgeCondition.daymonthLess)
                {
                    mm = currMM + 12 - mm;
                    currYYYY -= 1;
                }
                else
                {
                    mm = currMM - mm;
                }
                yyyy = currYYYY - yyyy;
                if (yyyy >= (int)AgeCondition.adult)
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
            if (result.Success)
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
        private string GetEmployeeRole()
        {
            while(true)
            {
                Console.WriteLine("**************************************");
                Console.WriteLine("--------Designation Available---------");
                Console.WriteLine("**************************************");
                Console.WriteLine("OPTION #1: ADMIN MANAGER");
                Console.WriteLine("OPTION #2: ADMIN");
                Console.WriteLine("OPTION #3: MANAGER");
                Console.WriteLine("OPTION #4: HR");
                Console.WriteLine("OPTION #5: EMPLOYEE");
                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            return RoleEmployee.AdminManager.ToString();
                        case 2:
                            return RoleEmployee.Admin.ToString();
                        case 3:
                            return RoleEmployee.Manager.ToString();
                        case 4:
                            return RoleEmployee.HumanResource.ToString();
                        case 5:
                            return RoleEmployee.Employee.ToString();
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Option Not Available");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input");
                    Console.ResetColor();
                }
            }
        }
        private string GetEmployeeLevel()
        {
            while (true)
            {
                Console.WriteLine("**************************************");
                Console.WriteLine("-------------Level Available----------");
                Console.WriteLine("**************************************");
                Console.WriteLine("OPTION #1: L7");
                Console.WriteLine("OPTION #2: L6C");
                Console.WriteLine("OPTION #3: L6B");
                Console.WriteLine("OPTION #4: L6A");
                Console.WriteLine("OPTION #5: L5C");
                Console.WriteLine("OPTION #6: L5B");
                Console.WriteLine("OPTION #7: L5A");
                Console.WriteLine("OPTION #8: L4B");
                Console.WriteLine("OPTION #9: L4A");
                Console.WriteLine("OPTION #10: L3B");
                Console.WriteLine("OPTION #11: L3A");
                Console.WriteLine("OPTION #12: L2");
                Console.WriteLine("OPTION #13: L1");
                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            return LevelEmployee.L7.ToString();
                        case 2:
                            return LevelEmployee.L6C.ToString();
                        case 3:
                            return LevelEmployee.L6B.ToString();
                        case 4:
                            return LevelEmployee.L6A.ToString();
                        case 5:
                            return LevelEmployee.L5C.ToString();
                        case 6:
                            return LevelEmployee.L5B.ToString();
                        case 7:
                            return LevelEmployee.L5A.ToString();
                        case 8:
                            return LevelEmployee.L4C.ToString();
                        case 9:
                            return LevelEmployee.L4B.ToString();
                        case 10:
                            return LevelEmployee.L4A.ToString();
                        case 11:
                            return LevelEmployee.L3B.ToString();
                        case 12:
                            return LevelEmployee.L3A.ToString();
                        case 13:
                            return LevelEmployee.L2.ToString();
                        case 14:
                            return LevelEmployee.L1.ToString();
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Option Not Available");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input");
                    Console.ResetColor();
                }
            }
        }
        private string GetDOJ(string employeeDOJ) //DOJ validation
        {
            string[] formats = { "MM/dd/yyyy" };
            DateTime parsedDateTime;
            bool correctDateFormat = DateTime.TryParseExact(employeeDOJ, formats, new CultureInfo("en-US"),
                                           DateTimeStyles.None, out parsedDateTime);
            if (correctDateFormat == true)
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
        private static ConsoleColor ChooseColor()
        {
            while (true)
            {
                try
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
                catch(Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Option\nChooose again");
                    Console.ResetColor();
                }
                
            }
        }
        private string GetAddress(string employeeAddress)
        {
            //string pattern = @"^([A-Z][a-z|0-9]{20,30})$";
            //Match match = Regex.Match(employeeAddress, pattern);
            //if(match.Success)
            //{
            //    return employeeAddress;
            //}
            //Console.ForegroundColor = ConsoleColor.DarkRed;
            //Console.WriteLine("Special characters are not allowed except '-' and minimum length should be 20");
            //Console.ResetColor();
            return employeeAddress;//GetAddress(Console.ReadLine());
        }
        public void AcceptEmployeeDetails(ref List<Employee> employeelist, ref SortedDictionary<string, List<string> > managerEmployee) // Creates New Employee
        {
            //Console.WriteLine("Please Enter Employee ID (e.g E104):");
            //employeeId = GetId(Console.ReadLine());
            //generateEmployeeEmailAdd(employeeFirstName,employeeLastName);
            Console.WriteLine("Please Enter Employee Address1:");
            employeeAddress1 = GetAddress(Console.ReadLine());
            Console.WriteLine("Please Enter Employee Address2:");
            employeeAddress2 = GetAddress(Console.ReadLine());
            Console.WriteLine("Please Enter Employee DOB in MM/DD/YYYY format:");
            employeeAge = GetAge(Console.ReadLine());
            Console.WriteLine("Please Enter Employee Salary:");
            employeeSalary = GetSalary(Console.ReadLine());
            Console.WriteLine("Please Enter Employee Mobile No(e.g +91 8946065442):");
            employeeMobileNo = GetMobileNo(Console.ReadLine());
            Console.WriteLine("Please Enter Employee DOJ in MM/DD/YYYY:");
            employeeDOJ = GetDOJ(Console.ReadLine());
            Console.WriteLine("Select Employee Role:");
            employeeRole = GetEmployeeRole();
            Console.WriteLine("Select Employee Level:");
            employeeLevel = GetEmployeeLevel();
            List<string> managerID = new List<string>();
            foreach (var employee in employeelist)
            {
                if (employee.employeeRole == RoleEmployee.Manager.ToString())
                {
                    managerID.Add(employee.MatchEmployee());
                }
            }
            int Flag = 1;
            while (true)
            {
                if(managerID.Capacity >= 1)
                {
                    Console.WriteLine("List of managerIDs:");
                    foreach (var managers in managerID)
                    {
                        Console.WriteLine(managers);
                    }
                    Console.WriteLine("Please select from above list\nEnter manager ID:");
                    employeeUnderManagerID = GetId(Console.ReadLine());
                    foreach (var managers in managerID)
                    {
                        if(employeeUnderManagerID == managers)
                        {
                            if(!managerEmployee.ContainsKey(employeeUnderManagerID))
                            {
                                managerEmployee.Add(employeeUnderManagerID, new List<string>());
                            }
                            managerEmployee[employeeUnderManagerID].Add(employeeId);    
                            Console.WriteLine("Succesfully mapped with manager:");
                            Flag = 2;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No manager available");
                    Flag = 2;
                }
                if(Flag == 2)
                {
                    break;
                }
            }
            //Console.WriteLine("Employee Under ManagerID:");
            //employeeUnderManagerID = GetId(Console.ReadLine());
            Console.WriteLine("Preferred Location");
            employeePreLoc = GetPreferredLoc();
        }
        public void DisplayEmployeeDetails() // Show Details of employee
        {
            //Console.WriteLine("Please choose background color");
            Console.BackgroundColor = backgroundColor;
            //Console.WriteLine("Please choose font color");
            Console.ForegroundColor = fontColor;
            Console.WriteLine(employeeId + ": " + employeeFirstName + " " + employeeLastName);
            Console.WriteLine(employeeEmailAdd);
            //Console.WriteLine(employeePassword);
            Console.WriteLine(employeeAddress1);
            Console.WriteLine(employeeAge);
            Console.WriteLine(employeeLevel);
            Console.WriteLine(employeeRole);
            Console.WriteLine("Salary INR " + employeeSalary);
            Console.WriteLine(employeeMobileNo);
            Console.WriteLine("Joined: " + employeeDOJ);
            Console.ResetColor();
        }
        public string SearchEmployee(string empID)
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
            fontColor = ChooseColor();
            Console.WriteLine("Please choose background color");
            backgroundColor = ChooseColor();
        }
    }
}
