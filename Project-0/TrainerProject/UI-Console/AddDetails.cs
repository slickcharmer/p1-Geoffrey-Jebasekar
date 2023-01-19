using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    public class AddDetails : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Press 0 to return to Go back");
            Console.WriteLine("Press 1 to Add Education");
            Console.WriteLine("press 2 to Add Experience");
            Console.WriteLine("Press 3 to Add Skills");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "UserDetails";

                case "1":
                    return "Education";
                case "2":
                    return "Experience";
                case "3":
                    return "Skills";
                //case"4":
                //return "Menu";
                default:
                    Console.WriteLine("Invalid response");
                    Console.ReadLine();
                    return "AddDetails";



            }

        }
    }
}
