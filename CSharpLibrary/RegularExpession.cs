using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Codepractice.CSharpLibrary
{
    public class RegularExpession
    {

        public static void RegMatch()
        {
            List<string> routeData = new List<string>();

            routeData.Add("ABC-LMN-DEF-MNO-JKL-LOO");
            routeData.Add("BYT-JKU-PLO-MNO");
            routeData.Add("DEF-BYT-IOT-POC-LOO");
            routeData.Add("LMN-RTX-PQS-JYY");
            routeData.Add("LMN-PQS-IRJ");

            // Lets use a regular expression to match a date string.
            string pattern = @"(^ABC|^LMN)(.)*(PQS|JKL)(.)*(LOO$|JYY$|IRJ$)";

            // The RegexOptions are optional to this call, we will go into more detail about
            // them below.

            foreach (string route in routeData)
            {
                Match result = Regex.Match(route, pattern, RegexOptions.IgnoreCase);

                if (result.Success)
                {
                    Console.WriteLine("Matched Route - " + route);
                }
            }
        }
    }
}
