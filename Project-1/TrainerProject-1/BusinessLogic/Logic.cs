using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entities;
using Microsoft.Data.SqlClient;
using TrainerDet = EntityLayer.Entities;
using Det = EntityLayer;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
        Mapper map = new Mapper();

        Det.IEFRepo repo;

        public Logic(Det.IEFRepo _repo)
        {
            repo = _repo;
        }

        //Det.TrainerEFRepo repo = new Det.TrainerEFRepo();
        //TrainerDet.Signup _signup = new TrainerDet.Signup();
        public TrainerDet.Signup Add(Trainer_Signup signup)
        {

            
            repo.Add(map.MapSignup(signup));
            return map.MapSignup(signup);

        }
        public List<Trainer_Signup> GetAllTrainers()
        {
            return repo.GetAllTrainers();
        }
        public void AddSignupLogin(Trainer_Signup signup, Trainer_Login login)
        {
            repo.Add(map.MapSignup(signup));
            repo.AddL(map.MapLogin(login));
        }
        public void AddE(Trainer_Education education)
        {
            repo.AddE(map.MapEducation(education));
        }

        public void AddC(Trainer_Companies companies)
        {
            repo.AddC(map.MapCompany(companies));
        }

        IEnumerable<Trainer_Education> ILogic.GetTrainersEducation(string emailid)
        {
            return repo.GetTrainersEducation(emailid);
        }
        public IEnumerable<Trainer_Companies> GetTrainersExperience(string emailid)
        {
            return repo.GetTrainersCompanies(emailid);
        }
        public IEnumerable<Trainer_Skills> GetTrainersSkills(string emailid)
        {
            return repo.GetTrainersSkills(emailid);
        }

        public void AddL(Trainer_Login login)
        {
            throw new NotImplementedException();
        }

        public void AddSk(Trainer_Skills skills)
        {
            repo.AddSk(map.MapSkill(skills));
        }

        public void DeleteAccount(string email)
        {
            throw new NotImplementedException();
        }

        public void DeleteEducation(string email, string educationType)
        {
            throw new NotImplementedException();
        }

        public void DeleteExperience(string email, string companyName, string title)
        {
            throw new NotImplementedException();
        }

        public void DeleteSkill(string email, string skillName)
        {
            throw new NotImplementedException();
        }

        public bool ForgotPassword(string email, string phoneno)
        {
            throw new NotImplementedException();
        }

        

        public IEnumerable<Trainer_Signup> GetTrainer(string emailid)
        {
            throw new NotImplementedException();
        }

        public List<Trainer_Education> GetTrainersEducation(string emailid)
        {
            throw new NotImplementedException();
        }

        public Trainer_Education GetTrainersEducation(string emailid, string instituteName)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Trainer_Companies> GetTrainersExperience(string emailid)
        //{
        //    return 
        //}

        

        public int IsValidLogin(string emailid)
        {
            throw new NotImplementedException();
        }

        public void UpdateEducation(Trainer_Education education)
        {
            throw new NotImplementedException();
        }

        public void UpdateExperience(Trainer_Companies experience)
        {
            throw new NotImplementedException();
        }

        public void UpdateLogin(Trainer_Login login)
        {
            throw new NotImplementedException();
        }

        public void UpdatePass(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void UpdateProfile(Trainer_Signup signup)
        {
            throw new NotImplementedException();
        }

        public void UpdateSignup(Trainer_Signup signup)
        {
            throw new NotImplementedException();
        }

        public void UpdateSkill(Trainer_Skills skills)
        {
            throw new NotImplementedException();
        }

        public List<Trainer_Details> ViewDetails(string email)
        {
            throw new NotImplementedException();
        }

        
    }
}
