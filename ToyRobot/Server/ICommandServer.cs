using System;
using ToyRobot.Model;

namespace ToyRobot.Server
{
    public interface ICommandServer
    {
        Robot ExecuteCommand(string commandLine, Robot robot);
    }
}
