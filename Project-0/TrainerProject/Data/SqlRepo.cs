using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Input;
using System.Linq.Expressions;

namespace Data
{
    public class SqlRepo : IRepo
    {
        public readonly string connectionstring;

        public SqlRepo()
        {

        }
        public SqlRepo(string connectionString)
        {
            connectionstring = connectionString;
        }
        public Trainer_Signup Add(Trainer_Signup signup)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = @"insert into TrainerSignup(firstname,lastname,emailid,password,phoneno,age,city)values(@firstname,@lastname,@emailid,@password,@phoneno,@age,@city)";
            //string query = @"insert into restaurants (Name, ZipCode)  values (@name, @zipcode)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@firstname", signup.firstname);
            command.Parameters.AddWithValue("@lastname", signup.lastname);
            command.Parameters.AddWithValue("@emailid", signup.emailId);
            command.Parameters.AddWithValue("@password", signup.password);
            command.Parameters.AddWithValue("@phoneno", signup.phoneno);
            command.Parameters.AddWithValue("@age", signup.age);
            command.Parameters.AddWithValue("@city", signup.city);
            return signup;
            /*string userinputemail;
            string query = $"select [emailid] from TrainerSignup where [emailid] = '{userinputemail}'";
            return userinputemail;*/
        }

        public Trainer_Companies AddC(Trainer_Companies companies)
        {
            throw new NotImplementedException();
        }

        public Trainer_Education AddE(Trainer_Education education)
        {
            throw new NotImplementedException();
        }

        public Trainer_Login AddL(Trainer_Login login)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = @"insert into TrainerSignup(firstname,lastname,emailid,password,phoneno,age,city)values(@firstname,@lastname,@emailid,@password,@phoneno,@age,@city)";
            //string query = @"insert into restaurants (Name, ZipCode)  values (@name, @zipcode)";
            SqlCommand command = new SqlCommand();
            
            command.Parameters.AddWithValue("@emailid", login.emailId);
            command.Parameters.AddWithValue("@password", login.password);
            
            return login;
        }

        public Trainer_Education AddS(Trainer_Education education)
        {
            throw new NotImplementedException();
        }

        public Trainer_Skills AddSk(Trainer_Skills skills)
        {
            throw new NotImplementedException();
        }

        public List<Trainer_Signup> GetAllTrainers()
        {
            List<Trainer_Signup> signup = new List<Trainer_Signup>();
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = "select firstname,lastname,emailid,phoneno,age,city from Signup";
            SqlCommand command = new SqlCommand(query,connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                signup.Add(new Trainer_Signup()
                {
                    firstname = reader.GetString(0),
                    lastname = reader.GetString(1),
                    emailId = reader.GetString(2),
                    phoneno = reader.GetString(3),
                    age = reader.GetInt32(4),
                    city = reader.GetString(5),



                }) ;
            }

            return signup;
        }
        

        public List<Trainer_Companies> GetAllTrainersCompanies()
        {
            throw new NotImplementedException();
        }

        public List<Trainer_Education> GetAllTrainersEducation()
        {
            throw new NotImplementedException();
        }

        public List<Trainer_Login> GetAllTrainersLogin()
        {
            throw new NotImplementedException();
        }

        public List<Trainer_Skills> GetAllTrainersSkills()
        {
            throw new NotImplementedException();
        }

        

        public int IsValidLogin(string emailid)
        {
            string query = $"select emailid from [Login] where emailid = '{emailid}';";
            using SqlConnection con = new SqlConnection();
            con.Open();
            using SqlCommand command = new SqlCommand(query,con);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                Console.WriteLine("Enter your password");
                string pass = Console.ReadLine();
                string query_1 = $"select emailid from [Login] where emailid = '{emailid}' and [password] = '{pass}';";
                using SqlCommand command1 = new SqlCommand(query_1,con);
                SqlDataReader sqlDataReader = command1.ExecuteReader();
                if(sqlDataReader.Read()) 
                {
                    Console.WriteLine("Login Success");
                    return 1;

                }
                else
                {
                    Console.WriteLine("\nEmail and password doesnt match");
                    Console.WriteLine("Try logging in again");
                    return 0;
                }

            }
            else
            {
                Console.WriteLine("Create an account to login");
                return 2;
            }
            //throw new NotImplementedException();
        }
        



    }
}
