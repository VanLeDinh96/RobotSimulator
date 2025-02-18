# Toy Robot Simulator

## Overview

The Toy Robot Simulator is a C# console application that simulates the movement of a toy robot on a 5x5 grid tabletop. The robot can be controlled using commands such as `PLACE`, `MOVE`, `LEFT`, `RIGHT`, and `REPORT` while ensuring it does not fall off the table.

## Prerequisites

- .NET SDK (6.0 or later)
- A terminal or command prompt

## Installation & Setup

1. **Clone the repository**:

   ```sh
   git clone https://github.com/VanLeDinh96/RobotSimulator.git
   cd RobotSimulator
   ```

2. **Build the project**:
   ```sh
   dotnet build
   ```

## How to Run

### **Running the Application**

To run the application, use the following command:

```sh
   dotnet run
```

### **Using Input Commands**

The application reads commands from a file named `commands.txt` located in the project directory. You can modify this file to include custom commands for the toy robot.

Example `commands.txt`:

```
PLACE 0,0,NORTH
MOVE
REPORT
```

Alternatively, you can enter commands manually in the terminal after running the application.

## Command Description

| Command       | Description                                                        |
| ------------- | ------------------------------------------------------------------ |
| `PLACE X,Y,F` | Places the robot at `(X,Y)` facing `F` (NORTH, EAST, SOUTH, WEST). |
| `MOVE`        | Moves the robot one step forward in the direction it is facing.    |
| `LEFT`        | Rotates the robot 90 degrees left.                                 |
| `RIGHT`       | Rotates the robot 90 degrees right.                                |
| `REPORT`      | Prints the current position and direction of the robot.            |

## Running Tests

To run tests (if available):

```sh
   dotnet test
```

## Troubleshooting

- Ensure you have .NET installed correctly by running:
  ```sh
  dotnet --version
  ```
- If `Permission Denied` occurs, check the file permissions or run the terminal as administrator.
