using EntityLayer.Entities;

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
            throw new NotImplementedException();
        }

        public void UpdatePass(string email, string password)
        {
            throw new NotImplementedException();
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

        //public List<Trainer_Education> GetTrainersEducation(string emailid, string instituteName)
        //{
        //    var editEdu = context.Educations;
        //    var editEduDet = (
        //                    from edu in editEdu
        //                    where edu.Emailid == emailid && edu.InstituteName == instituteName
        //                    select new Trainer_Education()
        //                    {
        //                        educationType = edu.EducationType,
        //                        instituteName = edu.InstituteName,
        //                        stream = edu.Stream,
        //                        startYear = edu.StartYear,
        //                        endYear = edu.EndYear,
        //                        percentage = edu.Percentage
        //                    }
        //        );
        //    return editEduDet.ToList();
        //}

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
                context.Educations.Update(map.MapEducation(education));
                context.SaveChanges();
                Console.WriteLine("Changes are successfully added");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }

       
    }
}
