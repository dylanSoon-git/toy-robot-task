using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toy_Robot_Task
{
    public class Robot
    { 
        public int PosX { get; set; }
        public int PosY { get; set; }
        public string Direction { get; set; }
        public bool Placed { get; set; }

        public Robot()
        {
        }

        /// <summary>
        /// Place robot in starting position 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        public void Place(int x, int y, string direction)
        {
            this.PosX = x;
            this.PosY = y;
            this.Direction = direction;
        }

        /// <summary>
        /// Move north 1 if safe
        /// </summary>
        public void MoveNorth()
        {
            if (PosY == 5)
            {
                this.PosY++;
            }
            else
            {
                Console.WriteLine("Can't move robot further in this direction");
            }
        }

        /// <summary>
        /// Move north 1 if safe
        /// </summary>
        public void MoveSouth()
        {
            if (PosY == 0)
            {
                this.PosY--;
            }
            else
            {
                Console.WriteLine("Can't move robot further in this direction");
            }
        }

        /// <summary>
        /// Move east 1 if safe
        /// </summary>
        public void MoveEast()
        {
            if (PosX == 5)
            {
                this.PosX++;
            }
            else
            {
                Console.WriteLine("Can't move robot further in this direction");
            }
        }

        /// <summary>
        /// Move west 1 if safe
        /// </summary>
        public void MoveWest()
        {
            if (PosX == 0)
            {
                this.PosX--;
            }
            else
            {
                Console.WriteLine("Can't move robot further in this direction");
            }
        }
    }
}
