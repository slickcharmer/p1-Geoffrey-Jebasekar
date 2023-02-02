using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IEFRepo
    {



       

        public bool ForgotPassword(string email, string phoneno);

        void UpdatePass(string email, string password);
        int IsValidLogin(string emailid);
        public List<Trainer_Details> ViewDetails(string email);
        public List<Trainer_Signup> GetAllTrainers();

        public void Add(Trainer_Signup signup);

        public void AddL(Trainer_Login login);
        public void AddE(Trainer_Education education);
        public void AddC(Trainer_Companies companies);
        public void AddSk(Trainer_Skills skills);

        List<Trainer_Education> GetTrainersEducation(string emailid);
       // List<Trainer_Education> GetTrainersEducation(string emailid,string instituteName);

        Trainer_Education  GetTrainersEducation(string emailid, string instituteName);

        public void UpdateEducation(Trainer_Education education);



    }
}
