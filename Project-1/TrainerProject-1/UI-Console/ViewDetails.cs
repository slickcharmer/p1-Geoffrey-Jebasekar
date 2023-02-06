//using Data;
using BusinessLogic;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    public class ViewDetails : IMenu
    {
        Trainer_Details trainer = new Trainer_Details();
        string f;

 
        IEFRepo repo = new TrainerEFRepo();
        public void Display()
        {
            
            Console.WriteLine("Press 0 to go back");
            Console.WriteLine("Press 1 to view details");
        }

        public string UserChoice()
        {
            string userInput=Console.ReadLine();
            switch(userInput) 
            {
                case "0":
                    return "UserDetails";
                case "1":
                    f = Login.PassEmail();

                    
                    var profDisp = repo.GetTrainer(f);
                    var eduDisp = repo.GetTrainersEducation(f);
                    var expDisp = repo.GetTrainersExperience(f);
                    var skillDisp = repo.GetTrainersSkills(f);
                    Console.WriteLine("Welcome " + f);
                    Console.WriteLine("\n");
                    Console.WriteLine("------------------Profile------------------");
                    Console.WriteLine("\n");
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
                    Console.WriteLine("\n");
                    Console.WriteLine("---------------Education---------------");
                    Console.WriteLine("\n");

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
                    Console.WriteLine("\n");
                    Console.WriteLine("---------------Experience---------------");
                    Console.WriteLine("\n");
                    foreach (var disp in expDisp)
                    {
                        Console.WriteLine($"Company name: {disp.companyName} " + "\n" +
                            $"Title: {disp.title} " + "\n" +
                            $"Location: {disp.location} " + "\n" +
                            $"Experience in years: {disp.experience}"
                            );
                        Console.WriteLine("=====================================================\n");

                    }
                    Console.WriteLine("\n");
                    Console.WriteLine("---------------Skills---------------");
                    Console.WriteLine("\n");
                    foreach (var disp in skillDisp)
                    {
                        Console.WriteLine($"Skill: {disp.skill} " + "\n" +
                            $"Profeciency: {disp.profeciencyInSkill}");

                        Console.WriteLine("=====================================================\n");
                    }
                    

                    Console.WriteLine("Press any key to go to User Details menu");
                    Console.ReadLine();
                    return "UserDetails";
                default:
                    Console.WriteLine("Please enter a valid response");
                    return "ViewDetails";



            }
        }
    }
}

