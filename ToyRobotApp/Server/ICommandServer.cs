using System;
using ToyRobotApp.Model;

namespace ToyRobotApp.Server
{
    public interface ICommandServer
    {
        Robot Place(string[] param);
        void Move(Robot robot);
        void Left(Robot robot);
        void Right(Robot robot);
        string Report(Robot robot);
    }
}
