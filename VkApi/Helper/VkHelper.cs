using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.DTO.Api.Helper.Time
{
    public static class TimeHelper
    {
        public static DateTime GetTime(string unixTime)
        {
            DateTime origin = new DateTime(1970, 1, 1, 3, 0, 0);
            double seconds = 0;
            try{
                seconds = double.Parse(unixTime, new CultureInfo("RU-ru"));
            }
            catch (Exception){
                Console.WriteLine("Wrong unix time format.");
            }

            origin = origin.AddSeconds(seconds);
            return origin;
        }
    }

}