using System;
using System.Text;
using ToyRobot.Model;
using ToyRobot.Model.Enum;

namespace ToyRobot.Server
{
    public class CommandServer : ICommandServer
    {
        //PLACE command
        public Robot Place(string[] param)
        {
            try
            {
                return new Robot()
                {
                    X = Int32.Parse(param[0]),
                    Y = Int32.Parse(param[1]),
                    Direction = Helper.PraseStringToDirection(param[2])
                };
            }
            catch
            {
                //invalid command parameter
                //skip the command
                return null;
            }
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

        //Translate command line entry to command structure
        public Robot ExecuteCommand(string commandLine, Robot robot)
        {
            Robot originRobot =  robot == null? null: new Robot()
            {
                X = robot.X,
                Y = robot.Y,
                Direction = robot.Direction
            };

            try
            {
                var cl = commandLine.Trim().Split(' ');
                Command command = Helper.PraseStringToCommand(cl[0]);

                if (cl.Length == 1 && robot != null)
                {
                    switch (command)
                    {
                        case Command.Left:
                            Left(robot);
                            break;
                        case Command.Move:
                            Move(robot);

                            //if new robot fall from the table, then move it back.
                            CheckIsFallFromTable(robot);
                            break;
                        case Command.Right:
                            Right(robot);
                            break;
                        case Command.Report:
                            Console.WriteLine(Report(robot));
                            break;
                        default:break;
                    }
                }
                if (cl.Length == 2 && command == Command.Place)
                {
                    robot = Place(cl[1].Split(','));

                    //if new robot fall from the table, then move it back.
                    CheckIsFallFromTable(robot);

                }
                return robot;
            }
            catch
            {
                //if catch any error, revert back.
                return originRobot;
            }
        }

        private void CheckIsFallFromTable(Robot robot)
        {
            if(robot.X > Constants.RANGE_X_MAX || robot.Y > Constants.RANGE_Y_MAX ||
               robot.X < Constants.RANGE_X_MIN || robot.Y < Constants.RANGE_Y_MIN)
            {
                throw new Exception();
            }
        }

    }
}
