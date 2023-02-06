using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Validation
    {
        public bool Phone(string phone)
        {
            Regex r = new Regex(@"^[6-9]\d{9}$");




            if (r.IsMatch(phone))
            {

                return true;

            }
            else
            {

                return false;
            }



        }

        public bool Password(string pass)
        {
            Regex r = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            if (r.IsMatch(pass))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool Email(string email)
        {
            Regex r = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (r.IsMatch(email))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool Percentage(string percent)
        {
            Regex r = new Regex(@"^[0-9][0-9].?[0-9]?%$");
            if (r.IsMatch(percent))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
