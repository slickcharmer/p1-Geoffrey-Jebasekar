using System.Text.RegularExpressions;
namespace Data
{
    public class Trainer_Signup
    {
        //private string password;
        //public int id;
        //private string phoneno;
        //private string password;
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string emailId { get; set; }

        public string password
        {
            get;
            set;
            
                //password = value;
        }
        public string phoneno
        {
            get;

            //return phoneno;

            set;
            
                /*string pattern = @"[6-9]\d{9}";
                var isCorrect = Regex.IsMatch(phoneno, pattern);
                if (isCorrect)
                {
                    phoneno = value;
                }
                else
                {
                    throw new InvalidDataException("Please add a mobile no which has only 10 digits and no symbols or extensions in between");
                }*/


            
        }
        public int age { get; set; }
        public string city { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
        public string GetTrainer()
        {
            return $@"
               First Name:{firstname},Last Name:{lastname},Email:{emailId},Phone Number:{phoneno},Age:{age},City:{city} 
               ";

        }
    }
    public class Trainer_Login
    {
        //public int id;
        public string emailId { get; set; }
        //private string password { get; set; }
        public string password
        {
            get;



            set;
               
            
        }


    }
    public class Trainer_Education
    {
        //public int id;
        public string emailid { get; set; }
        public string educationType { get; set; }
        public string instituteName { get; set; }
        public string stream { get; set; }
        public string startYear { get; set; }
        public string endYear { get; set; }
        public string percentage { get; set; }

    }
    public class Trainer_Companies
    {
        //public int id;
        public string emailid { get; set; }
        public string companyName { get; set; }
        public string title { get; set; }
        public string industry { get; set; }
        public string employementType { get; set; }
        public string location { get; set; }
        public string startYear { get; set; }
        public string endYear { get; set; }

    }
    public class Trainer_Skills
    {
        //public int id;
        public string emailid { get; set; }
        public string skill { get; set; }
        //Regex rx = new Regex(@"[1-5]");
        public int profeciencyInSkill
        {
            get
            {
                return profeciencyInSkill;

            }
            set
            {
                if (profeciencyInSkill >= 1 && profeciencyInSkill <= 5)
                {
                    profeciencyInSkill = value;
                }
                else
                {
                    throw new InvalidDataException("Profeciency should only contain value between 1 to 5");
                }


            }
        }
    }
    

}