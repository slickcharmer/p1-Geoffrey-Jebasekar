using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Input;
using System.Linq.Expressions;
using System.IO;
using System.Collections;
using System.Reflection.PortableExecutable;

namespace Data
{
    public class SqlRepo : IRepo
    {
        public readonly string connectionstring;
        public string email;
        public string skill;
        public SqlRepo()
        {

        }
        //public SqlRepo(string connectionstring,string val, string skill)
        //{
        //    this.connectionstring = connectionstring;
        //    email = val;
        //    this.skill = skill;

        //}
        public SqlRepo(string connectionString, string val)
        {
            connectionstring = connectionString;
            email = val;
        }
        public SqlRepo(string connectionString)
        {
            connectionstring = connectionString;
        }
        public Trainer_Signup Add(Trainer_Signup signup)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = @"insert into Signup(firstname,lastname,emailid,password,phoneno,age,city)values(@firstname,@lastname,@emailid,@password,@phoneno,@age,@city)";
            //string query = @"insert into restaurants (Name, ZipCode)  values (@name, @zipcode)";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@firstname", signup.firstname);
            command.Parameters.AddWithValue("@lastname", signup.lastname);
            command.Parameters.AddWithValue("@emailid", signup.emailId);
            command.Parameters.AddWithValue("@password", signup.password);
            command.Parameters.AddWithValue("@phoneno", signup.phoneno);
            command.Parameters.AddWithValue("@age", signup.age);
            command.Parameters.AddWithValue("@city", signup.city);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine($"{rows} rows affected");
            return signup;
            /*string userinputemail;
            string query = $"select [emailid] from TrainerSignup where [emailid] = '{userinputemail}'";
            return userinputemail;*/
        }

       
        public Trainer_Login AddL(Trainer_Login login)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = @"insert into Login values(@emailid,@password)";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@emailid", login.emailId);
            command.Parameters.AddWithValue("@password", login.password);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine($"{rows} rows affected");
            return login;
        }



        public Trainer_Education AddE(Trainer_Education education)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = @"insert into Education values(@emailid,@educationType,@instituteName,@stream,@startYear,@endYear,@percentage)";
            //string query = @"insert into restaurants values (@name, @zipcode)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@emailid", education.emailid);
            command.Parameters.AddWithValue("@educationType", education.educationType);
            command.Parameters.AddWithValue("@instituteName", education.instituteName);
            command.Parameters.AddWithValue("@stream", education.stream);
            command.Parameters.AddWithValue("@startYear", education.startYear);
            command.Parameters.AddWithValue("@endYear", education.endYear);
            command.Parameters.AddWithValue("@percentage", education.percentage);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine($"{rows} rows affected");
            return education;
        }

        public Trainer_Companies AddC(Trainer_Companies companies)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = @"insert into Companies(emailid,companyName,Title,industry,employementType,location,startYear,endYear) values(@emailid,@companyName,@Title,@industry,@employementType,@location,@startYear,@endYear)";
            //string query = @"insert into restaurants values (@name, @zipcode)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@emailid", companies.emailid);
            command.Parameters.AddWithValue("@companyName", companies.companyName);
            command.Parameters.AddWithValue("@Title", companies.title);
            command.Parameters.AddWithValue("@industry", companies.industry);
            command.Parameters.AddWithValue("@employementType", companies.employementType);
            command.Parameters.AddWithValue("@location", companies.location);
            command.Parameters.AddWithValue("@startYear", companies.startYear);
            command.Parameters.AddWithValue("@endYear", companies.endYear);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine($"{rows} rows affected");
            return companies;
        }
        





        public Trainer_Skills AddSk(Trainer_Skills skills)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = @"insert into Skills values(@emailid,@skill,@Profeciency)";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@emailid", skills.emailid);
            command.Parameters.AddWithValue("@skill", skills.skill);
            command.Parameters.AddWithValue("@Profeciency", skills.profeciencyInSkill);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine($"{rows} rows affected");

            return skills;
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
        

        

        

        

        public int IsValidLogin(string emailid)
        {
            string query = $@"select emailid from [Login] where emailid = '{emailid}';";
            
            using SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            using SqlCommand command = new SqlCommand(query,con);
            using SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                Console.WriteLine("Enter your password");
                string pass = Console.ReadLine();
                string query_1 = $"select emailid from [Login] where emailid = '{emailid}' and [password] = '{pass}';";
                using SqlCommand command1 = new SqlCommand(query_1,con);
                reader.Close();
                using SqlDataReader sqlDataReader = command1.ExecuteReader();
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

        public void DeleteAcount()
        {
            string query = $"DELETE from Signup WHERE emailid='{email}'";
            using SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            using SqlCommand command = new SqlCommand(query, con);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine($"{rows} rows affected");
            Console.WriteLine("----------------------");
            Console.WriteLine("Account deleted successfully----------Redirecting you to menu");
        }

        public void DeleteSkill(string skill)
        {
            string query = $"DELETE from Skills WHERE emailid='{email}' and skill = '{skill}'";
            using SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            using SqlCommand command = new SqlCommand(query, con);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine($"{rows} rows affected");
        }

        public void DeleteEducation(string education)
        {
            string query = $"DELETE from Education WHERE emailid='{email}' and educationType = '{education}'";
            using SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            using SqlCommand command = new SqlCommand(query, con);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine($"{rows} rows affected");
            
        }

        public void DeleteExperience(string experience)
        {
            string query = $"DELETE from Companies WHERE emailid='{email}' and companyName = '{experience}'";
            using SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            using SqlCommand command = new SqlCommand(query, con);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine($"{rows} rows affected");
            
        }
        public List<Trainer_Skills> GetTrainersSkills(string emailid)
        {
            List<Trainer_Skills> skills= new List<Trainer_Skills>();    
            string query = $"select skill,Profeciency from Skills where emailid = '{emailid}'";
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                skills.Add(new Trainer_Skills()
                {
                    //emailid=reader.GetString(0),
                    skill=reader.GetString(0),
                    profeciencyInSkill=reader.GetInt32(1)


                });
            }
            return skills;
            //throw new NotImplementedException();
        }

        public List<Trainer_Education> GetTrainersEducation(string emailid)
        {
            List<Trainer_Education> education = new List<Trainer_Education>();
            string query = $"select educationType,instituteName,stream,startYear,endYear,percentage from Education where emailid = '{emailid}'";
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                education.Add(new Trainer_Education()
                {
                    //emailid=reader.GetString(0),
                    educationType = reader.GetString(0),
                    instituteName = reader.GetString(1),
                    stream = reader.GetString(2),
                    startYear = reader.GetString(3),
                    endYear = reader.GetString(4),
                    percentage = reader.GetString(5)


                });
            }
            return education;
            
        }

        public List<Trainer_Companies> GetTrainersCompanies(string emailid)
        {
            List<Trainer_Companies> companies = new List<Trainer_Companies>();
            string query = $"select companyName,Title,industry,employementType,location,startYear,endYear from Companies where emailid = '{emailid}'";
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                companies.Add(new Trainer_Companies()
                {
                    //emailid=reader.GetString(0),
                    companyName = reader.GetString(0),
                    title = reader.GetString(1),
                    industry = reader.GetString(2),
                    employementType = reader.GetString(3),
                    location = reader.GetString(4),
                    startYear = reader.GetString(5),
                    endYear = reader.GetString(6),
                    


                });
            }
            return companies;
            
        }

        public List<Trainer_Login> GetAllTrainersLogin()
        {
            throw new NotImplementedException();
        }
        //public List<Trainer_Education> GetSpecificTrainersEducation(string emailid,string instituteName)
        //{
        //    List<Trainer_Education> education = new List<Trainer_Education>();
        //    string query = $"select educationType,instituteName,stream,startYear,endYear,percentage from Education where emailid = '{emailid}' and instituteName = '{instituteName}'";
        //    using SqlConnection connection = new SqlConnection(connectionstring);
        //    connection.Open();
        //    using SqlCommand command = new SqlCommand(query, connection);
        //    using SqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        education.Add(new Trainer_Education()
        //        {
        //            //emailid=reader.GetString(0),
        //            educationType = reader.GetString(0),
        //            instituteName = reader.GetString(1),
        //            stream = reader.GetString(2),
        //            startYear = reader.GetString(3),
        //            endYear = reader.GetString(4),
        //            percentage = reader.GetString(5)


        //        });
        //    }
        //    return education;

        //}

        public List<Trainer_Signup> GetSpecificTrainer()
        {
            throw new NotImplementedException();
        }

        public List<Trainer_Companies> GetSpecificTrainersCompanies(string emailid)
        {
            throw new NotImplementedException();
        }

        public List<Trainer_Skills> GetSpecificTrainersSkills(string emailid)
        {
            throw new NotImplementedException();
        }

        public Trainer_Education GetSpecificTrainersEducation(string emailid, string instituteName)
        {
            Trainer_Education education = new Trainer_Education();
            string query = $"select educationType,instituteName,stream,startYear,endYear,percentage from Education where emailid = '{emailid}' and instituteName = '{instituteName}'";
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                education.educationType = reader.GetString(0);
                education.instituteName = reader.GetString(1);
                education.stream = reader.GetString(2);
                education.startYear = reader.GetString(3);
                education.endYear = reader.GetString(4);
                education.percentage = reader.GetString(5);


            }
            return education;
        }

        public ArrayList ViewDetails(string email)
        {
            ArrayList arrayList = new ArrayList();
            string query = $"SELECT Signup.firstname,Signup.lastname,Signup.emailId,Signup.age,Education.educationType,Education.instituteName,Education.stream,Education.percentage,Companies.companyName,Companies.Title,Companies.industry,Companies.location,Skills.skill,Skills.Profeciency From Signup INNER JOIN Education on Signup.emailId = Education.emailid INNER join Companies on Signup.emailId = Companies.emailid INNER JOIN Skills on Signup.emailId = Skills.emailid WHERE Signup.emailId = '{email}'";
            using SqlConnection connection = new SqlConnection(connectionstring) ;
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                arrayList.Add(new Trainer_Details()
                {
                    firstname =reader.GetString(0),
                    lastname = reader.GetString(1),
                    emailid = reader.GetString(2),
                    age = reader.GetInt32(3),
                    educationType = reader.GetString(4),
                    instituteName = reader.GetString(5),
                    stream = reader.GetString(6),
                    percentage = reader.GetString(7),
                    companyName = reader.GetString(8),
                    title = reader.GetString(9),
                    industry = reader.GetString(10),
                    location = reader.GetString(11),
                    skill = reader.GetString(12),
                    profeciencyInSkill = reader.GetInt32(13)

                });
            }

            return arrayList;
        }

        public List<Trainer_Details> ViewDetailsDisconnected(string email)
        {
            List<Trainer_Details> trainer_Details = new List<Trainer_Details>();
            string query = $"SELECT Signup.firstname,Signup.lastname,Signup.emailId,Signup.age,Education.educationType,Education.instituteName,Education.stream,Education.percentage,Companies.companyName,Companies.Title,Companies.industry,Companies.location,Skills.skill,Skills.Profeciency From Signup INNER JOIN Education on Signup.emailId = Education.emailid INNER join Companies on Signup.emailId = Companies.emailid INNER JOIN Skills on Signup.emailId = Skills.emailid WHERE Signup.emailId = '{email}';";
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dataTable = ds.Tables[0];
            foreach(DataRow row in dataTable.Rows)
            {
                trainer_Details.Add(new Trainer_Details()
                {
                    firstname = (string)row[0],
                    lastname = (string)row[1],
                    emailid = (string)row[2],
                    age = (int)row[3],
                    educationType = (string)row[4],
                    instituteName = (string)row[5],
                    stream = (string)row[6],
                    percentage = (string)row[7],
                    companyName = (string)row[8],
                    title = (string)row[9],
                    industry = (string)row[10],
                    location = (string)row[11],
                    skill = (string)row[12],
                    profeciencyInSkill = (int)row[13]

                }) ;
            }

            return trainer_Details;
        }
    }
    
}
