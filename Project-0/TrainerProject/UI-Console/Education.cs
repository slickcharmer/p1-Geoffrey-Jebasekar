using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    public class Education : IMenu
    {
        int i = 0,j=0,k=0,l=0,m=0;
        public Education() { }
        static Trainer_Education education = new Trainer_Education();
        IRepo repo = new SqlRepo();
        public void Display()
        {
            Console.WriteLine("Trainer's Education Details");
            //Console.WriteLine("[9] City - " + trs.city);
            Console.WriteLine("[6] Percentage - " + education.percentage);
            Console.WriteLine("[5] End Year - " + education.endYear);
            Console.WriteLine("[4] Start Year - " + education.startYear);
            Console.WriteLine("[3] Institute Name - " + education.instituteName);
            Console.WriteLine("[2] Education Type - " + education.educationType);
            Console.WriteLine("Hey " + education.emailid);
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");

        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch(userInput)
            {
                case "0":
                    return "Login";
                case "1":
                    if (i>=1 && j>=1 && k>=1 && l>=1 && m>=1)
                    {
                        try
                        {
                            Console.WriteLine("Adding Trainer Eduction");

                            repo.AddE(education);
                            //repo1.AddL(login);
                            Console.WriteLine("Successfully added Trainer-------Login to fill further details");
                            return "Experience";
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine("Sorry-----Try Adding Again");
                            
                        }
                        return "Education";
                    }
                    else
                    {
                        Console.WriteLine("Sorry-----Try Adding Again");
                        return "Education";
                    }

                case "2":
                    i++;
                    Console.WriteLine("Enter your Education type");
                    education.educationType = Console.ReadLine();
                    return "Education";
                case "3":
                    j++;
                    Console.WriteLine("Enter your Institute name");
                    education.instituteName = Console.ReadLine();
                    return "Education";
                case "4":
                    k++;
                    Console.WriteLine("Enter your Start Year");
                    education.startYear = Console.ReadLine();
                    return "Education";
                case "5":
                    l++;
                    Console.WriteLine("Enter your End Year");
                    education.endYear = Console.ReadLine();
                    return "Education";
                case "6":
                    m++;
                    Console.WriteLine("Enter your Percentage");
                    education.percentage = Console.ReadLine();
                    return "Education";
                default:
                    Console.WriteLine("Enter a valid response");
                    return "Education";
                        

            }
            //throw new NotImplementedException();
        }
    }
}
