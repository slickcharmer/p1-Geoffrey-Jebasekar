using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    public class Skills : IMenu
    {
        int i = 0, j = 0;
        static Trainer_Skills skills = new Trainer_Skills();
        //static Login login = new Login();
        //readonly string val = login.PassEmail();
        static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;Password=Geoffrey2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        IRepo repo = new SqlRepo(conStr);
        //IRepo repo = new SqlRepo();
        string val = Login.PassEmail();
        public void Display()
        {
            Console.WriteLine("Hey ---------------------- " + val);
            skills.emailid = val;
            Console.WriteLine("[3] Profeceincy in skill - " + skills.profeciencyInSkill);
            Console.WriteLine("[2] Skill name - " + skills.skill);
            
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch(userInput)
            {
                case "0":
                    return "AddDetails";
                case "1":
                   
                        try
                        {
                            Console.WriteLine("Adding Trainer Skill");
                        

                            repo.AddSk(skills);
                            //repo1.AddL(login);
                            Console.WriteLine("Skills added successfully");
                            Console.WriteLine("Redirecting you to add details menu");
                            return "AddDetails";
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine("Sorry-----Try Adding Again");
                        Console.WriteLine(ex.Message);
                            return "Skills";
                        }
                    
                   


                case "2":
                    i++;
                    Console.WriteLine("Enter your Skill name");
                    skills.skill = Console.ReadLine();
                    return "Skills";
                case "3":
                    j++;
                    Console.WriteLine("Enter your profeciency in that skill");
                    Console.WriteLine("Enter any value between 1 and 5");

                    skills.profeciencyInSkill = Convert.ToInt32(Console.ReadLine());
                    if(skills.profeciencyInSkill>=1 && skills.profeciencyInSkill<=5)
                    {
                        //Console.WriteLine("Congratulations-------You have added all the details");
                        //Console.WriteLine("Redirecting you to Trainer Menu");
                        return "Skills";
                    }
                    else
                    {
                        Console.WriteLine("Enter any value between 1 and 5");
                        return "Skills";
                    }
                //return "skills";
                default:
                    Console.WriteLine("Enter a valid response");
                    return "skills";

            }
            //throw new NotImplementedException();
        }
    }
}
