using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Data.SqlClient;

namespace UI_Console
{
    public class EditEducation
    {
        //public List<Trainer_Education> education = new List<Trainer_Education>();
        static string email = Login.PassEmail();

        static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;Password=Geoffrey2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        IRepo repo1 = new SqlRepo(conStr, email);
        Trainer_Education edu = new Trainer_Education();


        //string instituteName;
        //public EditEducation(string name)
        //{
        //    instituteName = name;
        //}

        public void editEducation(string emailid)
        {
            
            bool repeat=false;
            Console.WriteLine("Enter the institute name which education details you want to edit");
            string instituteName = Console.ReadLine();
            Trainer_Education education = new Trainer_Education();
            string query = $"select educationType,instituteName,stream,startYear,endYear,percentage from Education where emailid = '{emailid}' and instituteName = '{instituteName}'";
            using SqlConnection connection = new SqlConnection(conStr);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
             
            if (reader.Read())
            {
                education.educationType = reader.GetString(0);
                education.instituteName = reader.GetString(1);
                education.stream = reader.GetString(2);
                education.startYear = reader.GetString(3);
                education.endYear = reader.GetString(4);
                education.percentage = reader.GetString(5);
                repeat = true;


            }
            else
            {
                Console.WriteLine("Entered institute name does not exist in your profile");

            }
            connection.Close();
            reader.Close();
            while(repeat)
            {
                Console.Clear();
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
                        connection.Open();
                        string query_1 = $"update Education set educationType='{education.educationType}',instituteName='{education.instituteName}',stream='{education.stream}',startYear='{education.startYear}',endYear='{education.endYear}',percentage='{education.percentage}' where emailid='{emailid}' and instituteName='{instituteName}' ";
                        SqlCommand command1 = new SqlCommand(query_1,connection);
                        int n = command1.ExecuteNonQuery();
                        if(n>0)
                        {
                            Console.WriteLine($"{n} row(s) affected");
                        }
                        connection.Close();
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
                        Console.WriteLine("Enter your new Education graduation percentage");
                        education.percentage = Console.ReadLine();
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