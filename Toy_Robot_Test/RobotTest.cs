using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toy_Robot_Task;

namespace Toy_Robot_Test
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void Should_Set_ToyRobot_Position_With_Coordinates()
        {
            //arrange
            var robot = new Robot();
            
            //act
            robot.Place(0, 0, "NORTH");
            
            //assert
            Assert.AreEqual(0, robot.PosX);
            Assert.AreEqual(0, robot.PosY);
            Assert.AreEqual("NORTH", robot.Direction);
        }

        [TestMethod]
        public void Should_Move_ToyRobot_North_One()
        {
            //arrange
            var robot = new Robot();
            
            //act
            robot.Place(0, 0, "NORTH");
            robot.MoveNorth();

            //assert
            Assert.AreEqual(0, robot.PosX);
            Assert.AreEqual(1, robot.PosY);
            Assert.AreEqual("NORTH", robot.Direction);
        }

        [TestMethod]
        public void Should_Move_ToyRobot_South_Three()
        {
            //arrange
            var robot = new Robot();

            //act
            robot.Place(0, 5, "SOUTH");
            robot.MoveSouth();
            robot.MoveSouth();
            robot.MoveSouth();

            //assert
            Assert.AreEqual(0, robot.PosX);
            Assert.AreEqual(2, robot.PosY);
            Assert.AreEqual("SOUTH", robot.Direction);
        }

        [TestMethod]
        public void Should_Not_Move_West_Due_To_Being_At_The_Edge()
        {
            //arrange
            var robot = new Robot();

            //act
            robot.Place(0, 4, "WEST");
            robot.MoveWest();

            //assert
            Assert.AreEqual(0, robot.PosX);
            Assert.AreEqual(4, robot.PosY);
            Assert.AreEqual("WEST", robot.Direction);
        }

        [TestMethod]
        public void Should_Change_Direction_To_The_Specified()
        {
            //arrange
            var robot = new Robot();

            //act
            robot.Place(0, 0, "NORTH");
            robot.ChangeDirection("EAST");

            //assert
            Assert.AreEqual("EAST", robot.Direction);
        }

        [TestMethod]
        public void Should_Be_In_Correct_Position_After_Multiple_Moves()
        {
            //arrange
            var robot = new Robot();

            //act
            robot.Place(0, 0, "NORTH");
            robot.MoveNorth();
            robot.MoveNorth();
            robot.ChangeDirection("EAST");
            robot.MoveEast();
            robot.MoveEast();
            robot.MoveEast();
            robot.ChangeDirection("SOUTH");

            //assert
            Assert.AreEqual(3, robot.PosX);
            Assert.AreEqual(2, robot.PosY);
            Assert.AreEqual("SOUTH", robot.Direction);
        }

    }
}
