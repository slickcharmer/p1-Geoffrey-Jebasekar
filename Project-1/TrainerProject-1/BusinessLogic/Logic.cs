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
        public IEnumerable<Trainer_Signup> GetTrainersByAge(int age)
        {
            return repo.GetTrainerByAge(age);
        }

        public IEnumerable<Trainer_Signup> GetTrainersByLocation(string location)
        {
            return repo.GetTrainerByLocation(location);
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
        public void UpdateExperience(Trainer_Companies experience, string email, string companyName, string title)
        {
            var exp = repo.UpdateExperience(email, companyName, title);
            if (exp != null)
            {
                if ((experience.companyName != null && experience.companyName != "string") && exp.CompanyName != experience.companyName)
                {
                    exp.CompanyName = experience.companyName;
                }
                if ((experience.title != null && experience.title != "string") && exp.Title != experience.title)
                {
                    exp.Title = experience.title;
                }
                if ((experience.location != null && experience.location != "string") && exp.Location != experience.location)
                {
                    exp.Location = experience.location;
                }
                if (((experience.experience).ToString() != null && experience.experience != 0) && exp.Experience != experience.experience)
                {
                    exp.Experience = experience.experience;
                }
            }

            //edu.Emailid = email;
            repo.UpdateExperience(exp);
        }

        public void UpdateSkill(Trainer_Skills skills, string email, string skill)
        {
            var skill1 = repo.UpdateSkill(email, skill);
            if (skill1 != null)
            {
                if ((skills.skill != null && skills.skill != "string") &&  skill1.Skill1!= skills.skill)
                {
                    skill1.Skill1 = skills.skill;
                }
                if (((skills.profeciencyInSkill).ToString() != null && skills.profeciencyInSkill != 0) && skill1.Profeciency != skills.profeciencyInSkill)
                {
                    skill1.Profeciency = skills.profeciencyInSkill;
                }
                
            }

            //edu.Emailid = email;
            repo.UpdateSkill(skill1);
        }
        public void UpdateProfile(Trainer_Signup signup, string email)
        {
            var profile = repo.UpdateProfile(email);
            if (profile!=null)
            {
                if((signup.firstname!=null && signup.firstname!="string") && profile.Firstname!=signup.firstname)
                {
                    profile.Firstname = signup.firstname;
                }
                if ((signup.lastname != null && signup.lastname != "string") && profile.Lastname != signup.lastname)
                {
                    profile.Lastname = signup.lastname;
                }
                if ((signup.phoneno != null && signup.phoneno != "string") && profile.Phoneno != signup.phoneno)
                {
                    profile.Phoneno = signup.phoneno;
                }
                if (((signup.age).ToString() != null && signup.age != 0) && profile.Age != signup.age)
                {
                    profile.Age = signup.age;
                }
                if ((signup.city != null && signup.city != "string") && profile.City != signup.city)
                {
                    profile.City = signup.city;
                }
            }
            repo.UpdateProfile(profile);
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

        
        public void UpdateSignup(Trainer_Signup signup)
        {
            throw new NotImplementedException();
        }

        //public void UpdateSkill(Trainer_Skills skills, string email, string title)
        //{
            
        //}

        public List<Trainer_Details> ViewDetails(string email)
        {
            throw new NotImplementedException();
        }

        
    }
}
