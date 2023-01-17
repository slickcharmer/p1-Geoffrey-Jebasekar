using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    public class Login : IMenu    
    {
        public Login() { }
        public string emailid;
        IRepo repo = new SqlRepo(); 
        public void Display()
        {
            Console.WriteLine("Login page");
            Console.WriteLine("[1] Press 1 to proceed to login");
            Console.WriteLine("[0] Press 0 to go back");
            

            
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch(userInput)
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
                        return "Education";

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
    }
}
