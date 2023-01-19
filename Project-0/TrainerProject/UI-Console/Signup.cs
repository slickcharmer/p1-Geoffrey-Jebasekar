using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;
namespace UI_Console
{
    public class Signup : IMenu

    {
        int i = 0,j=0,k=0,l=0,m=0,n=0,o=0;
        static Trainer_Signup signup = new Trainer_Signup();
        static Trainer_Login login = new Trainer_Login();
        static Trainer_Education education = new Trainer_Education();
        static Trainer_Companies experience = new Trainer_Companies();
        static Trainer_Skills skills = new Trainer_Skills();
        static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;Password=Geoffrey2001;" +
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";
        IRepo repo = new SqlRepo(conStr);
        //IRepo repo1 = new SqlRepo();

        
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
                    //repo.Add(signup);
                    //repo.AddL(login);
                    //return "Login";
                    
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
                    
                    //else
                    //{
                    //    Console.WriteLine("Sorry-----Try Adding Again");
                    //    return "Signup";
                    //}
                    //return "Menu";

                case "2":
                    //i++;
                    Console.WriteLine("Enter your First name");
                    string a= Console.ReadLine();
                    if(a!=null)
                    {
                        signup.firstname = a;

                    }
                     
                    return "Signup";
                case "3":
                    //j++;
                    Console.WriteLine("Enter your Last name");
                    string b = Console.ReadLine();
                    if (b != null)
                    {
                        signup.lastname = b;

                    }
                    return "Signup";
                case "4":
                    k++;
                    Console.WriteLine("Enter your Email id");
                    string c = Console.ReadLine();
                    if (c != null)
                    {
                        signup.emailId = c;
                        login.emailId = signup.emailId;
                        //education.emailid = signup.emailId;
                        //experience.emailid = signup.emailId;
                        //skills.emailid = signup.emailId;

                    }
                    //signup.emailId = Console.ReadLine();
                   

                    return "Signup";
                case "5":
                   
                    Console.WriteLine("Enter your Password");
                    string d = Console.ReadLine();
                    if (d != null)
                    {
                        signup.password = d;
                        login.password = signup.password;

                    }
                    //signup.password = Console.ReadLine();
                    
                    return "Signup";
                case "6":
                    
                    Console.WriteLine("Enter your Phone number");
                    string e = Console.ReadLine();
                    if (e != null)
                    {
                        signup.phoneno = e;
                        

                    }
                    //signup.phoneno = Console.ReadLine();
                    return "Signup";
                case "7":
                    
                    Console.WriteLine("Enter your Age");
                    int f = Convert.ToInt32(Console.ReadLine());
                    if (f != null)
                    {
                        signup.age = f;
                        //login.password = signup.password;

                    }
                    //signup.age = Convert.ToByte(Console.ReadLine());
                    return "Signup";
                case "8":
                    Console.WriteLine("Enter your City");
                    string g = Console.ReadLine();
                    if (g != null)
                    {
                        signup.city = g;
                        //login.password = signup.password;

                    }
                    //signup.city = Console.ReadLine();
                    return "Signup";

                default:
                    Console.WriteLine("Enter a valid response");
                    Console.ReadKey();
                    return "Signup";
            }
            
        }
    }
}
