using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Data.SqlClient;

namespace UI_Console
{
    public class EditEducation : IMenu
    {
        //public List<Trainer_Education> education = new List<Trainer_Education>();
        static string email = Login.PassEmail();
        
        static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;Password=Geoffrey2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        IRepo repo1 = new SqlRepo(conStr,email);
        Trainer_Education edu = new Trainer_Education();
        
       
        string instituteName;
        public EditEducation(string name) 
        {
            instituteName = name;
        }
        
        

        public void Display()
        {
           edu=repo1.GetSpecificTrainersEducation(email, instituteName);    
            Console.WriteLine("Hey---------------------"+email);

            Console.WriteLine("[7] Percentage - " + edu.percentage);
            Console.WriteLine("[6] End Year - " + edu.endYear);
            Console.WriteLine("[5] Start Year - " + edu.startYear);
            Console.WriteLine("[4] Stream - " + edu.stream);
            Console.WriteLine("[3] Institute Name - " + edu.instituteName);
            Console.WriteLine("[2] Education Type - " + edu.educationType);
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");

        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            string query = $"update Education set educationType='{edu.educationType}',instituteName='{edu.instituteName}',stream='{edu.stream}',startYear='{edu.startYear}',endYear='{edu.endYear}',percentage='{edu.percentage}' where emailid='{email}' and instituteName='{instituteName}' ";
            using SqlConnection connection = new SqlConnection(conStr);
            using SqlCommand command = new SqlCommand(query,connection);
            switch (userInput)
            {
                case "0":
                    return "EditDetails";
                case "1":

                   
                  
                        Console.WriteLine("Editing Trainer Eduction");

                        int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        //repo1.AddL(login);
                        Console.WriteLine($"{n} rows affected");
                        return "EditDetails";
                    }


                    else
                    {
                        Console.WriteLine("Sorry-----Try Editing Again");
                        //Console.WriteLine(ex.Message);

                    }
                    return "EditEducation";



                case "2":
                    
                    Console.WriteLine("Enter your Education type");
                    edu.educationType = Console.ReadLine();
                    return "EditEducation";
                case "3":
                    
                    Console.WriteLine("Enter your Institute name");
                    edu.instituteName = Console.ReadLine();
                    return "EditEducation";
                case "4":
                    
                    Console.WriteLine("Enter your Stream");
                    edu.stream = Console.ReadLine();
                    return "EditEducation";
                case "5":
                    Console.WriteLine("Enter your Start Year");
                    edu.startYear = Console.ReadLine();
                    return "EditEducation";
                case "6":
                    Console.WriteLine("Enter your End Year");
                    edu.endYear = Console.ReadLine();
                    return "EditEducation";
                case "7":
                    Console.WriteLine("Enter your Percentage");
                    edu.percentage = Console.ReadLine();
                    return "EditEducation";
                default:    
                    Console.WriteLine("Enter a valid response");
                    return "EditEducation";


            }
        }
    }
}
