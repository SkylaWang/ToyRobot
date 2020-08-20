using System;
using ToyRobot.Model;
using ToyRobot.Server;

namespace ToyRobot
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ICommandServer _commandServer = new CommandServer();

            Robot robot = null;
            bool exit = false;

            Console.WriteLine("Welcome to Toy Robot. Please input your commands or type EXIT to exit.");

            do
            {
                string command = Console.ReadLine();
                exit = command.ToLower() == "exit";
                robot = _commandServer.ExecuteCommand(command, robot);
            }
            while (!exit);
        }
    }
}
