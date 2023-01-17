// See https://aka.ms/new-console-template for more information
using UI_Console;
using Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Trainer
{
    class program : SqlRepo
    {
        static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;" +
            "Password=Geoffrey2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static void Main(string[] args)
        {
            List<Trainer_Signup> GetDetails = new List<Trainer_Signup>();
            
            SqlRepo repo = new SqlRepo(conStr);
            Signup signup = new Signup();
            //int flag = 0;
            IMenu menu = new Menu();
            
            bool repeat = true;
            while(repeat)
            {
                Console.Clear();
                menu.Display();
                string userInput = menu.UserChoice();
                switch(userInput)
                {
                    case "Exit":
                        Console.WriteLine("Thanks for visiting--------Come again");
                        repeat = false;
                        break;
                    case "GetAllTrainers":
                        var trainerdet = repo.GetAllTrainers();
                        foreach(var trainer in trainerdet) 
                        {
                            //var r = trainerdet.GetTrainer();
                            Console.WriteLine(trainer.GetTrainer());
                            Console.ReadLine();
                        }
                        break;
                        
                        
                    case "Signup":
                        menu = new Signup();
                        break;
                    case "Login":
                        //repeat = false;
                        //flag = 1;
                        menu = new Login();
                        break;
                    case "UserDetails":
                        menu = new UserDetails();
                        break;
                    //case "EditDetails":
                    //    menu = new EditDetails();
                    //    break;
                    case "Delete":

                    case "Education":
                        menu = new Education();
                        break;
                    case "Experience":
                        menu = new Experience();
                        break;
                    case "Skills":
                        menu = new Skills();
                        break;
                    case "Menu":
                        menu = new Menu();
                        break;
                       

                }
                
            }
            /*IDetails details = new Login();
            if (flag==1)
            {
                repeat = true;
                while(repeat)
                {
                    string a = details.Display();
                    switch(a)
                    {
                        case "UserDetails":
                            break;
                        case "Signup":
                            menu=new Signup();
                            break;
                    }
                }


            }*/
            
        }
    }
}
