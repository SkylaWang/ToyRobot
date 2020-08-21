using System;
using ToyRobotApp.Model.Enum;

namespace ToyRobotApp
{
    public static class Helper
    {
        public static Direction PraseStringToDirection(string direction)
        {
            Direction result;

            //format input string to capital letter in uppercase and rest in lowercase
            direction = direction.Substring(0,1).ToUpper() + direction.Substring(1).ToLower();

            Enum.TryParse<Direction>(direction, out result);
            return result;
        }

        public static Command PraseStringToCommand(string command)
        {
            Command result;

            //format input string to capital letter in uppercase and rest in lowercase
            command = command.Substring(0, 1).ToUpper() + command.Substring(1).ToLower();

            Enum.TryParse<Command>(command, out result);
            return result;
        }


    }
}
