using System;
using System.IO;

namespace FileInteraction
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Application Running...");

            
            string[] text = {"Hello Everyone!", "Second object in array", "hello world again"};
            string[] secondText = {"This is the appended text in the secondText array"};
            string path = @"./TextFile.txt";

            Console.WriteLine("Please select an option:");
            Console.WriteLine("1: Read from file.");
            Console.WriteLine("2: Write to file.");
            Console.WriteLine("0: Exit.");

            string choice = Console.ReadLine();

            bool loop = true;

            while (loop)
            {
                switch(choice)
                    {
                        case "1": // if (choice == "1")
                            Console.WriteLine("Reading from file...");

                            if (!File.Exists(path))
                            {
                                Console.WriteLine("File does not exist.");
                            }
                            else 
                            {
                                string[] readText = File.ReadAllLines(path); // Read all lines from the file and store in string array

                                foreach (string s in readText) // loop through the string array
                                {
                                    Console.WriteLine(s);
                                }
                            }
                            break;

                        case "2":
                            Console.WriteLine("Writing to file...");
                            if (!File.Exists(path))
                            {
                                File.WriteAllLines(path, text);
                            }
                            else
                            {
                                File.AppendAllLines(path, secondText);
                            }
                            break;

                        case "0":
                            loop = false;
                            Console.WriteLine("Exiting...");
                            break;
                            
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
            }

            Console.WriteLine("Application Complete.");

        }
    }
}
