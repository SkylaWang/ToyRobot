using System;
using ToyRobotApp.Model;
using ToyRobotApp.Model.Enum;
using ToyRobotApp.Server;

namespace ToyRobotApp
{
    class Program
    {
        static void Main(string[] args)
        {
           

            Robot robot = null;
            bool exit = false;

            Console.WriteLine("Welcome to Toy Robot. Please input your commands or type EXIT to exit.");

            do
            {
                string command = Console.ReadLine();
                exit = command.ToLower() == "exit";
                robot = ExecuteCommand(command, robot);
            }
            while (!exit);
        }


        //Translate command line to excute command
        private static Robot ExecuteCommand(string commandLine, Robot robot)
        {
            ICommandServer _commandServer = new CommandServer();

            Robot originRobot = robot == null ? null : new Robot()
            {
                X = robot.X,
                Y = robot.Y,
                Direction = robot.Direction
            };

            try
            {
                var cl = commandLine.Trim().Split(' ');
                Command command = Helper.PraseStringToCommand(cl[0]);

                switch (command)
                {
                    case Command.Place:
                        robot = _commandServer.Place(cl[1].Split(','));
                        break;
                    case Command.Left:
                        _commandServer.Left(robot);
                        break;
                    case Command.Move:
                        _commandServer.Move(robot);
                        break;
                    case Command.Right:
                        _commandServer.Right(robot);
                        break;
                    case Command.Report:
                        Console.WriteLine(_commandServer.Report(robot));
                        break;
                    default: break;
                }

                return robot;
            }
            catch
            {
                //if catch any error, revert back.
                return originRobot;
            }
        }
    }
}
