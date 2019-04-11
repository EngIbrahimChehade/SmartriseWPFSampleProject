namespace WPFSampleProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;

    /// <summary>
    /// DataValidation class 
    /// </summary>
    public static class DataValidation
    {
        public static bool IsValidEmail(string email)
        {
            if (email?.Length < 11)
                return false;
            return new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").Match(email).Success;
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            return new Regex(@"^(([+][(]?[0-9]{1,3}[)]?)|([(]?[0-9]{4}[)]?))\s*[)]?[-\s\.]?[(]?[0-9]{1,3}[)]?([-\s\.]?[0-9]{3})([-\s\.]?[0-9]{3,4})$").Match(phoneNumber).Success;
        }

        public static bool IsValidName(string name)
        {
            return new Regex(@"^([a-z\sA-Z]{4,})$").Match(name).Success;
        }
    }
}