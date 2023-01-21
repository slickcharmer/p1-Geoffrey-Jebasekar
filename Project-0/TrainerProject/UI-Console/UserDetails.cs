using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    public class UserDetails : IMenu
    {
        public UserDetails() { }
        bool repeat = true;
        
        

        IMenu menu;
        public void Display()
        {
            Console.WriteLine("Press 0 to Logout");
            Console.WriteLine("Press 1 to Add details");
            Console.WriteLine("press 2 to Edit details");
            Console.WriteLine("Press 3 to Delete details");
            Console.WriteLine("Press 4 to View Details");
            //Console.WriteLine("Press 4 to return to Menu"); 
          
            
        }
        
        public string UserChoice()
        {

        string userInput = Console.ReadLine();

        switch (userInput)
        {
                case "0":
                    return "Menu";

                case "1":
                    return "AddDetails";
                case "2":
                    return "EditDetails";
                case "3":
                    return "DeleteDetails";
                case "4":
                    return "ViewDetails";
                default:
                    Console.WriteLine("Invalid response");
                    Console.ReadLine();
                    return "UserDetails";



        }
            
            
           
        }
    }
}
