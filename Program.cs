using System;

namespace Koisk
{
    // The class which was given to write to the file 
    public class BackgroundOperation
    {
        public async Task WriteToFileAsync(string message)
        {
            await Task.Delay(3000);
            await File.WriteAllTextAsync("tmp.txt", message);
        }
    }

    class Program
    {
        public static async Task Main(string[] args)
        {
            //Creating object of BackgroundOperation class
            BackgroundOperation bgOperation = new BackgroundOperation();

            // Writing a welcome message
            Console.WriteLine(" ---------------------------------");
            Console.WriteLine("| Welcome to Kiosk - File Writer |");
            Console.WriteLine(" ---------------------------------");


            while (true) // To repeat the process again and again 
            {
                // The Kiosk system will show the following menu to the user:
                Console.WriteLine("Select an option from below");
                Console.WriteLine("1. Write \"Hello World\"");
                Console.WriteLine("2. Write Current Date");
                Console.WriteLine("3. Write OS Version");
                Console.WriteLine("4. Exit");
                Console.WriteLine();

                // To better handle the exception I have used string here instead of int
                string? option = Console.ReadLine();
                try
                {
                    // To exit the loop
                    if (option == "4")
                    {
                        Console.WriteLine("Exiting from the application");
                        break;
                    }

                    // If the user enters '1', '2' or '3' it will write it respectively to the file. 
                    switch (option) // You can also do this using if and else..
                    {
                        case "1":
                            Console.WriteLine("Writing to file please wait...");
                            await bgOperation.WriteToFileAsync("\"Hello World\"");
                            Console.WriteLine("successful...\n");
                            break;

                        case "2":
                            Console.WriteLine("Writing to file please wait...");
                            await bgOperation.WriteToFileAsync(DateTime.Now.ToString("dd/MM/yyyy")); // Writing only date
                            Console.WriteLine("successful...\n");
                            break;

                        case "3":
                            Console.WriteLine("Writing to file please wait...");
                            await bgOperation.WriteToFileAsync(Environment.OSVersion.VersionString);
                            Console.WriteLine("successful...\n");
                            break;

                        default:
                            Console.WriteLine("Invalid input please write the correct input from the option\n");
                            break;
                    }
                }
                // To catch exceptions
                catch (IOException)
                {
                    Console.WriteLine("Some exception occured");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }



            }
        }


    }
}

