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
        IEnumerable<Trainer_Education> GetTrainersEducation(string email);
        IEnumerable<Trainer_Companies> GetTrainersCompanies(string email);
        IEnumerable<Trainer_Skills> GetTrainersSkills(string email);
        public TrainerDet.Education DeleteEducation(string email,string educationType);
        public TrainerDet.Company DeleteExperience(string email, string companyName, string title);
        public TrainerDet.Skill DeleteSkill(string email, string skill);
        public void DeleteAccount(string email);

        public TrainerDet.Education UpdateEducation(string email,string educationType);
        public TrainerDet.Education UpdateEducation(TrainerDet.Education _education);


    }
}
