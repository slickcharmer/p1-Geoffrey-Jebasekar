using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    public class EditExperience
    {
        
        static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;Password=Geoffrey2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //IRepo repo1 = new SqlRepo(conStr);
        public EditExperience(string emailid) 
        {
            bool repeat = false;
            Console.WriteLine("Enter the Company name which experience details you want to edit");
            string companyName = Console.ReadLine();
            Trainer_Companies experience = new Trainer_Companies();
            string query = $"select companyName,title,industry,employementType,location,startYear,endYear from Companies where emailid = '{emailid}' and companyName = '{companyName}'";
            using SqlConnection connection = new SqlConnection(conStr);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                experience.companyName = reader.GetString(0);
                experience.title = reader.GetString(1);
                experience.industry = reader.GetString(2);
                experience.employementType = reader.GetString(3);
                experience.location = reader.GetString(4);
                experience.startYear = reader.GetString(5);
                experience.endYear = reader.GetString(6);
                repeat = true;


            }
            else
            {
                Console.WriteLine("Entered Company name does not exist in your profile");

            }
            connection.Close();
            reader.Close();
            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Hey-----------------------------" + emailid);
                Console.WriteLine("Update your experience details and verify your changes");
                Console.WriteLine("[8] End Year - " + experience.endYear);
                Console.WriteLine("[7] Start Year - " + experience.startYear);
                Console.WriteLine("[6] Location - " + experience.location);
                Console.WriteLine("[5] Employement type - " + experience.employementType);
                Console.WriteLine("[4] Industry - " + experience.industry);
                Console.WriteLine("[3] Title - " + experience.title);
                Console.WriteLine("[2] Company name - " + experience.companyName);

                Console.WriteLine("[1] Save");
                Console.WriteLine("[0] Go Back");
                Console.WriteLine("Enter your choice");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        repeat = false;
                        break;
                    case "1":
                        connection.Open();
                        string query_1 = $"update Companies set companyName='{experience.companyName}',Title='{experience.title}',industry='{experience.industry}',employementType='{experience.employementType}',location='{experience.location}',startYear='{experience.startYear}',endYear='{experience.endYear}' where emailid='{emailid}' and companyName='{companyName}' ";
                        SqlCommand command1 = new SqlCommand(query_1, connection);
                        int n = command1.ExecuteNonQuery();
                        if (n > 0)
                        {
                            Console.WriteLine($"{n} row(s) affected");
                            Console.WriteLine("User Experience updated successfully");
                        }
                        connection.Close();
                        repeat = false;
                        break;
                    case "2":
                        Console.WriteLine("Enter your new Company name");
                        experience.companyName = Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Enter your new Title");
                        experience.title = Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Enter your new Industry");
                        experience.industry = Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("Enter your new Employement type");
                        experience.employementType = Console.ReadLine();
                        break;
                    case "6":
                        Console.WriteLine("Enter your new Location");
                        experience.location = Console.ReadLine();
                        break;
                    case "7":
                        Console.WriteLine("Enter your new Start year");
                        experience.startYear = Console.ReadLine();
                        break;
                    case "8":
                        Console.WriteLine("Enter your new End year");
                        experience.endYear = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Enter a valid response");

                        break;
                }





            }
        }
    }
}
