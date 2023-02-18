using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using TrainerDet = EntityLayer.Entities;
namespace BusinessLogic
{
    public interface ILogic
    {
        public bool ForgotPassword(string email, string phoneno);

        void UpdatePass(string email, string password);
        public void UpdateSignup(Trainer_Signup signup);

        public void UpdateLogin(Trainer_Login login);
        bool IsValidLogin(string emailid);
        public List<Trainer_Details> ViewDetails(string email);
        public List<Trainer_Signup> GetAllTrainers();

        public TrainerDet.Signup Add(Trainer_Signup signup);
        public void AddSignupLogin(Trainer_Signup signup, Trainer_Login login);

        public void AddL(Trainer_Login login);
        public void AddE(Trainer_Education education);
        public void AddC(Trainer_Companies companies);
        public void AddSk(Trainer_Skills skills);

        IEnumerable<Trainer_Education> GetTrainersEducation(string emailid);
        IEnumerable<Trainer_Companies> GetTrainersExperience(string emailid);
        IEnumerable<Trainer_Skills> GetTrainersSkills(string emailid);
        IEnumerable<Trainer_Signup> GetTrainer(string emailid);
        IEnumerable<Trainer_Signup> GetTrainersByAge( int age);
        IEnumerable<Trainer_Signup> GetTrainersByLocation(string location);
        // List<Trainer_Education> GetTrainersEducation(string emailid,string instituteName);

        

        public void UpdateEducation(Trainer_Education education,string email,string educationType);
        public void UpdateExperience(Trainer_Companies experience, string email, string companyName, string title );
        public void UpdateExperience(Trainer_Companies experience);
        public void UpdateSkill(Trainer_Skills skills, string email, string skill);
        public void UpdateProfile(Trainer_Signup signup, string email);
        public void DeleteEducation(string email,string educationType);
        public void DeleteExperience(string email, string companyName, string title);

        public void DeleteSkill(string email, string skillName);

        public void DeleteAccount(string email);

    }
}
