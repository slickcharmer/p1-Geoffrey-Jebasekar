// See https://aka.ms/new-console-template for more information
global using Serilog;
using UI_Console;
using Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;


namespace Trainer
{
    class program : SqlRepo
    {
        static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;" +
            "Password=Geoffrey2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                             .WriteTo.File(@"..\..\..\Logs\logs.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                             .CreateLogger();
            Log.Logger.Information("--------------------Program is started------------------");
            List<Trainer_Signup> GetDetails = new List<Trainer_Signup>();
            
            SqlRepo repo = new SqlRepo(conStr);
            Signup signup = new Signup();
            Login login = new Login();
            EditDetails det = new EditDetails();
            DeleteDetails del = new DeleteDetails();
            IRepo repo1;
            EditEducation education1 = new EditEducation();
            
            
            IMenu menu = new Menu();
            IMenu menu1 = new EditDetails();
            
            //string email = login.PassEmail();
            
            
            bool repeat = true;
            while(repeat)
            {
                //Console.Clear();
                menu.Display();
                string userInput = menu.UserChoice();
                switch(userInput)
                {
                    case "Exit":
                        Console.WriteLine("Thanks for visiting--------Come again");
                        repeat = false;
                        break;
                    case "GetAllTrainers":
                        Log.Logger.Information("Get all trainers has been accessed");
                        var trainerdet = repo.GetAllTrainers();
                        foreach(var trainer in trainerdet) 
                        {
                            //var r = trainerdet.GetTrainer();
                            Console.WriteLine(trainer.GetTrainer());
                            //Console.ReadLine();
                        }
                        break;
                        
                        
                    case "Signup":
                        Log.Logger.Information("A new trainer entered");
                        menu = new Signup();
                        break;
                    case "Login":
                        //repeat = false;
                        //flag = 1;
                        Log.Logger.Information("A trainer logged in");
                        menu = new Login();
                        break;
                    case "UserDetails":
                        menu = new UserDetails();
                            
                        break;
                    case "AddDetails":
                        Log.Logger.Information("A trainer wanted to add their details");
                        menu = new AddDetails();
                        break;
                    case "EditDetails":
                        Log.Logger.Information("A trainer wanted to edit their details ");
                        bool rep = true;
                        menu = new EditDetails();
                        //menu.Display();
                        while(rep)
                        {
                            //menu = new EditDetails();
                            menu.Display();
                            string choice = menu.UserChoice();
                            switch (choice) 
                            {
                                case "UserDetails":
                                    rep = false;
                                    menu = new UserDetails();
                                    break;
                                case "EditEducation":
                                    string f = Login.PassEmail();
                                    Console.WriteLine("---------------Education---------------");
                                    repo1 = new SqlRepo(conStr);
                                    var eduDisp = repo1.GetTrainersEducation(f);
                                    Console.WriteLine("Welcome " + f);
                                    foreach (var disp in eduDisp)
                                    {
                                        Console.WriteLine($"Education Type: {disp.educationType}, Institute Name: {disp.instituteName}, Stream: {disp.stream}, " +
                                            $"Start Year: {disp.startYear}, End Year: {disp.endYear}, Percentage: {disp.percentage}");

                                    }
                                    string emailid = Login.PassEmail();
                                    education1.editEducation(emailid);
                                    

                                    break;






                                    

                                case "EditExperience":
                                    string g = Login.PassEmail();
                                    Console.WriteLine("---------------Experience---------------");
                                    repo1 = new SqlRepo(conStr);
                                    var expDisp = repo1.GetTrainersCompanies(g);
                                    Console.WriteLine("Welcome " + g);
                                    foreach (var disp in expDisp)
                                    {
                                        Console.WriteLine($"Company name: {disp.companyName}, Title: {disp.title}, Industry: {disp.industry}, " +
                                            $"Employement Type: {disp.employementType}, Location: {disp.location}, Start Year: {disp.startYear}, End Year: {disp.endYear}");

                                    }
                                    string emailid1 = Login.PassEmail();
                                    EditExperience experience1 = new EditExperience(emailid1);
                                    
                                    break;
                                case "EditSkills":
                                    string e = Login.PassEmail();
                                    Console.WriteLine("---------------Skills---------------");
                                    repo1 = new SqlRepo(conStr);
                                    var skillDisp = repo1.GetTrainersSkills(e);
                                    Console.WriteLine("Welcome " + e);
                                    foreach (var disp in skillDisp)
                                    {
                                        Console.WriteLine($"Skill: {disp.skill}, Profeciency: {disp.profeciencyInSkill}");

                                    }
                                    string emailid2 = Login.PassEmail();
                                    EditSkills skill1 = new EditSkills(emailid2);

                                    break;
                                case "EditDetails":

                                    break;
                                    

                            }
                        }
                        break;
                    case "DeleteDetails":
                        Log.Logger.Information("A trainer wanted to delete their details or their account");
                        bool repe = true;
                        //menu = new EditDetails();
                        //menu.Display();
                        while (repe)
                        {
                            menu = new DeleteDetails();
                            menu.Display();
                            string choice = menu.UserChoice();
                            switch (choice)
                            {
                                case "UserDetails":
                                    repe = false;
                                    menu = new UserDetails();
                                    break;
                                case "DeleteEducation":
                                    string f = Login.PassEmail();
                                    Console.WriteLine("---------------Education---------------");
                                    repo1 = new SqlRepo(conStr);
                                    var eduDisp = repo1.GetTrainersEducation(f);
                                    Console.WriteLine("Welcome " + f);
                                    foreach (var disp in eduDisp)
                                    {
                                        Console.WriteLine($"Education Type: {disp.educationType}, Institute Name: {disp.instituteName}, Stream: {disp.stream}, " +
                                            $"Start Year: {disp.startYear}, End Year: {disp.endYear}, Percentage: {disp.percentage}");

                                    }
                                    Console.WriteLine("Enter the education which you want to delete. All the relevant details assocaited with it will be deleted");
                                    string education = Console.ReadLine();
                                    repo1 = new SqlRepo(conStr, f);
                                    repo1.DeleteEducation(education);

                                    //del.DeleteEducation();
                                    break;

                                case "DeleteExperience":
                                    string g = Login.PassEmail();
                                    Console.WriteLine("---------------Experience---------------");
                                    repo1 = new SqlRepo(conStr);
                                    var expDisp = repo1.GetTrainersCompanies(g);
                                    Console.WriteLine("Welcome " + g);
                                    foreach (var disp in expDisp)
                                    {
                                        Console.WriteLine($"Company name: {disp.companyName}, Title: {disp.title}, Industry: {disp.industry}, " +
                                            $"Employement Type: {disp.employementType}, Location: {disp.location}, Start Year: {disp.startYear}, End Year: {disp.endYear}");

                                    }
                                    Console.WriteLine("Enter the Company name which you want to delete. All the relevant details assocaited with it will be deleted");
                                    string experience = Console.ReadLine();
                                    repo1 = new SqlRepo(conStr, g);
                                    repo1.DeleteExperience(experience);

                                    //del.DeleteExperience();
                                    break;
                                case "DeleteSkills":
                                    string e = Login.PassEmail();
                                    Console.WriteLine("---------------Skills---------------");
                                    repo1 = new SqlRepo(conStr);
                                    var skillDisp = repo1.GetTrainersSkills(e);
                                    Console.WriteLine("Welcome " + e);
                                    foreach (var disp in skillDisp)
                                    {
                                        Console.WriteLine($"Skill: {disp.skill}, Profeciency: {disp.profeciencyInSkill}");
                                        
                                    }
                                    Console.WriteLine("Enter the skill which you want to delete. All the relevant details assocaited with it will be deleted");
                                    string skill = Console.ReadLine();
                                    repo1 = new SqlRepo(conStr, e);
                                    repo1.DeleteSkill(skill);
                                    
                                    //del.DeleteEducation();

                                    break;
                                case "DeleteAccount":
                                    string email = Login.PassEmail();
                                    repo1 = new SqlRepo(conStr, email);
                                    repo1.DeleteAcount();
                                    menu = new Menu();
                                    repe = false;
                                    

                                    break;


                            }
                        }
                        break;
                    case "ViewDetails":
                        menu = new ViewDetails();
                        break;


                    case "Education":
                        menu = new Education();
                        break;
                    case "Experience":
                        menu = new Experience();
                        break;
                    case "Skills":
                        menu = new Skills();
                        break;
                    case "Menu":
                        menu = new Menu();
                        break;
                       

                }
                
            }
            Log.Logger.Information("----------------Program ends----------------------");
            /*IDetails details = new Login();
            if (flag==1)
            {
                repeat = true;
                while(repeat)
                {
                    string a = details.Display();
                    switch(a)
                    {
                        case "UserDetails":
                            break;
                        case "Signup":
                            menu=new Signup();
                            break;
                    }
                }


            }*/
            
        }
    }
}
