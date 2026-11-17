using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD.Classes
{
    public class clsValidatoin
    {

        public static bool ValidateEmail(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }

        public static bool ValidateInteger(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number) || ValidateFloat(Number));
        }

        //public  static bool ValidateUserName(string Name)
        //{
        //    DataTable UsersnameTable = ClsUser.GetAllUsersName();
        //    DataTable PlayersnameTable = ClsPlayers.GetAllPlayersName();

        //    foreach (DataRow row in UsersnameTable.Rows)
        //    {
        //        string koko=row["UserName"].ToString();
        //        if (row["UserName"].ToString().ToLower() == Name.ToLower())
        //            return false;

        //    }

        //    foreach (DataRow row in PlayersnameTable.Rows)
        //    {
        //        if (row["PlayerName"].ToString().ToLower() == Name.ToLower())
        //            return false;

        //    }

        //    return true;
        //}

    }
}
