using System;
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
        List<Trainer_Login> GetAllTrainersLogin();
        List<Trainer_Education> GetAllTrainersEducation();
        List<Trainer_Companies> GetAllTrainersCompanies();
        List<Trainer_Skills> GetAllTrainersSkills();

        //string GetTrainer();

        int IsValidLogin(string emailid);
    }
}
