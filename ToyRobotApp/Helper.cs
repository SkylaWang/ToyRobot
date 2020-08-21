using System;
using System.Text.RegularExpressions;
using ToyRobotApp.Model.Enum;

namespace ToyRobotApp
{
    public static class Helper
    {
        public static T PraseStringToEmun<T>(string command) where T:struct
        {
            //don't want numeric value be prase to Enum
            Regex r = new Regex(@"^[0-9]+$");
            if (r.IsMatch(command))
            {
                throw new Exception();
            }

            //format input string to capital letter in uppercase and rest in lowercase
            command = command.Substring(0, 1).ToUpper() + command.Substring(1).ToLower();

            Enum.TryParse<T>(command, out T result);
            return result;
        }
    }
}
