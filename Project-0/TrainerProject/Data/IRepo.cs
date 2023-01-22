using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepo
    {
        Trainer_Signup Add(Trainer_Signup signup);
     
        Trainer_Login AddL(Trainer_Login login);
        Trainer_Education AddE(Trainer_Education education);
        Trainer_Companies AddC(Trainer_Companies companies);
        Trainer_Skills AddSk(Trainer_Skills skills);
          
        List<Trainer_Signup> GetAllTrainers();
        List<Trainer_Signup> GetSpecificTrainer(string email);
        List<Trainer_Login> GetAllTrainersLogin();
        List<Trainer_Education> GetTrainersEducation(string emailid);
        List<Trainer_Companies> GetTrainersCompanies(string emailid);
        List<Trainer_Skills> GetTrainersSkills(string emailid);

        

        Trainer_Education GetSpecificTrainersEducation(string emailid, string instituteName);
        List<Trainer_Companies> GetSpecificTrainersCompanies(string emailid);
        List<Trainer_Skills> GetSpecificTrainersSkills(string emailid);


        ArrayList ViewDetails(string email);
        List<Trainer_Details> ViewDetailsDisconnected(string email);




        void DeleteAcount();
        void DeleteSkill(string skill);
        void DeleteEducation(string education);
        void DeleteExperience(string experience);
        

        

        

        int IsValidLogin(string emailid);
    }
}
