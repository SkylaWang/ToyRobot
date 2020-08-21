using System;
using System.Text;
using ToyRobotApp.Model;
using ToyRobotApp.Model.Enum;

namespace ToyRobotApp.Server
{
    public class CommandServer : ICommandServer
    {
        //PLACE command
        public Robot Place(string[] param)
        {
            Robot result = new Robot()
            {
                X = Int32.Parse(param[0]),
                Y = Int32.Parse(param[1]),
                Direction = Helper.PraseStringToEmun<Direction>(param[2])
            };

            return result;
        }

        //MOVE command
        public void Move(Robot robot)
        {
            switch (robot.Direction)
            {
                case Direction.North:
                    robot.Y++;
                    break;
                case Direction.South:
                    robot.Y--;
                    break;
                case Direction.East:
                    robot.X++;
                    break;
                case Direction.West:
                    robot.X--;
                    break;
                default: break;
            }
            
        }

        //LEFT command
        public void Left(Robot robot)
        {
            switch (robot.Direction)
            {
                case Direction.North:
                    robot.Direction = Direction.West;
                    break;
                case Direction.South:
                    robot.Direction = Direction.East;
                    break;
                case Direction.East:
                    robot.Direction = Direction.North;
                    break;
                case Direction.West:
                    robot.Direction = Direction.South;
                    break;
                default: break;
            }
        }

        //RIGHT command
        public void Right(Robot robot)
        {
            switch (robot.Direction)
            {
                case Direction.North:
                    robot.Direction = Direction.East;
                    break;
                case Direction.South:
                    robot.Direction = Direction.West;
                    break;
                case Direction.East:
                    robot.Direction = Direction.South;
                    break;
                case Direction.West:
                    robot.Direction = Direction.North;
                    break;
                default: break;
            }
        }

        //REPORT command
        public string Report(Robot robot)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Output: ");
            builder.Append(robot.X);
            builder.Append(",");
            builder.Append(robot.Y);
            builder.Append(",");
            builder.Append(robot.Direction.ToString("g").ToUpper());
            return builder.ToString();
        }
    }
}
