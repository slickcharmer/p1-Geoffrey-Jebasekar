// See https://aka.ms/new-console-template for more information
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
            List<Trainer_Signup> GetDetails = new List<Trainer_Signup>();
            
            SqlRepo repo = new SqlRepo(conStr);
            Signup signup = new Signup();
            Login login = new Login();
            EditDetails det = new EditDetails();
            DeleteDetails del = new DeleteDetails();
            IRepo repo1;
            //Login login = new Login();
            //int flag = 0;
            IMenu menu = new Menu();
            
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
                        var trainerdet = repo.GetAllTrainers();
                        foreach(var trainer in trainerdet) 
                        {
                            //var r = trainerdet.GetTrainer();
                            Console.WriteLine(trainer.GetTrainer());
                            //Console.ReadLine();
                        }
                        break;
                        
                        
                    case "Signup":
                        menu = new Signup();
                        break;
                    case "Login":
                        //repeat = false;
                        //flag = 1;
                        menu = new Login();
                        break;
                    case "UserDetails":
                        menu = new UserDetails();
                            
                        break;
                    case "AddDetails":
                        menu = new AddDetails();
                        break;
                    case "EditDetails":
                        bool rep = true;
                        //menu = new EditDetails();
                        //menu.Display();
                        while(rep)
                        {
                            menu = new EditDetails();
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
                                    Console.WriteLine("Enter the institute name which details you want to edit");
                                    string edu = Console.ReadLine();
                                    //repo1 = new SqlRepo(conStr, f);
                                    //var education = repo1.GetSpecificTrainersEducation(f, edu);
                                    menu = new EditEducation(edu);
                                    menu.Display();
                                    string a = menu.UserChoice();
                                    //switch(a)
                                    //{
                                    //    case "EditDetails":
                                    //        break;
                                    //    case "EditEducation":
                                    //        menu = new EditEducation();
                                    //        break;


                                    //}

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

                                    break;
                                case "EditDetails":

                                    break;
                                    

                            }
                        }
                        break;
                    case "DeleteDetails":
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
