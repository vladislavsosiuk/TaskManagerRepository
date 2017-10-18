using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CheckData
{
    public class Checking
    {
        public static bool CheckName(string name)
        {
            if (name != null)
            {
                //Цифры в имени должны отсуствоватть, от 3 до 11 символов
                try
                {
                    Regex rx = new Regex(@"^[a-zA-Z][a-zA-Z0-9]{3,11}$");
                    return rx.IsMatch(name);
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            return false;

        }
        public static bool CheckPass(string pass)
        {
            // от 6 до 15 символов
            if (pass != null)
            {
                
                    try
                    {
                        Regex rx = new Regex(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{6,15})$");
                        return rx.IsMatch(pass);
                    }
                    catch (FormatException)
                    {
                        return false;
                    }
             }
                return false;
        }
        public static bool CheckEmailAddress(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                try
                {
                    Regex rx = new Regex(
                @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
                    return rx.IsMatch(email);
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
