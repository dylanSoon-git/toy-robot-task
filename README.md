# toy-robot-task

In order to run this Console Application you will need to do the following:
1. Clone this repository https://github.com/dylanSoon-git/toy-robot-task.git
2. Open the **Toy_Robot_Task.sln** in Visual Studio
3. Build the project and then go to **Toy_Robot_Task/bin/Debug**
4. Run the **Toy_Robot_Task** application. This will start the program.
  
  
If you want to run the unit tests created for this project:
1. Open the **Toy_Robot_Task.sln** in Visual Studio
2. Go to _Test_ -> _Test Explorer_
3. In _Test Explorer_ you can see all the tests and run them from there. 


Description of task

The application is a simulation of a toy robot moving on a square table top, of dimensions 5 units x 5 units. There are no
other obstructions on the table surface. The robot is free to roam around the surface of the table, but must be prevented
from falling to destruction. Any movement that would result in the robot falling from the table must be prevented,
however further valid movement commands must still be allowed.

Create a console application that can read in commands of the following form -

- PLACE X,Y,F
- MOVE
- LEFT
- RIGHT
- REPORT

**PLACE** will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. The origin (0,0)
can be considered to be the SOUTH WEST most corner. It is required that the first command to the robot is a PLACE
command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The
application should discard all commands in the sequence until a valid PLACE command has been executed.

**MOVE** will move the toy robot one unit forward in the direction it is currently facing.

**LEFT** and **RIGHT** will rotate the robot 90 degrees in the specified direction without changing the position of the robot.

**REPORT** will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient.
