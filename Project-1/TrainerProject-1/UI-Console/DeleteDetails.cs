using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    public class DeleteDetails : IMenu
    {
        public DeleteDetails() { }

        public void Display()
        {
            Console.WriteLine("Press 0 to Go back");
            Console.WriteLine("Press 1 to delete a Education");
            Console.WriteLine("Press 2 to delete a Experience");
            Console.WriteLine("Press 3 to delete a Skill ");
            Console.WriteLine("Press 4 to delete your Account ");

        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch(userInput) 
            {
               case "0":
                    return "UserDetails";
               case "1":
                    return "DeleteEducation";
                case "2":
                    return "DeleteExperience";
               case "3":
                    return "DeleteSkills";
               case "4":
                    return "DeleteAccount";
                default:
                    Console.WriteLine("Enter a valid response");
                    return "DeleteDetails";

            }

            
        }

        //public void DeleteEducation()
        //{
           
        //}
        //public void DeleteExperience()
        //{
            
        //}
        //public void DeleteSkills()
        //{
            
        //}
        //public void DeleteAccount()
        //{

        //}
    }
}
