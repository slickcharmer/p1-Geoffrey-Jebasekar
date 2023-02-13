//using Data;
using BusinessLogic;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Trainer;

namespace UI_Console
{
    public class Login : IMenu    
    {
        //DbContextOptionsBuilder dbContext = new DbContextOptionsBuilder();
        
        public static string emailid;
        static Trainer_Signup signup = new Trainer_Signup();
        static Trainer_Login login = new Trainer_Login();

        TutorAppContext context = new TutorAppContext();
       
        Validation validation = new Validation();

       
        IEFRepo repo = new TrainerEFRepo();
        int i=0, j=0, k=0;

        
        
        public void Display()
        {
            Console.WriteLine("Login page");
            Console.WriteLine("[2] Press 2 if you have forgot your password");
            Console.WriteLine("[1] Press 1 to proceed to login");
            Console.WriteLine("[0] Press 0 to go back");
            

            
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case "0":
                    return "Menu";
                case "1":
                    Console.WriteLine("Enter your Email id");
                    emailid = Console.ReadLine();
                    int a = repo.IsValidLogin(emailid);
                    if(a==0) 
                    {
                        k++;
                        if(k>3)
                        {
                            Console.WriteLine("You have crossed the maximum attempts");
                            Console.WriteLine("Try resetting your passwrod");
                            goto case "2";
                        }
                        Console.WriteLine("Emaild and password doesnt match-------Try again");
                        goto case "1";
                        
                    }
                    else if(a==1)
                    {
                        Console.WriteLine("--------Logged in successfully----------");
                        
                        return "UserDetails";

                    }
                    else
                    {
                        j++;
                        if(j>3)
                        {
                            Console.WriteLine("Create an account to login");
                            return "Signup";
                        }
                        Console.WriteLine("Try entering a valid eamilid");
                        goto case "1";

                    }
                case "2":
                    bool repeat = true;
                    while(repeat)
                    {
                        Console.WriteLine("Enter your email id");
                        string validEmail = Console.ReadLine();
                        Console.WriteLine("Enter your phone no associated with the email id");
                        string validPhone = Console.ReadLine();
                        bool valid = repo.ForgotPassword(validEmail, validPhone);
                        //context = new TutorAppContext();
                        //TutorAppContext context1 = new TutorAppContext();
                        if (valid)
                        {
                            Console.WriteLine("Enter your new password");
                            Console.WriteLine("Your new password should have atleast 8 digits one uppercase, one lowercase and one number");
                            string validPass = Console.ReadLine();
                            bool result = validation.Password(validPass);
                            if (result)
                            {
                                //context = new TutorAppContext();
                                //TutorAppContext context2 = new TutorAppContext();
                                //repo.UpdatePass(validEmail, validPass);
                                
                                var editProfLogin = context.Logins.Where(x => x.Emailid == validEmail).FirstOrDefault();
                                //login.emailId = editProfLogin.Emailid;
                                editProfLogin.Password = validPass;
                                context.SaveChanges();
                                var editProfSign = context.Signups.Where(x => x.EmailId == validEmail).FirstOrDefault();
                                editProfSign.Password = validPass;
                                context.SaveChanges();


                                //login.password = validPass;
                                //repo.UpdateSignup(signup);
                                //repo.UpdateLogin(login);
                                //repo.UpdateSignupPassword(login);
                                //context = new TutorAppContext();
                                //var editProf = context.Signups;
                                //var editProfDet = from tr in editProf
                                //                  where tr.EmailId == validEmail
                                //                  select tr;
                                //foreach (var prof in editProfDet)
                                //{
                                //    signup.emailId = prof.EmailId;
                                //    signup.password = validPass;
                                //    signup.firstname = prof.Firstname;
                                //    signup.lastname = prof.Lastname;
                                //    signup.phoneno = prof.Phoneno;
                                //    signup.age = prof.Age;
                                //    signup.city = prof.City;
                                //}
                                //repo.UpdateSignup(signup);

                                Console.WriteLine("Password updated successfully");
                                Console.WriteLine("Press any key to go back to login page");
                                Console.ReadKey();
                                repeat = false;
                                break;
                            }
                            else
                            {

                                Console.WriteLine("Try adding a valid password which contains which matches the format given above");

                            }

                        }
                        else
                        {
                            i++;
                            if(i>3)
                            {
                                Console.WriteLine("you have crossed the maximum attempts");
                                Console.WriteLine("Redirecting you to login page");
                                repeat = false;
                                break;

                            }
                            Console.WriteLine("Your Emailid and Phone number does not match");
                            Console.WriteLine("Try again");
                        }
                    }
                    return "Login";



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
        
    }
}
