using System;
using ToyRobot.Model;

namespace ToyRobot.Server
{
    public interface ICommandServer
    {
        Robot Place(string[] param);
        void Move(Robot robot);
        void Left(Robot robot);
        void Right(Robot robot);
        string Report(Robot robot);
        Robot ExecuteCommand(string commandLine, Robot robot);
    }
}
