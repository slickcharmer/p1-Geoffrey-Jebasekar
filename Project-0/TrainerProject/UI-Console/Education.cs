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
        //Education edu = new Education();

        //Login login = new Login();
        //public Education(string val)
        //{
        //    email=val;
        //}
        static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;Password=Geoffrey2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        IRepo repo = new SqlRepo(conStr);
        string val = Login.PassEmail();
        
        //public string email;
        //IRepo repo = new SqlRepo();
        public void Display()
        {
            Console.WriteLine("Trainer's Education Details");
            //Console.WriteLine("[9] City - " + trs.city);
            Console.WriteLine("Hey ------------------ " + val);
            education.emailid = val;
            Console.WriteLine("[7] Percentage - " + education.percentage);
            Console.WriteLine("[6] End Year - " + education.endYear);
            Console.WriteLine("[5] Start Year - " + education.startYear);
            Console.WriteLine("[4] Stream - " + education.stream);
            Console.WriteLine("[3] Institute Name - " + education.instituteName);
            Console.WriteLine("[2] Education Type - " + education.educationType);
            
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
                            Console.WriteLine("Adding Trainer Eduction");
                        

                            repo.AddE(education);
                            //repo1.AddL(login);
                            Console.WriteLine("Successfully added Trainer-------Login to fill further details");
                            return "AddDetails";
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine("Sorry-----Try Adding Again");
                        Console.WriteLine(ex.Message);
                            
                        }
                        return "Education";
                    
                    

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
                    Console.WriteLine("Enter your Stream");
                    education.stream = Console.ReadLine();
                    return "Education";
                case "5":
                    k++;
                    Console.WriteLine("Enter your Start Year");
                    education.startYear = Console.ReadLine();
                    return "Education";
                case "6":
                    l++;
                    Console.WriteLine("Enter your End Year");
                    education.endYear = Console.ReadLine();
                    return "Education";
                case "7":
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
