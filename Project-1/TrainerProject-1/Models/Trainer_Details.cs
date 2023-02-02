using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
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
        
        public string location { get; set; }
        public string skill { get; set; }
        public int profeciencyInSkill
        {
            get; set;
        }
        public string TrainerDetails()
        {
            return @$"

----------------------------------------------------------------------------------------------------------------------------------------------------
First Name: {firstname}, Last Name: {lastname}, EmailId: {emailid}, Age: {age}, Education Type: {educationType}, Institute Name: {instituteName}, Stream: {stream}, Percentage: {percentage}, Company Name: {companyName}, Title: {title}, Location: {location}, Skill: {skill}, Profeciency in skill: {profeciencyInSkill}
----------------------------------------------------------------------------------------------------------------------------------------------------
            ";
        }
    }
}
