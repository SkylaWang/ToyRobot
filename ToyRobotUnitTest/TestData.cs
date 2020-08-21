using System;
using ToyRobotApp.Model;
using ToyRobotApp.Model.Enum;

namespace ToyRobotUnitTest
{
    public static class TestData
    {
        public static string[] PlaceCommandValidParam = { "1", "1", "north" };
        public static string[] PlaceCommandInValidParam = { "1", "1"};

        public static Robot NullRobot() { return null; }

        public static Robot MoveSouthRobot()
        {
            return new Robot()
            {
                X = 1,
                Y = 1,
                Direction = Direction.South
            };
        }

        public static Robot MoveWestRobot()
        {
            return new Robot()
            {
                X = 1,
                Y = 1,
                Direction = Direction.West
            };
        }

        public static Robot MoveEastRobot()
        {
            return new Robot()
            {
                X = 1,
                Y = 1,
                Direction = Direction.East
            };
        }


        public static Robot MoveNorthRobot()
        {
            return new Robot()
            {
                X = 1,
                Y = 1,
                Direction = Direction.North
            };
        }

    }
}
