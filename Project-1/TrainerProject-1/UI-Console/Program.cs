// See https://aka.ms/new-console-template for more information
global using Serilog;
using UI_Console;
//using Data;
using BusinessLogic;
using Models;


namespace Trainer
{
    class program 
    {
        

       
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                             .WriteTo.File(@"..\..\..\Logs\logs.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                             .CreateLogger();
            Log.Logger.Information("--------------------Program is started------------------");
            List<Trainer_Signup> GetDetails = new List<Trainer_Signup>();
            
            
            IEFRepo repo = new TrainerEFRepo();

            
           
            EditEducation education1 = new EditEducation();
            
            
            IMenu menu = new Menu();
            IMenu menu1 = new EditDetails();
            
            
            
            
            bool repeat = true;
            while(repeat)
            {
                //Console.Clear();
                menu.Display();
                string userInput = menu.UserChoice();
                switch(userInput)
                {
                    case "Exit":
                        Log.Logger.Information("----------------Program ends----------------------");
                        Console.WriteLine("Thanks for visiting--------Come again");
                        repeat = false;
                        break;
                    case "GetAllTrainers":
                        Log.Logger.Information("Get all trainers has been accessed");
                        var trainerdet = repo.GetAllTrainers();
                        foreach(var trainer in trainerdet) 
                        {
                            
                            Console.WriteLine(trainer.GetTrainer());
                            
                        }
                        Console.WriteLine("Press any key to return to Menu page");
                        Console.ReadLine();
                        break;
                        
                        
                    case "Signup":
                        Log.Logger.Information("A new trainer entered");
                        menu = new Signup();
                        break;
                    case "Login":
                        
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
                        
                        while(rep)
                        {
                            
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
                                    
                                    var eduDisp = repo.GetTrainersEducation(f);
                                    Console.WriteLine("Welcome " + f);
                                    foreach (var disp in eduDisp)
                                    {
                                        Console.WriteLine($"Education Type: {disp.educationType} " + "\n" +
                                            $"Institute Name: {disp.instituteName} " + "\n" +
                                            $"Stream: {disp.stream} " + "\n" +
                                            $"Start Year: {disp.startYear} " + "\n" +
                                            $"End Year: {disp.endYear} " + "\n" +
                                            $"Percentage: {disp.percentage}");
                                        Console.WriteLine("====================================================\n");

                                    }
                                    
                                    education1.editEducation(f);
                                    

                                    break;






                                    

                                case "EditExperience":
                                    string g = Login.PassEmail();
                                    Console.WriteLine("---------------Experience---------------");
                                   
                                    var expDisp = repo.GetTrainersExperience(g);
                                    Console.WriteLine("Welcome " + g);
                                    foreach (var disp in expDisp)
                                    {
                                        Console.WriteLine($"Company name: {disp.companyName} " + "\n" +
                                            $"Title: {disp.title} " + "\n" +
                                            $"Location: {disp.location} " + "\n" +
                                            $"Experience in years: {disp.experience}"
                                            );
                                        Console.WriteLine("=====================================================\n");

                                    }
                                    string emailid1 = Login.PassEmail();
                                    EditExperience experience1 = new EditExperience(emailid1);
                                    
                                    break;
                                case "EditSkills":
                                    string e = Login.PassEmail();
                                    Console.WriteLine("---------------Skills---------------");
                                    
                                    var skillDisp = repo.GetTrainersSkills(e);
                                    Console.WriteLine("Welcome " + e);
                                    foreach (var disp in skillDisp)
                                    {
                                        Console.WriteLine($"Skill: {disp.skill} " + "\n" +
                                            $"Profeciency: {disp.profeciencyInSkill}");

                                        Console.WriteLine("=====================================================\n");
                                    }
                                    string emailid2 = Login.PassEmail();
                                    EditSkills skill1 = new EditSkills(emailid2);

                                    break;
                                case "EditProfile":
                                    string p = Login.PassEmail();
                                    Console.WriteLine("------------------Profile------------------");
                                    
                                    var profDisp = repo.GetTrainer(p);
                                    Console.WriteLine("Welcome-------------"+p);
                                    foreach (var disp in profDisp)
                                    {
                                        Console.WriteLine($"First name: {disp.firstname} " + "\n" +
                                            $"Last name: {disp.lastname} " + "\n" +
                                            $"Phone number: {disp.phoneno} " + "\n" +
                                            $"Age: {disp.age} " + "\n" + 
                                            $"City: {disp.city} "
                                            );
                                        Console.WriteLine("=====================================================\n");
                                    }
                                    Console.WriteLine("Press any key to edit your details");
                                    Console.ReadKey();
                                    EditProfile profile = new EditProfile(p);
                                    


                                    break;
                                    

                            }
                        }
                        break;
                    case "DeleteDetails":
                        Log.Logger.Information("A trainer wanted to delete their details or their account");
                        bool repe = true;
                        
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
                                    
                                    var eduDisp = repo.GetTrainersEducation(f);
                                    Console.WriteLine("Welcome " + f);
                                    foreach (var disp in eduDisp)
                                    {
                                        Console.WriteLine($"Education Type: {disp.educationType} " + "\n" +
                                            $"Institute Name: {disp.instituteName} " + "\n" +
                                            $"Stream: {disp.stream} " + "\n" +
                                            $"Start Year: {disp.startYear} " + "\n" +
                                            $"End Year: {disp.endYear} " + "\n" +
                                            $"Percentage: {disp.percentage}");
                                        Console.WriteLine("====================================================\n");

                                    }
                                    Console.WriteLine("Enter the Education Type which you want to delete. All the relevant details assocaited with it will be deleted");
                                    string education = Console.ReadLine();
                                    
                                    repo.DeleteEducation(f,education);

                                    
                                    break;

                                case "DeleteExperience":
                                    string g = Login.PassEmail();
                                    Console.WriteLine("---------------Experience---------------");
                                    
                                    var expDisp = repo.GetTrainersExperience(g);
                                    Console.WriteLine("Welcome " + g);
                                    foreach (var disp in expDisp)
                                    {
                                        Console.WriteLine($"Company name: {disp.companyName} " + "\n" +
                                            $"Title: {disp.title} " + "\n" +
                                            $"Location: {disp.location} " + "\n" +
                                            $"Experience in years: {disp.experience}"
                                            );
                                        Console.WriteLine("=====================================================\n");

                                    }
                                    Console.WriteLine("Enter the Company name and title which experience details you want to delete. All the relevant details assocaited with it will be deleted");
                                    string experience = Console.ReadLine();
                                    string title = Console.ReadLine();
                                    repo.DeleteExperience(g,experience,title);

                                    
                                    break;
                                case "DeleteSkills":
                                    string e = Login.PassEmail();
                                    Console.WriteLine("---------------Skills---------------");
                                    var skillDisp = repo.GetTrainersSkills(e);
                                    Console.WriteLine("Welcome " + e);
                                    foreach (var disp in skillDisp)
                                    {
                                        Console.WriteLine($"Skill: {disp.skill} " + "\n" +
                                            $"Profeciency: {disp.profeciencyInSkill}");

                                        Console.WriteLine("=====================================================\n");
                                    }
                                    Console.WriteLine("Enter the skill which you want to delete. All the relevant details assocaited with it will be deleted");
                                    string skill = Console.ReadLine();
                                    
                                    repo.DeleteSkill(e, skill);
                                    
                                    

                                    break;
                                case "DeleteAccount":
                                    string email = Login.PassEmail();
                                    Console.WriteLine("------------------Profile------------------");

                                    var profDisp = repo.GetTrainer(email);
                                    Console.WriteLine("Welcome-------------" + email);
                                    foreach (var disp in profDisp)
                                    {
                                        Console.WriteLine($"First name: {disp.firstname} " + "\n" +
                                            $"Last name: {disp.lastname} " + "\n" +
                                            $"Phone number: {disp.phoneno} " + "\n" +
                                            $"Age: {disp.age} " + "\n" +
                                            $"City: {disp.city} "
                                            );
                                        Console.WriteLine("=====================================================\n");
                                    }
                                    //repo1 = new SqlRepo(conStr, email);
                                    //repo1.DeleteAcount();
                                    Console.WriteLine("Press any key to confirm the deletion of your account");
                                    Console.ReadKey();
                                    repo.DeleteAccount(email);
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
            
            
            
        }
    }
}
