using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using Data;
using Models;
using BusinessLogic;
using System.Text.RegularExpressions;
namespace UI_Console
{
    public class Signup : IMenu

    {
        
        static Trainer_Signup signup = new Trainer_Signup();
        static Trainer_Login login = new Trainer_Login();
        
        static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;Password=Geoffrey2001;" +
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";
        //IRepo repo = new SqlRepo(conStr);
        IEFRepo repo = new TrainerEFRepo();
        public bool Phone(string phone)
        {
            Regex r = new Regex(@"^[6-9]\d{9}$");


            
            
                if (r.IsMatch(phone))
                {

                return true;

                }
                else
                {
                   
                    return false;
                }
                
            
           
        }

        public bool Password(string pass)
        {
            Regex r = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            if (r.IsMatch(pass))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool Email(string email)
        {
            Regex r = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if(r.IsMatch(email))
            {
                return true;

            }
            else
            {
                return false;
            }
        }



        public void Display()
        {
            Console.WriteLine("Trainer information");

            Console.WriteLine("[8] City - " + signup.city);
            Console.WriteLine("[7] age - " + signup.age);
            Console.WriteLine("[6] Phone - " + signup.phoneno);
            Console.WriteLine("[5] Password - " + signup.password);
            Console.WriteLine("[4] Email - " + signup.emailId);
            Console.WriteLine("[3] Last Name - " + signup.lastname);
            Console.WriteLine("[2] First Name - " + signup.firstname);
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");
        }

        public string UserChoice()
        {
            
            string userInput = Console.ReadLine();
            switch(userInput)
            {
                case "0":
                    return "Menu";

                case "1":
                   
                    
                        try
                        {
                           Console.WriteLine("Adding Trainer");

                          repo.Add(signup);
                          repo.AddL(login);
                           Console.WriteLine("Successfully added Trainer-------Login to fill further details");
                          return "Login";
                        }

                       catch(Exception ex)
                        {
                         Console.WriteLine("Sorry-----Try Adding Again");
                        Console.WriteLine(ex.Message);
                            return "Signup";
                        }
                    
                  

                case "2":
                    
                    Console.WriteLine("Enter your First name");
                    string a= Console.ReadLine();
                    if(a!=null)
                    {
                        signup.firstname = a;

                    }
                     
                    return "Signup";
                case "3":
                    
                    Console.WriteLine("Enter your Last name");
                    string b = Console.ReadLine();
                    if (b != null)
                    {
                        signup.lastname = b;

                    }
                    return "Signup";
                case "4":
                    
                    Console.WriteLine("Enter your Email id");
                    string c = Console.ReadLine();
                    if (c != null)
                    {
                        bool mail = Email(c);
                        if(mail)
                        {
                            signup.emailId = c;
                            login.emailId = signup.emailId;
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid email id");
                        }
                        
                       

                    }
                    
                   

                    return "Signup";
                case "5":
                   
                    Console.WriteLine("Enter your Password");
                    string d = Console.ReadLine();
                    if (d != null)
                    {
                        bool pass = Password(d);
                        if (pass)
                        {
                            signup.password = d;
                            login.password = signup.password;
                        }   
                        else
                        {
                            Console.WriteLine("Please add a password which contains atleast 8 digits and one number,uppercase and lowecase letters");
                        }

                    }
                    
                    
                    return "Signup";
                case "6":
                    
                    Console.WriteLine("Enter your Phone number");
                    string e = Console.ReadLine();
                    
                    if(e!=null)
                    {
                        bool no = Phone(e);
                        if(no)
                        {
                            signup.phoneno = e;
                        }
                        else
                        {
                            Console.WriteLine("Please add a mobile no which has only 10 digits and no symbols or extensions in between");
                        }
                    }
                    
                    return "Signup";
                case "7":
                    
                    Console.WriteLine("Enter your Age");
                    int f = Convert.ToInt32(Console.ReadLine());
                    if (f != null)
                    {
                        if(f>=21)
                        {
                            signup.age = f;
                        }
                        else 
                        {
                            Console.WriteLine("Trainers age should be greater than or equal to 21");
                        }
                        
                        

                    }
                   
                    return "Signup";
                case "8":
                    Console.WriteLine("Enter your City");
                    string g = Console.ReadLine();
                    if (g != null)
                    {
                        signup.city = g;
                        

                    }
                    
                    return "Signup";

                default:
                    Console.WriteLine("Enter a valid response");
                    Console.WriteLine("Press any key to continue adding");
                    Console.ReadKey();
                    return "Signup";
            }

           
            
        }
    }
}
