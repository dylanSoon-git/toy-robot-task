using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toy_Robot_Task;

namespace Toy_Robot_Test
{
    [TestClass]
    public class ToyRobotTest
    {
        [TestMethod]
        public void Should_Place_ToyRobot_With_Valid_Coordinates()
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
        public void Should_Not_Place_ToyRobot_With_Invalid_XAxis()
        {
            //arrange
            var robot = new Robot();
            //act
            robot.Place(7, 0, "NORTH");

            
            //assert
            Assert.(0, robot.PosX);
            Assert.AreEqual(0, robot.PosY);
            Assert.AreEqual("NORTH", robot.Direction);
        }
    }
}
