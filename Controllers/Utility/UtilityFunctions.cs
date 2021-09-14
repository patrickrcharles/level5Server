using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Controllers.Utility
{
    public static class UtilityFunctions
    {
        // killer id, crime id, victimid, note id
        public static string GenerateCrimeId()
        {
            int length = 16;
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new System.Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            System.Diagnostics.Debug.WriteLine("stringChars : " + stringChars);

            string date = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            // killer id + utc date + randomstring
            var finalString = new String("killerid"+ date + stringChars);

            System.Diagnostics.Debug.WriteLine("finalString : "+ finalString);
            return finalString;
        }
    }
}
