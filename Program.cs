using System;
using System.IO;
using System.Xml.Serialization;

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


            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1: Read from file.");
                Console.WriteLine("2: Write to file.");
                Console.WriteLine("3: Create Xml Record");
                Console.WriteLine("4: Read from Xml Record");
                Console.WriteLine("0: Exit.");

                string ? choice = Console.ReadLine(); // the ? makes it nullable

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

                        case "3":
                            Person p = new Person("James", 12.34, 55.5);

                            if (!File.Exists(path))
                            {
                                File.WriteAllText(path, p.SerializeAsXml());
                            }
                            else
                            {
                                File.AppendAllText(path, p.SerializeAsXml());
                            }
                           
                            Console.WriteLine(p.SerializeAsXml());
                            break;

                        case "4":
                            Person q = DeserializeXML();
                            Console.WriteLine(q.name);
                            Console.WriteLine(q.height);
                            Console.WriteLine(q.weight);
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

            Console.WriteLine("Application closing...");

        }

        private static Person DeserializeXML()
        {   
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            string path = @"./TextFile.txt";
            Person P = new Person();

            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist.");
                return null;
            }
            else 
            {
                using StreamReader reader = new StreamReader(path);
                var record = (Person)serializer.Deserialize(reader);

                if (record is null) 
                {
                    throw new InvalidDataException();
                    return null;
                }
                else
                {
                    P = record;
                }
            }

            return P; 
        }
    }
}
