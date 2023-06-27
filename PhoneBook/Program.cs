using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Library;

namespace WseiProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBookOperator = new PhoneBookOperator();

            Console.WriteLine("Welcome to console phone book");
            Console.WriteLine("Type in 'bye' to exit");


            string userInput = "";
            do
            {
                Console.WriteLine();
                Console.WriteLine("*************");
                Console.WriteLine("Options:");
                Console.WriteLine("1: Add contact");
                Console.WriteLine("2: Remove contact");
                Console.WriteLine("3: Edit contact");
                Console.WriteLine("4: Display All Contacts");
                Console.WriteLine("5: Search honeNumber");
                Console.WriteLine("6: Search Name");
                Console.WriteLine("7: Display contact");
                Console.WriteLine("Insert your option or type 'bye' to exit:");

                userInput = Console.ReadLine();
                if (userInput == "bye")
                {
                    return;
                }

                object input;



                if (Enum.TryParse(typeof(PhoneBookOperation), userInput, true, out input))
                {
                    PhoneBookOperation operation = (PhoneBookOperation) input;
                    phoneBookOperator.Process(operation);
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                }
                Console.WriteLine("*************");
                Console.WriteLine();
            } while (true);
        }
    }

}