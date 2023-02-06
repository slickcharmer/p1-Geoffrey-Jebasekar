//using Data;
using Models;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System;
using BusinessLogic;
using EntityLayer.Entities;
using Microsoft.IdentityModel.Tokens;

namespace UI_Console
{
    public class EditProfile
    {
        
        
        public EditProfile(string email)
        {
            Trainer_Signup signup = new Trainer_Signup();
            Mapper mapper = new Mapper();
            TutorAppContext context = new TutorAppContext();
            IEFRepo repo = new TrainerEFRepo();
            Validation validation = new Validation();
            bool repeat = true;
            
            var editProf = context.Signups;
            var editProfDet = from tr in editProf
                              where tr.EmailId == email
                              select tr;
            if(!editProfDet.IsNullOrEmpty())
            {
                foreach(var prof in editProfDet)
                {
                    signup.emailId = prof.EmailId;
                    signup.password = prof.Password;
                    signup.firstname = prof.Firstname;
                    signup.lastname = prof.Lastname;
                    signup.phoneno = prof.Phoneno;
                    signup.age = prof.Age;
                    signup.city = prof.City;
                }
                repeat = true;
            }
            else
            {
                Console.WriteLine("Enter a valid institute name which is present in your profile");
            }


           
            
            while (repeat)
            {
                Console.WriteLine("Welcome-------------------"+email);
                Console.WriteLine("Edit your profile details");
                Console.WriteLine("[6] City - " + signup.city);
                Console.WriteLine("[5] age - " + signup.age);
                Console.WriteLine("[4] Phone - " + signup.phoneno);
                Console.WriteLine("[3] Last Name - " + signup.lastname);
                Console.WriteLine("[2] First Name - " + signup.firstname);
                Console.WriteLine("[1] Save");
                Console.WriteLine("[0] Go Back");
                Console.WriteLine("Enter your choice");
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
                        repeat = false;
                        break;
                    case "1":
                        
                        //string query_1 = $"update Signup set firstname='{signup.firstname}',lastname='{signup.lastname}',phoneno='{signup.phoneno}',age='{signup.age}',city='{signup.city}' where emailid = '{email}'";
                        
                        try
                        {

                            repo.UpdateProfile(signup);
                            Console.WriteLine("User profile updated successfully");
                            
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Sorry.........Try saving again");
                        }
                        
                        repeat = false;
                        break;
                    case "2":
                        Console.WriteLine("Enter your new First name");
                        string a = Console.ReadLine();
                        if (a != null)
                        {
                            signup.firstname = a;

                        }
                        break;
                    case "3":

                        Console.WriteLine("Enter your new Last name");
                        string b = Console.ReadLine();
                        if (b != null)
                        {
                            signup.lastname = b;

                        }
                        break;
                   case "4":
                        Console.WriteLine("Enter your new Phone number");
                        string e = Console.ReadLine();

                        if (e != null)
                        {
                            bool no = validation.Phone(e);
                            if (no)
                            {
                                signup.phoneno = e;
                            }
                            else
                            {
                                Console.WriteLine("Please add a mobile no which has only 10 digits and no symbols or extensions in between");
                            }
                        }
                        break;
                    case "5":
                        Console.WriteLine("Enter your new Age");
                        int f = Convert.ToInt32(Console.ReadLine());
                        if (f != null)
                        {
                            if (f >= 21)
                            {
                                signup.age = f;
                            }
                            else
                            {
                                Console.WriteLine("Trainers age should be greater than or equal to 21");
                            }


                        }
                        break;
                    case "6":
                        Console.WriteLine("Enter your new City");
                        string g = Console.ReadLine();
                        if (g != null)
                        {
                            signup.city = g;


                        }

                        break;
                    default:
                        Console.WriteLine("Enter a valid response");
                        Console.WriteLine("Press any key to continue editing");
                        Console.ReadKey();
                        break;
                }
            }


        }
    }
}
