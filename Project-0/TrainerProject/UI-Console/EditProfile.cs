using Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System;

namespace UI_Console
{
    public class EditProfile
    {
        static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;Password=Geoffrey2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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
        public EditProfile(string email)
        {
            Trainer_Signup signup = new Trainer_Signup();
            bool repeat = true;
            string query = $"SELECT firstname,lastname,phoneno,age,city from Signup where emailid = '{email}'";
            using SqlConnection connection = new SqlConnection(conStr);
            connection.Open();
            using SqlCommand command = new SqlCommand(query,connection);
            using SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                signup.firstname = reader.GetString(0);
                signup.lastname = reader.GetString(1);
                signup.phoneno = reader.GetString(2);
                signup.age = reader.GetInt32(3);
                signup.city = reader.GetString(4);
            }
            connection.Close();
            reader.Close();
            command.Dispose();
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
                        
                        string query_1 = $"update Signup set firstname='{signup.firstname}',lastname='{signup.lastname}',phoneno='{signup.phoneno}',age='{signup.age}',city='{signup.city}' where emailid = '{email}'";
                        connection.Open();
                        SqlCommand command1 = new SqlCommand(query_1, connection);
                        int n = command1.ExecuteNonQuery();
                        try
                        {
                            if (n > 0)
                            {
                                Console.WriteLine($"{n} row(s) affected");
                                Console.WriteLine("User profile updated successfully");
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Sorry.........Try saving again");
                        }
                        connection.Close();
                        command1.Dispose();
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
                            bool no = Phone(e);
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
