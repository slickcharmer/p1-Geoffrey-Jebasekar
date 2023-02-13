using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerDet = EntityLayer.Entities;
using Models;

namespace EntityLayer
{
    public interface IEFRepo
    {
        public void Add(TrainerDet.Signup signup);
        public List<Trainer_Signup> GetAllTrainers();
        public void AddL(TrainerDet.Login login);
        public void AddE(TrainerDet.Education education);
        public void AddC(TrainerDet.Company experience);
        public void AddSk(TrainerDet.Skill skill);
        public IEnumerable<Trainer_Signup> GetTrainerByAge(int age);
        public IEnumerable<Trainer_Signup> GetTrainerByLocation(string location);
        IEnumerable<Trainer_Education> GetTrainersEducation(string email);
        IEnumerable<Trainer_Companies> GetTrainersCompanies(string email);
        IEnumerable<Trainer_Skills> GetTrainersSkills(string email);
        public TrainerDet.Education DeleteEducation(string email,string educationType);
        public TrainerDet.Company DeleteExperience(string email, string companyName, string title);
        public TrainerDet.Skill DeleteSkill(string email, string skill);
        public void DeleteAccount(string email);

        public TrainerDet.Education UpdateEducation(string email,string educationType);
        public TrainerDet.Education UpdateEducation(TrainerDet.Education _education);
        public TrainerDet.Company UpdateExperience(string email, string companyName, string title);
        public TrainerDet.Company UpdateExperience(TrainerDet.Company _experience);
        public TrainerDet.Skill UpdateSkill(string email, string skill);
        public TrainerDet.Skill UpdateSkill(TrainerDet.Skill _skill);
        public TrainerDet.Signup UpdateProfile(string email);
        public TrainerDet.Signup UpdateProfile(TrainerDet.Signup _signup);


    }
}
