using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toy_Robot_Task
{
    public class Command
    {
        /// <summary>
        /// Read the input and check if command exists
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="totalEntry"></param>
        /// <param name="keyWord"></param>
        public void ReadCommand(Robot robot, string totalEntry)
        {
            var keyWord = totalEntry.Split(' ').First();

            //Check command keyword PLACE, MOVE etc
            switch (keyWord.ToUpper())
            {
                case "PLACE":
                    DoPlaceCommand(robot, totalEntry, keyWord.Length);
                    break;

                case "MOVE":
                    if (CheckIfPlaced(robot.Placed))
                    {
                        DoMoveCommand(robot);
                    }
                    break;

                case "REPORT":
                    if (CheckIfPlaced(robot.Placed))
                    {
                        robot.ReportPosition();
                    }
                    break;

                case "LEFT":
                    if (CheckIfPlaced(robot.Placed))
                    {
                        var newDir = DoLeftCommand(robot.Direction);
                        robot.ChangeDirection(newDir.ToString());
                    }
                    break;

                case "RIGHT":
                    if (CheckIfPlaced(robot.Placed))
                    {
                        var newDir = DoRightCommand(robot.Direction);
                        robot.ChangeDirection(newDir.ToString());
                    }
                    break;
                default:
                    Console.WriteLine("Please enter valid command");
                    break;
            }
        }

        /// <summary>
        /// Call when the PLACE command is used
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="keyWordLength"></param>
        private static void DoPlaceCommand(Robot robot, string entry, int keyWordLength)
        {
            //Get cooordinates from PLACE
            var commandParams = entry.Substring(keyWordLength);
            var coordinates = commandParams.Split(',');

            //If more than x, y and direction, invalid command
            if (coordinates.Length != 3)
            {
                Console.WriteLine("Incorrect amount of parameters");
            }
            else
            {
                var placeX = int.Parse(coordinates[0]);
                var placeY = int.Parse(coordinates[1]);
                var placeDirection = coordinates[2].ToUpper();

                //Validate coordinates
                var validX = ValidAxisPosition(placeX);
                var validY = ValidAxisPosition(placeY);
                var validDirection = Enum.IsDefined(typeof(Direction), placeDirection);

                //All valid then place robot
                if (validX && validY && validDirection)
                {
                    robot.Place(placeX, placeY, placeDirection);
                }
                else
                {
                    Console.WriteLine("Place robot on valid coordinates");
                }
            }
        }

        /// <summary>
        /// Move the robot's position based on the direction
        /// </summary>
        /// <param name="robot"></param>
        private static void DoMoveCommand(Robot robot)
        {
            //Convert direction to an enum 
            Enum.TryParse(robot.Direction, out Direction currentDirection);

            //Depending on direction update the position of the robot
            switch (currentDirection)
            {
                case Direction.NORTH:
                    robot.MoveNorth();
                    break;

                case Direction.SOUTH:
                    robot.MoveSouth();
                    break;

                case Direction.EAST:
                    robot.MoveEast();
                    break;

                case Direction.WEST:
                    robot.MoveWest();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// If not placed then show message and retry
        /// </summary>
        /// <param name="placed"></param>
        /// <returns></returns>
        private static bool CheckIfPlaced(bool placed)
        {
            if (!placed)
            {
                Console.WriteLine("Robot must be placed first");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Since grid is 5x5, the positions can't be greater than 5
        /// Validates the positions entered
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private static bool ValidAxisPosition(int position)
        {
            return position >= 0 && position <= 5;
        }

        /// <summary>
        /// Moves the robot 90 degrees to the right
        /// </summary>
        /// <param name="robotsDir"></param>
        /// <returns></returns>
        private static Direction DoRightCommand(string robotsDir)
        {
            Enum.TryParse(robotsDir, out Direction currentDirection);

            //Get all enum values as an array and get the next direction
            var directionsArray = (Direction[])Enum.GetValues(typeof(Direction));
            var nextDir = Array.IndexOf(directionsArray, currentDirection) + 1;
            return directionsArray.Length == nextDir ? directionsArray[0] : directionsArray[nextDir];
        }

        /// <summary>
        /// Moves the robot 90 degrees to the left
        /// </summary>
        /// <param name="robotsDir"></param>
        /// <returns></returns>
        private static Direction DoLeftCommand(string robotsDir)
        {
            //Parse string to Direction
            Enum.TryParse(robotsDir, out Direction currentDirection);

            //Get all enum values as an array and get the previous direction
            var directionsArray = (Direction[])Enum.GetValues(typeof(Direction));
            var previousDir = Array.IndexOf(directionsArray, currentDirection) - 1;
            return previousDir == -1 ? directionsArray[3] : directionsArray[previousDir];
        }

    }
}
