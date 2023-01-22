using System.Text.RegularExpressions;
namespace Data
{
    public class Trainer_Signup
    {
        
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string emailId { get; set; }

        public string password
        {
            get;
            set;

            
        }
        public string phoneno
        {
            get;

            

            set;

            



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
        public string GetSpecificTrainer()
        {
            return $@"
------------------------------------------------------------------------------------------------------------
               First Name:{firstname},Last Name:{lastname},Phone Number:{phoneno},Age:{age},City:{city}
------------------------------------------------------------------------------------------------------------
               ";

        }
    }
    public class Trainer_Login
    {
        
        public string emailId { get; set; }
        
        public string password
        {
            get;



            set;


        }



    }
    public class Trainer_Education
    {
        
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
        
        public string emailid { get; set; }
        public string skill { get; set; }
        
        public int profeciencyInSkill
        {
            get; set;
        }
    }

    public class Trainer_Details
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string emailid
        {
            get;
            set;
        }
        public int age { get; set; }
        public string educationType { get; set; }
        public string instituteName { get; set; }
        public string stream { get; set; }
        public string percentage { get; set; }
        public string companyName { get; set; }
        public string title { get; set; }
        public string industry { get; set; }
        public string location { get; set; }
        public string skill { get; set; }
        public int profeciencyInSkill
        {
            get; set;
        }
        public string TrainerDetails()
        {
            return @$"

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
First Name: {firstname}, Last Name: {lastname}, EmailId: {emailid}, Age: {age}, Education Type: {educationType}, Institute Name: {instituteName}, Stream: {stream}, Percentage: {percentage}, Company Name: {companyName}, Title: {title}, Industry: {industry}, Location: {location}, Skill: {skill}, Profeciency in skill: {profeciencyInSkill}
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ";
        }
            
        

    }

}