using RobotSimulator;

ToyRobot robot = new();
string filePath = "commands.txt";

if (File.Exists(filePath))
{
    foreach (var line in File.ReadLines(filePath))
    {
        robot.ExecuteCommand(line.Trim().ToUpper());
    }
}
else
{
    Console.WriteLine("Command file not found!");
}