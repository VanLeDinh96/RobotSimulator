using Xunit;

namespace RobotSimulator.Tests;

public class ToyRobotTests
{
    private readonly ToyRobot robot;

    public ToyRobotTests()
    {
        robot = new ToyRobot();
    }

    [Fact]
    public void Test_Place_Command()
    {
        robot.ExecuteCommand("PLACE 2,2,NORTH");

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            robot.ExecuteCommand("REPORT");

            string output = sw.ToString().Trim();
            Console.WriteLine($"Actual output: {output}");

            Assert.Contains("2,2,NORTH", output);
        }
    }


    [Fact]
    public void Test_Move_Command()
    {
        robot.ExecuteCommand("PLACE 0,0,NORTH");
        robot.ExecuteCommand("MOVE");
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            robot.ExecuteCommand("REPORT");
            Assert.Contains("0,1,NORTH", sw.ToString().Trim());
        }
    }

    [Fact]
    public void Test_Left_Command()
    {
        robot.ExecuteCommand("PLACE 0,0,NORTH");
        robot.ExecuteCommand("LEFT");
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            robot.ExecuteCommand("REPORT");
            Assert.Contains("0,0,WEST", sw.ToString().Trim());
        }
    }

    [Fact]
    public void Test_Right_Command()
    {
        robot.ExecuteCommand("PLACE 0,0,NORTH");
        robot.ExecuteCommand("RIGHT");
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            robot.ExecuteCommand("REPORT");
            Assert.Contains("0,0,EAST", sw.ToString().Trim());
        }
    }

    [Fact]
    public void Test_Invalid_Move_At_Edge()
    {
        robot.ExecuteCommand("PLACE 0,4,NORTH");
        robot.ExecuteCommand("MOVE");
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            robot.ExecuteCommand("REPORT");
            Assert.Contains("0,4,NORTH", sw.ToString().Trim());
        }
    }

    [Fact]
    public void Test_Invalid_Command_Ignored()
    {
        robot.ExecuteCommand("JUMP");
        robot.ExecuteCommand("PLACE 1,1,EAST");
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            robot.ExecuteCommand("REPORT");
            Assert.Contains("1,1,EAST", sw.ToString().Trim());
        }
    }
}
