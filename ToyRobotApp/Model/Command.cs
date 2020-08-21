using System;
using ToyRobotApp.Model.Enum;

namespace ToyRobotApp.Model
{
    public class Command
    {
        public CommandType CommandType { get; set; }
        public string[] Param { get; set; }
    }
}
