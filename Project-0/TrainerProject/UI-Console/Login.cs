using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Trainer;

namespace UI_Console
{
    public class Login : IMenu    
    {
        //public Login() 
        //{
        //    return login;
        //}
        public static string emailid;
        static Trainer_Education education = new Trainer_Education();
        //IRepo repo = new SqlRepo(); 
        //Login login= new Login();
        //int flag = 0;
        static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;" +
            "Password=Geoffrey2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";
        IRepo repo = new SqlRepo(conStr);
        

       
        public void Display()
        {
            Console.WriteLine("Login page");
            Console.WriteLine("[1] Press 1 to proceed to login");
            Console.WriteLine("[0] Press 0 to go back");
            

            
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case "0":
                    return "Signup";
                case "1":
                    Console.WriteLine("Enter your Email id");
                    emailid = Console.ReadLine();
                    int a = repo.IsValidLogin(emailid);
                    if(a==0) 
                    {
                        Console.WriteLine("Emaild and password doesnt match-------Try logging in again");
                        return "Login";
                        
                    }
                    else if(a==1)
                    {
                        Console.WriteLine("--------Logged in successfully----------");
                        //flag = 1;
                        return "UserDetails";

                    }
                    else
                    {
                        Console.WriteLine("Create an account to login");
                        return "Signup";

                    }
                default:
                    Console.WriteLine("Enter a valid response");
                    Console.ReadLine();
                    return "Login";
                    
            }
            
            
        }
        public static string PassEmail()
        {
            return emailid ;
        }
        //Education education = new Education(emailid);
        //program prog = new program(emailid);
    }
}
