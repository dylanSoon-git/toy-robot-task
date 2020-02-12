using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toy_Robot_Task
{
    public enum Direction { NORTH, EAST, SOUTH, WEST };

    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            var cmdControl = new Command();

            Console.WriteLine("Welcome to the toy robot task");
            Console.WriteLine("To begin.. use the command PLACE");

            while (true)
            {
                //Enter command                
                var entry = Console.ReadLine();
                var keyWord = entry.Split(' ').First();

                cmdControl.ReadCommand(robot, entry, keyWord);
            }
        }
    }
}
