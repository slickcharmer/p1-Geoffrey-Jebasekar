using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Data;
using Models;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using BusinessLogic;
using EntityLayer.Entities;

namespace UI_Console
{
    public class EditEducation
    {
        
        static string email = Login.PassEmail();

        //static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;Password=Geoffrey2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //IRepo repo1 = new SqlRepo(conStr, email);
        IEFRepo repo = new TrainerEFRepo();
        //Trainer_Education education = new Trainer_Education();

        public bool Percentage(string percent)
        {
            Regex r = new Regex(@"^[0-9][0-9].?[0-9]?%$");
            if (r.IsMatch(percent))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public void editEducation(string emailid)
        {
            Mapper mapper = new Mapper();
            TutorAppContext context = new TutorAppContext();
            
            bool repeat=false;
            Console.WriteLine("Enter the institute name which education details you want to edit");
            string instituteName = Console.ReadLine();

            var editEdu = context.Educations;
            var editEduDet = from edu in editEdu
                             where edu.Emailid == emailid && edu.InstituteName == instituteName
                             select edu;
            

            Trainer_Education education = new Trainer_Education();
            EntityLayer.Entities.Education education1 = new EntityLayer.Entities.Education();

            

            if (editEduDet != null)
            {
                foreach (var edu in editEduDet)
                {
                    education.id = edu.Id;
                    education.educationType = edu.EducationType;
                    education.instituteName = edu.InstituteName;
                    education.stream = edu.Stream;
                    education.startYear = edu.StartYear;
                    education.endYear = edu.EndYear;
                    education.percentage = edu.Percentage;
                }
                repeat = true;
            }
            else
            {
                Console.WriteLine("Enter a valid institute name which is present in your profile");
            }
           



            while (repeat)
            {
                //Console.Clear();
                Console.WriteLine("Hey-----------------------------"+emailid);
                Console.WriteLine("Update your education details and verify your changes");
                Console.WriteLine("[7] Percentage - " + education.percentage);
                Console.WriteLine("[6] End Year - " + education.endYear);
                Console.WriteLine("[5] Start Year - " + education.startYear);
                Console.WriteLine("[4] Stream - " + education.stream);
                Console.WriteLine("[3] Institute Name - " + education.instituteName);
                Console.WriteLine("[2] Education Type - " + education.educationType);
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
                        
                        string query_1 = $"update Education set educationType='{education.educationType}',instituteName='{education.instituteName}',stream='{education.stream}',startYear='{education.startYear}',endYear='{education.endYear}',percentage='{education.percentage}' where emailid='{emailid}' and instituteName='{instituteName}' ";
                        education.emailid = emailid;
                        
                        repo.UpdateEducation(education);
                        repeat = false;
                        break;
                    case "2":
                        Console.WriteLine("Enter your new Education type");
                        education.educationType = Console.ReadLine();
                        break;
                    case "3": 
                        Console.WriteLine("Enter your new Education Institute name");
                        education.instituteName = Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Enter your new Education stream");
                        education.stream = Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("Enter your new Education start year");
                        education.startYear = Console.ReadLine();
                        break;
                    case "6":
                        Console.WriteLine("Enter your new Education end year");
                        education.endYear = Console.ReadLine();
                        break;
                    case "7":
                        Console.WriteLine("Enter your new Education percentage in the specified format");
                        Console.WriteLine("For eg: 92% or 92.4%");

                        string p = Console.ReadLine();
                        if (p != null)
                        {
                            bool percentage = Percentage(p);
                            if (percentage)
                            {
                                education.percentage = p;
                            }
                            else
                            {
                                Console.WriteLine("Please add percentage in the spcified format");
                            }

                        }
                        
                        break;
                    default:
                        Console.WriteLine("Enter a valid response");

                        break;
                }





            }



        }






    }
}


































//public void Display()
//{
//   edu=repo1.GetSpecificTrainersEducation(email, instituteName);    
//    Console.WriteLine("Hey---------------------"+email);

//    Console.WriteLine("[7] Percentage - " + edu.percentage);
//    Console.WriteLine("[6] End Year - " + edu.endYear);
//    Console.WriteLine("[5] Start Year - " + edu.startYear);
//    Console.WriteLine("[4] Stream - " + edu.stream);
//    Console.WriteLine("[3] Institute Name - " + edu.instituteName);
//    Console.WriteLine("[2] Education Type - " + edu.educationType);
//    Console.WriteLine("[1] Save");
//    Console.WriteLine("[0] Go Back");

//}

//public string UserChoice()
//{
//    string userInput = Console.ReadLine();
//    string query = $"update Education set educationType='{edu.educationType}',instituteName='{edu.instituteName}',stream='{edu.stream}',startYear='{edu.startYear}',endYear='{edu.endYear}',percentage='{edu.percentage}' where emailid='{email}' and instituteName='{instituteName}' ";
//    using SqlConnection connection = new SqlConnection(conStr);
//    using SqlCommand command = new SqlCommand(query,connection);
//    switch (userInput)
//    {
//        case "0":
//            return "EditDetails";
//        case "1":



//                Console.WriteLine("Editing Trainer Eduction");

//                int n = command.ExecuteNonQuery();
//            if (n > 0)
//            {
//                //repo1.AddL(login);
//                Console.WriteLine($"{n} rows affected");
//                return "EditDetails";
//            }


//            else
//            {
//                Console.WriteLine("Sorry-----Try Editing Again");
//                //Console.WriteLine(ex.Message);

//            }
//            return "EditEducation";



//        case "2":

//            Console.WriteLine("Enter your Education type");
//            edu.educationType = Console.ReadLine();
//            return "EditEducation";
//        case "3":

//            Console.WriteLine("Enter your Institute name");
//            edu.instituteName = Console.ReadLine();
//            return "EditEducation";
//        case "4":

//            Console.WriteLine("Enter your Stream");
//            edu.stream = Console.ReadLine();
//            return "EditEducation";
//        case "5":
//            Console.WriteLine("Enter your Start Year");
//            edu.startYear = Console.ReadLine();
//            return "EditEducation";
//        case "6":
//            Console.WriteLine("Enter your End Year");
//            edu.endYear = Console.ReadLine();
//            return "EditEducation";
//        case "7":
//            Console.WriteLine("Enter your Percentage");
//            edu.percentage = Console.ReadLine();
//            return "EditEducation";
//        default:    
//            Console.WriteLine("Enter a valid response");
//            return "EditEducation";


//    }
//}