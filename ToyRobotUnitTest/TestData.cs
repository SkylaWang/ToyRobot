using System;
using ToyRobotApp.Model;
using ToyRobotApp.Model.Enum;

namespace ToyRobotUnitTest
{
    public static class TestData
    {
        public static string[] PlaceCommandValidParam = { "1", "1", "north" };
        public static string[] PlaceCommandOutOfBoundryParam = { "6", "1", "north" };
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

        public static Robot MoveSouthBoundryRobot()
        {
            return new Robot()
            {
                X = 1,
                Y = 0,
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


        public static Robot MoveWestBoundryRobot()
        {
            return new Robot()
            {
                X = 0,
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

        public static Robot MoveEastBoundryRobot()
        {
            return new Robot()
            {
                X = 5,
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

        public static Robot MoveNorthBoundryRobot()
        {
            return new Robot()
            {
                X = 1,
                Y = 5,
                Direction = Direction.North
            };
        }
    }
}
