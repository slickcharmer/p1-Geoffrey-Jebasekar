using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    internal class Menu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Trainer Menu");
            // Console.WriteLine("[3] Password - " + trl.password);
            Console.WriteLine("[3] Get all trainer details");
            Console.WriteLine("[2] Trainer Login");
            Console.WriteLine("[1] Trainer Signup");
            Console.WriteLine("[0] Exit");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch(userInput) 
            {
                case "0":
                    return "Exit";
                case "1":
                    return "Signup";
                case "2":
                    return "Login";
                case "3":
                    return "GetAllTrainers";
                default:
                    Console.WriteLine("Please enter a valid response");
                    return "Menu";
            }

        }
    }
}
