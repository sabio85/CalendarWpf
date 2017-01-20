using Calendar.BL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarConsole
{
    class Program
    {
        private const string Greeting = "Please enter Date value in the format 'dd.MM.yyyy', for example '30.10.2016'";

        static void Main(string[] args)
        {
            while (true) {
                Console.WriteLine(Greeting);
                var dateString = Console.ReadLine();

                var dateTimeOperations = new DateTimeOperations();

                var validationResult = dateTimeOperations.ValidateDate(dateString);

                //Check validation result for entered Date string
                if (!validationResult.Success)
                {
                    Console.WriteLine(validationResult.Message);

                    FinalizeConsole();

                    continue;
                }

                var resultString = dateTimeOperations.Stringify(validationResult.Result);

                Console.WriteLine(resultString);
                FinalizeConsole();
            }
        }
               

        private static void FinalizeConsole()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to try again...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
