using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toy_Robot_Task;

namespace Toy_Robot_Test
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void Should_Place_Robot_Using_Command_Coordinates()
        {
            //arrange
            var robot = new Robot();
            var command = new Command();

            //act
            command.ReadCommand(robot, "PLACE 0,0,SOUTH");

            //assert
            Assert.AreEqual(0, robot.PosX);
            Assert.AreEqual(0, robot.PosY);
            Assert.AreEqual("SOUTH", robot.Direction);
        }

        [TestMethod]
        public void Should_Not_Place_Robot_Due_To_Invalid_XAxis()
        {
            //arrange
            var robot = new Robot();
            var command = new Command();

            //act
            command.ReadCommand(robot, "PLACE 8,0,SOUTH");

            //assert
            Assert.AreEqual(0, robot.PosX);
            Assert.AreEqual(0, robot.PosY);
            Assert.AreEqual(null, robot.Direction);
        }

        [TestMethod]
        public void Should_Not_Place_Robot_Due_To_Invalid_YAxis()
        {
            //arrange
            var robot = new Robot();
            var command = new Command();

            //act
            command.ReadCommand(robot, "PLACE 0,8,SOUTH");

            //assert
            Assert.AreEqual(0, robot.PosX);
            Assert.AreEqual(0, robot.PosY);
            Assert.AreEqual(null, robot.Direction);
        }

        [TestMethod]
        public void Should_Not_Place_Robot_Due_To_Invalid_Direction()
        {
            //arrange
            var robot = new Robot();
            var command = new Command();

            //act
            command.ReadCommand(robot, "PLACE 0,0,FAKE");

            //assert
            Assert.AreEqual(0, robot.PosX);
            Assert.AreEqual(0, robot.PosY);
            Assert.AreEqual(null, robot.Direction);
        }

        [TestMethod]
        public void Should_Move_Robot_Position_Based_On_Command()
        {
            //arrange
            var robot = new Robot();
            var command = new Command();

            //act
            command.ReadCommand(robot, "PLACE 2,3,WEST");
            command.ReadCommand(robot, "MOVE");

            //assert
            Assert.AreEqual(1, robot.PosX);
            Assert.AreEqual(3, robot.PosY);
            Assert.AreEqual("WEST", robot.Direction);
        }

        [TestMethod]
        public void Should_Not_Move_Robot_Position_Due_To_Edge()
        {
            //arrange
            var robot = new Robot();
            var command = new Command();

            //act
            command.ReadCommand(robot, "PLACE 1,5,NORTH");
            command.ReadCommand(robot, "MOVE");

            //assert
            Assert.AreEqual(1, robot.PosX);
            Assert.AreEqual(5, robot.PosY);
            Assert.AreEqual("NORTH", robot.Direction);
        }

        [TestMethod]
        public void Should_Change_Direction_To_The_Right()
        {
            //arrange
            var robot = new Robot();
            var command = new Command();

            //act
            command.ReadCommand(robot, "PLACE 1,1,NORTH");
            command.ReadCommand(robot, "RIGHT");

            //assert
            Assert.AreEqual("EAST", robot.Direction);
        }

        [TestMethod]
        public void Should_Change_Direction_To_The_LEFT()
        {
            //arrange
            var robot = new Robot();
            var command = new Command();

            //act
            command.ReadCommand(robot, "PLACE 1,1,NORTH");
            command.ReadCommand(robot, "LEFT");

            //assert
            Assert.AreEqual("WEST", robot.Direction);
        }

        [TestMethod]
        public void Should_Be_In_Correct_Position_After_Multiple_Commands()
        {
            //arrange
            var robot = new Robot();
            var command = new Command();

            //act
            command.ReadCommand(robot, "PLACE 1,1,NORTH");
            command.ReadCommand(robot, "MOVE"); // 1,2
            command.ReadCommand(robot, "MOVE"); // 1,3
            command.ReadCommand(robot, "LEFT"); // WEST
            command.ReadCommand(robot, "MOVE"); // 0,3
            command.ReadCommand(robot, "LEFT"); // SOUTH
            command.ReadCommand(robot, "MOVE"); // 0,2

            //assert
            Assert.AreEqual(0, robot.PosX);
            Assert.AreEqual(2, robot.PosY);
            Assert.AreEqual("SOUTH", robot.Direction);
        }
    }
}
