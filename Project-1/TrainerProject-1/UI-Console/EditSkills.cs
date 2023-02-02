//using Data;
using BusinessLogic;
using EntityLayer.Entities;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    public class EditSkills 
    {
        static string conStr = "Server=tcp:geff29-db-server.database.windows.net,1433;Initial Catalog=TrainerProject;Persist Security Info=False;User ID=Geff;Password=Geoffrey2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public EditSkills(string emailid)
        {
            TutorAppContext context= new TutorAppContext();
            Trainer_Skills skills = new Trainer_Skills();
            IEFRepo repo = new TrainerEFRepo();
            bool repeat = false;
            Console.WriteLine("Enter the Skill name which details which you want to edit");
            string skill = Console.ReadLine();
            string query = $"select skill,Profeciency from Skills where emailid='{emailid}' and skill='{skill}'";
            var editSkill = context.Skills;
            var editSkillDet = from sk in editSkill
                               where sk.Emailid == emailid && sk.Skill1 == skill
                               select sk;
            

            
            if(!editSkillDet.IsNullOrEmpty())
            {
                foreach(var skil in editSkillDet)
                {
                    skills.id = skil.Id;
                    skills.skill = skil.Skill1;
                    skills.profeciencyInSkill = skil.Profeciency;
                }
                repeat = true;
                

            }
            else
            {
                Console.WriteLine(@"The skill you entered doesn't exist in your profile");
            }
            
            while(repeat)
            {
                Console.Clear();
                Console.WriteLine("Hey---------------------------"+emailid);
                Console.WriteLine("Verify your updation in skills");
                Console.WriteLine("[3] Profeciency in SKill - " + skills.profeciencyInSkill);
                Console.WriteLine("[2] Skill name - " + skills.skill);
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
                        //connection.Open();
                        //string query_1 = $"update Skills set skill='{skills.skill}',Profeciency='{skills.profeciencyInSkill}' where emailid='{emailid}' and skill='{skill}'";
                        skills.emailid = emailid;
                        repo.UpdateSkill(skills);
                        repeat = false;
                        break;
                    case "2":
                        Console.WriteLine("Enter your new skill");
                        skills.skill = Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Enter your new profeciency in skill");
                        skills.profeciencyInSkill = Convert.ToInt32(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Enter a valid response");
                        break;
            

                }
            }
        }
    }
}
