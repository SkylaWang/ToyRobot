using System;
using ToyRobotApp.Model;
using ToyRobotApp.Model.Enum;
using ToyRobotApp.Server;
using Xunit;

namespace ToyRobotUnitTest
{
    public class CommandServerTest
    {
        CommandServer _server = new CommandServer();

        [Fact]
        public void PlaceCommandTest()
        {
            var result = _server.Place(TestData.PlaceCommandValidParam);
            Assert.Equal(1, result.X);
            Assert.Equal(1, result.Y);
            Assert.Equal(Direction.North, result.Direction);

            Assert.ThrowsAny<Exception>(()=>_server.Place(TestData.PlaceCommandOutOfBoundryParam));

            Assert.ThrowsAny<Exception>(() => _server.Place(TestData.PlaceCommandInValidParam));
        }

        [Fact]
        public void MoveCommandTest()
        {
            var robot = TestData.NullRobot();
            Assert.ThrowsAny<Exception>(() => _server.Move(robot));

            robot = TestData.MoveEastRobot();
            _server.Move(robot);
            Assert.Equal(2, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Direction.East, robot.Direction);

            robot = TestData.MoveNorthRobot();
            _server.Move(robot);
            Assert.Equal(1, robot.X);
            Assert.Equal(2, robot.Y);
            Assert.Equal(Direction.North, robot.Direction);

            robot = TestData.MoveSouthRobot();
            _server.Move(robot);
            Assert.Equal(1, robot.X);
            Assert.Equal(0, robot.Y);
            Assert.Equal(Direction.South, robot.Direction);

            robot = TestData.MoveWestRobot();
            _server.Move(robot);
            Assert.Equal(0, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Direction.West, robot.Direction);

            robot = TestData.MoveEastBoundryRobot();
            Assert.ThrowsAny<Exception>(() => _server.Move(robot));

            robot = TestData.MoveNorthBoundryRobot();
            Assert.ThrowsAny<Exception>(() => _server.Move(robot));

            robot = TestData.MoveSouthBoundryRobot();
            Assert.ThrowsAny<Exception>(() => _server.Move(robot));

            robot = TestData.MoveWestBoundryRobot();
            Assert.ThrowsAny<Exception>(() => _server.Move(robot));
        }

        [Fact]
        public void LeftCommandTest()
        {
            var robot = TestData.NullRobot();
            Assert.ThrowsAny<Exception>(() => _server.Left(robot));

            robot = TestData.MoveEastRobot();
            _server.Left(robot);
            Assert.Equal(1, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Direction.North, robot.Direction);

            robot = TestData.MoveNorthRobot();
            _server.Left(robot);
            Assert.Equal(1, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Direction.West, robot.Direction);

            robot = TestData.MoveSouthRobot();
            _server.Left(robot);
            Assert.Equal(1, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Direction.East, robot.Direction);

            robot = TestData.MoveWestRobot();
            _server.Left(robot);
            Assert.Equal(1, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Direction.South, robot.Direction);
        }

        [Fact]
        public void RightCommandTest()
        {
            var robot = TestData.NullRobot();
            Assert.ThrowsAny<Exception>(() => _server.Right(robot));

            robot = TestData.MoveEastRobot();
            _server.Right(robot);
            Assert.Equal(1, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Direction.South, robot.Direction);

            robot = TestData.MoveNorthRobot();
            _server.Right(robot);
            Assert.Equal(1, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Direction.East, robot.Direction);

            robot = TestData.MoveSouthRobot();
            _server.Right(robot);
            Assert.Equal(1, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Direction.West, robot.Direction);

            robot = TestData.MoveWestRobot();
            _server.Right(robot);
            Assert.Equal(1, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Direction.North, robot.Direction);
        }

        [Fact]
        public void ReportCommandTest()
        {
            var robot = TestData.NullRobot();
            Assert.ThrowsAny<Exception>(() => _server.Report(robot));

            robot = TestData.MoveEastRobot();
            var result = _server.Report(robot);
            Assert.Equal("Output: 1,1,EAST", result);
        }
    }
}
