using EntityLayer.Entities;
using Models;
using TrainerDet=EntityLayer.Entities;
namespace BusinessLogic
{
    public class Mapper
    {
        public Trainer_Signup MapTrainerSignup(TrainerDet.Signup signup)
        {
            return new Trainer_Signup()
            {
                emailId = signup.EmailId,
                password= signup.Password,
                firstname = signup.Firstname,
                lastname = signup.Lastname,
                age= signup.Age,
                phoneno = signup.Phoneno,
                city = signup.City,
               

            };
        }
        public Trainer_Login MapTrainerLogin(TrainerDet.Login login)
        {
            Trainer_Login trainer_Login = new Trainer_Login();
            trainer_Login.emailId = login.Emailid;
            trainer_Login.password = login.Password;
            
            return trainer_Login;
            
        }
        public Trainer_Education MapTrainerEducation(TrainerDet.Education education)
        {
            return new Trainer_Education()
            {
                id = education.Id,
                educationType = education.EducationType,
                instituteName = education.InstituteName,
                stream = education.Stream,
                startYear = education.StartYear,
                endYear = education.EndYear,
                percentage = education.Percentage,
                emailid = education.Emailid
                

            };
        }
        public Trainer_Companies MapTrainerCompanies(TrainerDet.Company company)
        {
            return new Trainer_Companies()
            {
                id = company.Id,
                emailid = company.Emailid,
                companyName = company.CompanyName,
                title = company.Title,
                location = company.Location,
                experience= company.Experience,
                
            };
        }
        public Trainer_Skills MapTrainerSkills(TrainerDet.Skill skill)
        {
            return new Trainer_Skills()
            {
                id = skill.Id,
                emailid = skill.Emailid,
                skill = skill.Skill1,
                profeciencyInSkill = skill.Profeciency,


            };
        }


        public TrainerDet.Signup MapSignup(Trainer_Signup _signup )
        {
            return new TrainerDet.Signup()
            {
                Firstname = _signup.firstname,
                Lastname = _signup.lastname,
                EmailId = _signup.emailId,
                Password = _signup.password,
                Phoneno = _signup.phoneno,
                Age = _signup.age,
                City = _signup.city

            };
        }

        public TrainerDet.Login MapLogin(Trainer_Login _login)
        {
            return new TrainerDet.Login()
            {
                Emailid = _login.emailId,
                Password = _login.password
            };
        }


        public TrainerDet.Education MapEducation(Trainer_Education _education)
        {
            return new TrainerDet.Education()
            {
                Emailid = _education.emailid,
                EducationType = _education.educationType,
                InstituteName = _education.instituteName,
                Stream = _education.stream,
                StartYear = _education.startYear,
                EndYear = _education.endYear,
                Percentage = _education.percentage
            };
        }
        public TrainerDet.Company MapCompany(Trainer_Companies _company)
        {
            return new TrainerDet.Company()
            {
                Emailid = _company.emailid,
                CompanyName = _company.companyName,
                Title = _company.title,
                Location = _company.location,
                Experience = _company.experience
                

            };
        }
        public TrainerDet.Skill MapSkill(Trainer_Skills _skill)
        {
            return new TrainerDet.Skill()
            {
                Emailid = _skill.emailid,
                Skill1 = _skill.skill,
                Profeciency = _skill.profeciencyInSkill,

            };
        }

       
        public TrainerDet.Education MapEditEducation(Trainer_Education _education)
        {
            return new TrainerDet.Education()
            {
                Id = _education.id,
                Emailid = _education.emailid,
                EducationType = _education.educationType,
                InstituteName = _education.instituteName,
                Stream = _education.stream,
                StartYear = _education.startYear,
                EndYear = _education.endYear,
                Percentage = _education.percentage
            };
        }
        public TrainerDet.Company MapEditCompany(Trainer_Companies _company)
        {
            return new TrainerDet.Company()
            {
                Id = _company.id,
                Emailid = _company.emailid,
                CompanyName = _company.companyName,
                Title = _company.title,
                Location = _company.location,
                Experience = _company.experience


            };
        }
        public TrainerDet.Skill MapEditSkill(Trainer_Skills _skills)
        {
            return new TrainerDet.Skill()
            {
                Id = _skills.id,
                Emailid = _skills.emailid,
                Skill1 = _skills.skill,
                Profeciency = _skills.profeciencyInSkill


            };
        }

        public TrainerDet.Signup MapEditProfile(Trainer_Signup _signup)
        {
            return new TrainerDet.Signup()
            {
                EmailId = _signup.emailId,
                Password = _signup.password,
                Firstname = _signup.firstname,
                Lastname = _signup.lastname,
                Phoneno = _signup.phoneno,
                Age = _signup.age,
                City = _signup.city
             
                



            };
        }
    }
}