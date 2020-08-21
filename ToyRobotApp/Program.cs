﻿using System;
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

            Console.WriteLine("Welcome to Toy Robot. Please input your commands.");

            do
            {
                //translate input  to command
                Command command = PraseInputToCommand();
                robot = ExecuteCommand(command, robot);
            }
            while (true);
        }


        //Translate command line to excute command
        private static Robot ExecuteCommand(Command command, Robot robot)
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
                switch (command.CommandType)
                {
                    case CommandType.Place:
                        robot = _commandServer.Place(command.Param);
                        //Check if robot is placed out of the rang of table
                        CheckIsFallFromTable(robot);
                        break;
                    case CommandType.Left:
                        _commandServer.Left(robot);
                        break;
                    case CommandType.Move:
                        _commandServer.Move(robot);
                        //Check if robot is moved out of the rang of table
                        CheckIsFallFromTable(robot);
                        break;
                    case CommandType.Right:
                        _commandServer.Right(robot);
                        break;
                    case CommandType.Report:
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

        //translate input to command 
        private static Command PraseInputToCommand()
        {
            try
            {
                Command command = new Command();
                string commandLine = Console.ReadLine();
                var cl = commandLine.Trim().Split(' ');

                command.CommandType = Helper.PraseStringToEmun<CommandType>(cl[0]);

                if (command.CommandType == CommandType.Place)
                {
                    command.Param = cl[1].Split(',');
                }

                return command;
            }
            catch
            {
                return new Command();
            }
        }


        //Check if robot is moved or placed out of the rang of table
        private static void CheckIsFallFromTable(Robot robot)
        {
            if (robot.X > Constants.RANGE_X_MAX || robot.Y > Constants.RANGE_Y_MAX ||
               robot.X < Constants.RANGE_X_MIN || robot.Y < Constants.RANGE_Y_MIN)
            {
                throw new Exception();
            }
        }
    }
}
