﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    public class EditDetails : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Press 0 to return to Go back");
            Console.WriteLine("Press 1 to edit Education");
            Console.WriteLine("Press 2 to edit Experience");
            Console.WriteLine("Press 3 to edit Skills");


        }



        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "UserDetails";
                case "1":

                    return "EditEducation";



                case "2":
                    return "EditExperience";


                case "3":
                    return "EditSkills";

                default:
                    Console.WriteLine("Enter a valid response");
                    return "EditDetails";


            }
        }

        //public string EditEducation()
        //   {
        //       return "null";
        //   }

        //   public string EditExperience()
        //   {
        //       return "";
        //   }
        //   public string EditSkills()
        //   {
        //       return "";
        //   }
    }
}

