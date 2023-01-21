using Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    public class ViewDetails : IMenu
    {
        Trainer_Details trainer = new Trainer_Details();
        string email;

        static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;Password=Geoffrey2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //SqlRepo repo = new SqlRepo();
        IRepo repo = new SqlRepo(conStr);
        public void Display()
        {
            
            Console.WriteLine("Press 0 to go back");
            Console.WriteLine("Press 1 to view details");
        }

        public string UserChoice()
        {
            string userInput=Console.ReadLine();
            switch(userInput) 
            {
                case "0":
                    return "UserDetails";
                case "1":
                    email = Login.PassEmail();
                    
                    var viewDetails = repo.ViewDetailsDisconnected(email);
                    foreach(var details in viewDetails)
                    {

                        Console.WriteLine(details.TrainerDetails());
                        
                    }
                    Console.WriteLine("Press any key to go to User Details menu");
                    Console.ReadLine();
                    return "UserDetails";
                default:
                    Console.WriteLine("Please enter a valid response");
                    return "ViewDetails";



            }
        }
    }
}

