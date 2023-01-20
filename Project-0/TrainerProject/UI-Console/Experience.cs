using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    public class Experience : IMenu
    {
        int i = 0, j = 0, k = 0, l = 0, m = 0, n = 0, o = 0;
        static Trainer_Companies experience = new Trainer_Companies();
        //static Login login = new Login();
        //string val = login.PassEmail();
        static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;Password=Geoffrey2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        IRepo repo = new SqlRepo(conStr);
        //IRepo repo = new SqlRepo();
        string val = Login.PassEmail();
        public void Display()
        {
            Console.WriteLine("Trainer's Experience Details");
            Console.WriteLine("Hey ------------------- " + val);
            experience.emailid = val;
            //Console.WriteLine("[9] City - " + trs.city);
            Console.WriteLine("[8] End Year - " + experience.endYear);
            Console.WriteLine("[7] Start Year - " + experience.startYear);
            Console.WriteLine("[6] Location - " + experience.location);
            Console.WriteLine("[5] Employement type - " + experience.employementType);
            Console.WriteLine("[4] Industry - " + experience.industry);
            Console.WriteLine("[3] Title - " + experience.title);
            Console.WriteLine("[2] Company name - " + experience.companyName);
            
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "AddDetails";
                case "1":
                   
                    
                        try
                        {
                            Console.WriteLine("Adding Trainer Experience");
                        

                            repo.AddC(experience);
                            //repo1.AddL(login);
                            Console.WriteLine("Successfully added Trainer-------Redirecting you to Add Details page");
                            return "AddDetails";
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine("Sorry-----Try Adding Again");
                        Console.WriteLine(ex.Message);
                            return "Experience";
                        }
                    
                   

                case "2":
                    i++;
                    Console.WriteLine("Enter your Company name");
                    experience.companyName = Console.ReadLine();
                    return "Experience";
                case "3":
                    j++;
                    Console.WriteLine("Enter your Title");
                    experience.title = Console.ReadLine();
                    return "Experience";
                case "4":
                    k++;
                    Console.WriteLine("Enter your industry");
                    experience.industry = Console.ReadLine();
                    return "Experience";
                case "5":
                    l++;
                    Console.WriteLine("Enter your Employement Type");
                    experience.employementType = Console.ReadLine();
                    return "Experience";
                case "6":
                    m++;
                    Console.WriteLine("Enter your Location");
                    experience.location = Console.ReadLine();
                    return "Experience";
                case "7":
                    n++;
                    Console.WriteLine("Enter your Start Year");
                    experience.startYear = Console.ReadLine();
                    return "Experience";
                case "8":
                    o++;
                    Console.WriteLine("Enter your End Year");
                    experience.endYear = Console.ReadLine();
                    return "Experience";
                default:
                    Console.WriteLine("Enter a valid response");
                    return "Experience";


            }
            //throw new NotImplementedException();
        }
    }
}
