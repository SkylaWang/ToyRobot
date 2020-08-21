# ToyRobot
### Description:
- The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.
- There are no other obstructions on the table surface.
- The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.
### Commonds
  - PLACE X,Y,F
  
  PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. The origin (0,0) can be considered to be the SOUTH WEST most corner. The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application should discard all commands in the sequence until a valid PLACE command has been executed.
  - MOVE
  
  MOVE will move the toy robot one unit forward in the direction it is currently facing.
  - LEFT
  - RIGHT
  
  LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
  - REPORT
  
  REPORT will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient.

### Special rule:
- Any command before first PLACE will be ignored.
- Any command that would cause the robot to fall will be ignored. 
- Commands are mannualy input. Ensure each line has one command.
- Output will only display after excute REPORT command.

### Tech & Project
- .Net Core Console App (ToyRobotApp project)
- xUnit unit testing (ToyRobotUnitTest)

### How it works?
1. Use Visual Studio open the solution ToyRobot.sln
2. Run ToyRobotApp project 
3. Type commands
- examples of input and output:
    
```sh
Welcome to Toy Robot. Please input your commands or type EXIT to exit.
place 1,2,North
report
Output: 1,2,NORTH
```

```sh
Welcome to Toy Robot. Please input your commands or type EXIT to exit.
place 2,3,east
move
move
report
Output: 4,3,EAST
```

```sh
Welcome to Toy Robot. Please input your commands or type EXIT to exit.
place 2,3,east
left
report
Output: 2,3,NORTH
```
