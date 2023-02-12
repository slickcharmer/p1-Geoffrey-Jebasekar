using EntityLayer.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TrainerEFRepo : IEFRepo
    {
        //static Trainer_Signup signup = new Trainer_Signup();
        //Trainer_Login login = new Trainer_Login();
        TutorAppContext context = new TutorAppContext();
        Mapper map = new Mapper();
        public List<Trainer_Details> ViewDetails(string email)
            
        {
            var signup = context.Signups;
            var education = context.Educations;
            var experience = context.Companies;
            var skills = context.Skills;
           
            var trainerDetails = (from tr in signup
                                  join ed in education on tr.EmailId equals ed.Emailid
                                  join ex in experience on ed.Emailid equals ex.Emailid
                                  join sk in skills on ex.Emailid equals sk.Emailid 
                                  where tr.EmailId == email
                                  select new Trainer_Details()
                                  {
                                      
                                      firstname = tr.Firstname,
                                      lastname = tr.Lastname,
                                      emailid = tr.EmailId,
                                      age = tr.Age,
                                      educationType = ed.EducationType,
                                      instituteName = ed.InstituteName,
                                      stream = ed.Stream,
                                      percentage = ed.Percentage,
                                      companyName = ex.CompanyName,
                                      title = ex.Title,
                                      location = ex.Location,
                                      skill = sk.Skill1,
                                      profeciencyInSkill = sk.Profeciency

                                  });
            
      
            return trainerDetails.ToList();
            
        }

        public List<Trainer_Signup> GetAllTrainers()
        {
            var signup = context.Signups;
            var trainerDet = (from tr in signup
                              select new Trainer_Signup()
                              {
                                  firstname = tr.Firstname,
                                  lastname = tr.Lastname,   
                                  emailId = tr.EmailId,
                                  age = tr.Age,
                                  phoneno = tr.Phoneno,
                                  city = tr.City




                               });
            return trainerDet.ToList();
        }

        
        public int IsValidLogin(string emailid)
        {
            var loginData = context.Logins;
            var query = loginData.FirstOrDefault(val=> val.Emailid == emailid);
            
            if(query!=null)
            {
                Console.WriteLine("Enter your password");
                var password = Console.ReadLine();
                if(query.Password == password)
                {
                    Console.WriteLine("Login Success");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    return 1;
                }
                else
                {
                    Console.WriteLine("\nEmail and password doesnt match");
                    Console.WriteLine("Try logging in again");
                    return 0;
                }
                
            }
            else
            {
                Console.WriteLine("Try again");
                return 2;
            }
            //throw new NotImplementedException();
        }





        public bool ForgotPassword(string email, string phoneno)
        {
            var forgot = context.Signups.Where(f => f.EmailId == email && f.Phoneno == phoneno).FirstOrDefault();
            
            
                if(forgot!=null)
                {
                    return true;
                }
                else
                {
                return false;
                   
                }

            
            


            
        }

        public void UpdatePass(string email, string password)
        {
            
            

            //var editProf = context.Signups;
            //var editProfDet = from tr in editProf
            //                  where tr.EmailId == email
            //                  select tr;
            //foreach (var prof in editProfDet)
            //{
            //    signup.emailId = prof.EmailId;
            //    signup.password = password;
            //    signup.firstname = prof.Firstname;
            //    signup.lastname = prof.Lastname;
            //    signup.phoneno = prof.Phoneno;
            //    signup.age = prof.Age;
            //    signup.city = prof.City;
            //}
            //var editProfLogin = context.Logins.Where(x => x.Emailid == email).FirstOrDefault();
            //login.emailId = editProfLogin.Emailid;
            ////login.password = editProfLogin.Password;
            
            //login.password = password;
            
            ////signup.password = password;
            //UpdateSignup(signup);
            //UpdateLogin(login);

        }

        public void Add(Trainer_Signup signup)
        {
            context.Signups.Add(map.MapSignup(signup));
            context.SaveChanges();
        }

        public void AddL(Trainer_Login login)
        {
            context.Logins.Add(map.MapLogin(login));
            context.SaveChanges();
        }

        public void AddE(Trainer_Education education)
        {
            context.Educations.Add(map.MapEducation(education));
            context.SaveChanges();
        }

        public void AddC(Trainer_Companies companies)
        {
            context.Companies.Add(map.MapCompany(companies));
            context.SaveChanges();
        }

        public void AddSk(Trainer_Skills skills)
        {
            context.Skills.Add(map.MapSkill(skills));
            context.SaveChanges();
           
        }

        public List<Trainer_Education> GetTrainersEducation(string emailid)
        {
            var editEdu = context.Educations;
            var editEduDet = (
                            from edu in editEdu
                            where edu.Emailid == emailid
                            select new Trainer_Education()
                            {
                                educationType = edu.EducationType,
                                instituteName = edu.InstituteName,
                                stream = edu.Stream,
                                startYear = edu.StartYear,
                                endYear = edu.EndYear,
                                percentage = edu.Percentage
                            }
                );
            return editEduDet.ToList();
        }

        public IEnumerable<Trainer_Companies> GetTrainersExperience(string emailid)
        {
            var editExp = context.Companies;
            var editExpDet = (
                                from exp in editExp
                                where exp.Emailid == emailid
                                select new Trainer_Companies()
                                {
                                    companyName = exp.CompanyName,
                                    title = exp.Title,
                                    location = exp.Location,
                                    experience = exp.Experience
                                }
                ) ;
            return editExpDet.ToList();
        }
        public IEnumerable<Trainer_Skills> GetTrainersSkills(string emailid)
        {
            var editSkill = context.Skills;
            var editSkillDet = (
                                from skills in editSkill
                                where skills.Emailid == emailid
                                select new Trainer_Skills()
                                {
                                    skill = skills.Skill1,
                                    profeciencyInSkill = skills.Profeciency
                                }
                );
            return editSkillDet.ToList();
            
        }
        public IEnumerable<Trainer_Signup> GetTrainer(string emailid)
        {
            var signup = context.Signups;
            var trainerDet = (from tr in signup
                              where tr.EmailId == emailid
                              select new Trainer_Signup()
                              {
                                  firstname = tr.Firstname,
                                  lastname = tr.Lastname,
                                  age = tr.Age,
                                  phoneno = tr.Phoneno,
                                  city = tr.City




                              });
            return trainerDet.ToList();
        }

       

        public Trainer_Education GetTrainersEducation(string emailid, string instituteName)
        {

            Trainer_Education education = new();
            var editEdu = context.Educations;
            var editEduDet = (
                                from edu in editEdu
                                where edu.Emailid == emailid && edu.InstituteName == instituteName
                                select new Trainer_Education()
                             );
            if (editEduDet != null)
            {
                foreach (var edu in editEdu)
                {
                    education.educationType = edu.EducationType;
                    education.instituteName = edu.InstituteName;
                    education.stream = edu.Stream;
                    education.startYear = edu.StartYear;
                    education.endYear = edu.EndYear;
                    education.percentage = edu.Percentage;
                }
            }
            else
            {
                Console.WriteLine("Entered institute name does not exist in your profile");
            }
            return education;


            
        }

        public void UpdateEducation(Trainer_Education education)
        {
            try
            {
                context.Educations.Update(map.MapEditEducation(education));
                context.SaveChanges();
                Console.WriteLine("Changes are successfully added");
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }

        public void UpdateExperience(Trainer_Companies experience)
        {
            try
            {
                context.Companies.Update(map.MapEditCompany(experience));
                context.SaveChanges();
                Console.WriteLine("Changes are successfully added");

            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void UpdateSkill(Trainer_Skills skills)
        {
            try
            {
                context.Skills.Update(map.MapEditSkill(skills));
                context.SaveChanges();
                Console.WriteLine("Changes are successfully added");

            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateProfile(Trainer_Signup signup)
        {
            try
            {
                context.Signups.Update(map.MapEditProfile(signup));
                context.SaveChanges();
                Console.WriteLine("Changes are successfully added");

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateSignup(Trainer_Signup signup)
        {
            try
            {
                context.Signups.Update(map.MapEditProfile(signup));
                context.SaveChanges();
                Console.WriteLine("Changes are successfully added");

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateLogin(Trainer_Login login)
        {
            try
            {
                context.Logins.Update(map.MapLogin(login));
                context.SaveChanges();
                Console.WriteLine("Changes are successfully added");

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteEducation(string email,string educationType)
        {
            var delete = context.Educations.Where(del => del.Emailid == email && del.EducationType == educationType).FirstOrDefault();
            try
            {
                if (delete != null)
                {
                    context.Educations.Remove(delete);
                    context.SaveChanges();
                    Console.WriteLine("Education deleted successfully");
                }

            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteExperience(string email, string companyName, string title)
        {
            var delete = context.Companies.Where(del => del.Emailid == email && del.CompanyName == companyName && del.Title == title).FirstOrDefault();
            try
            {
                if (delete != null)
                {
                    context.Companies.Remove(delete);
                    context.SaveChanges();
                    Console.WriteLine("Experience deleted successfully");
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Try deleting again");
            }
        }
        public void DeleteSkill(string email, string skillName)
        {
            var delete = context.Skills.Where(del => del.Emailid == email && del.Skill1 == skillName).FirstOrDefault();
            try
            {
                if (delete != null)
                {
                    context.Skills.Remove(delete);
                    context.SaveChanges();
                    Console.WriteLine("Skill deleted successfully");
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteAccount(string email)
        {
            var delete = context.Signups.Where(del => del.EmailId == email).FirstOrDefault();
            try
            {
                if (delete != null)
                {
                    context.Signups.Remove(delete);
                    context.SaveChanges();
                    Console.WriteLine("Account deleted successfully");
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void UpdateSignupPassword(Trainer_Login login)
        {
            EntityLayer.Entities.Signup _signup = new EntityLayer.Entities.Signup();
            Trainer_Signup signup = new Trainer_Signup();
            var editprof = context.Signups;
            var editprofdet = from tr in editprof
                              where tr.EmailId == login.emailId
                              select tr;
            foreach (var prof in editprofdet)
            {
                signup.emailId = prof.EmailId;
                signup.password = login.password;
                signup.firstname = prof.Firstname;
                signup.lastname = prof.Lastname;
                signup.phoneno = prof.Phoneno;
                signup.age = prof.Age;
                signup.city = prof.City;
            }
            context.Signups.Update(map.MapEditProfile(signup));
            context.SaveChanges();

        }
    }
}
