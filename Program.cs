using System;
using System.IO;

namespace A1_Ticketing_System
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string choice;

            do
            {
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // convert string to array
                            string[] arr = line.Split(',');
                            // display array data
                            Console.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching \n {0}, {1}, {2}, {3}, {4}, {5}, {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                        }
                        sr.Close();
                        
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                } 
                else if (choice == "2")
                {
                    // create file from data
                    StreamWriter sw = new StreamWriter(file);
                    for (int i = 0; i < 7; i++)
                    {
                        Console.Write("Enter a TicketID: ");
                        int resp = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter a summary: ");
                        string summary = Console.ReadLine();
                        Console.Write("Enter ticket status: ");
                        string status = Console.ReadLine();
                        Console.Write("Enter ticket priority: ");
                        string priority = Console.ReadLine();
                        Console.Write("Enter the submitter: ");
                        string submitter = Console.ReadLine();
                        Console.Write("Enter assigned person: ");
                        string assigned = Console.ReadLine();
                        string watching = "";
                        string watching2 = "";
                        
                        for(int j = 0; j < 7; j++)
                        {
                            Console.Write("Enter person watching: ");
                            watching = Console.ReadLine();
                            Console.Write("Enter another person watching? (Y/N): ");
                            string watchResp = Console.ReadLine().ToUpper();
                            if (watchResp == "N")
                            {watching2 += "|" + watching; break;}
                            else {watching2 += "|" + watching; }
                        }
                        
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", resp, summary, status, priority, submitter, assigned, watching2);
                        Console.WriteLine("Enter another ticket? (Y/N): ");
                        string rerun = Console.ReadLine().ToUpper();
                        if (rerun != "Y") { break; }
                    }
                    sw.Close();
                }
            } while (choice == "1" || choice == "2"); 
        }
    }
}
