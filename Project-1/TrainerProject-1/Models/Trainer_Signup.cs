namespace Models
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
---------------------------------------------------------------------------------------------------------
 First Name:{firstname},Last Name:{lastname},Email:{emailId},Phone Number:{phoneno},Age:{age},City:{city}
---------------------------------------------------------------------------------------------------------
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
}