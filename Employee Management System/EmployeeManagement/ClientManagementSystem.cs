using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLeaveManagement;

namespace EmployeeManagement
{
    class ClientManagementSystem
    {
        public enum CheckClient { clientPresent = 1, clientAbsent = 2 };
        public void ClientMangement()
        {
            List<ClientInfo> ClientList = new List<ClientInfo>();
            while (true)
            {
                Console.WriteLine("**************************************");
                Console.WriteLine("------------------Menu----------------");
                Console.WriteLine("**************************************");
                Console.WriteLine("OPTION #1: ADD CLIENT DETAILS");
                Console.WriteLine("OPTION #2: VIEW CLIENT DETAILS");
                Console.WriteLine("OPTION #3: CHANGE SCREEN SETTINGS");
                Console.WriteLine("OPTION #4: RETURN TO MAIN MENU");
                Console.WriteLine("OPTION #5: EXIT");
                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("How many client details you want to add");
                            int numberOfClient = Convert.ToInt32(Console.ReadLine());
                            for (int i = 1; i <= numberOfClient; i++)
                            {
                                ClientInfo newClient = new ClientInfo();

                                ClientList.Add(newClient);
                            }
                            break;
                        case 2:
                            if (ClientList.Capacity >= 1)
                            {
                                int clientstatus = 0;
                                Console.WriteLine("Enter client name");
                                string searchClient = Console.ReadLine();
                                foreach (var client in ClientList)
                                {
                                    if (searchClient == client.SearchDetails())
                                    {
                                        client.DisplayInfo();
                                        clientstatus = 1;
                                    }
                                    if (clientstatus == (int)CheckClient.clientPresent)
                                    {
                                        break;
                                    }
                                }
                                if (clientstatus == (int)CheckClient.clientAbsent)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Client does not exist");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("No client details available");
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
