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
            repo.DeleteAccount(email);
        }

        public void DeleteEducation(string email,string educationType)
        {

            repo.DeleteEducation(email, educationType);
        }

        public void DeleteExperience(string email, string companyName, string title)
        {
            repo.DeleteExperience(email, companyName, title);
        }

        public void DeleteSkill(string email, string skillName)
        {
            repo.DeleteSkill(email, skillName);
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

        public void UpdateEducation(Trainer_Education education,string email,string educationtype)
        {
            var edu = repo.UpdateEducation(email, educationtype);
            if (edu != null) 
            {
                if((education.educationType != null && education.educationType != "string") && edu.EducationType != education.educationType)
                {
                    edu.EducationType = education.educationType;
                }
                if((education.instituteName != null && education.instituteName != "string") && edu.InstituteName != education.instituteName)
                {
                    edu.InstituteName = education.instituteName;
                }
                if((education.stream!=null && education.stream!="string") && edu.Stream!=education.stream)
                {
                    edu.Stream = education.stream;
                }
                if((education.startYear!=null && education.startYear!="string") && edu.StartYear!=education.startYear)
                {
                    edu.StartYear = education.startYear;

                }
                if ((education.endYear != null && education.endYear != "string") && edu.EndYear != education.endYear)
                {
                    edu.EndYear = education.endYear;

                }

                if ((education.percentage != null && education.percentage != "string") && edu.Percentage != education.percentage)
                {
                    edu.Percentage = education.percentage;

                }
            }
            
            //edu.Emailid = email;
            repo.UpdateEducation(edu);
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
