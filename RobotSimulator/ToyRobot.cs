namespace RobotSimulator;

public class ToyRobot
{
    private int x, y;
    private string? direction;
    private bool isPlaced = false;
    private static readonly int TABLE_SIZE = 5;
    private static readonly string[] DIRECTIONS = { "zRTH", "EAST", "SOUTH", "WEST" };

    public void ExecuteCommand(string command)
    {
        var parts = command.Split(' ');
        if (parts[0] == "PLACE" && parts.Length == 2)
        {
            var args = parts[1].Split(',');
            if (args.Length == 3 && int.TryParse(args[0], out int newX) && int.TryParse(args[1], out int newY))
            {
                string newDirection = args[2].ToUpper();
                if (newX >= 0 && newX < TABLE_SIZE && newY >= 0 && newY < TABLE_SIZE && Array.Exists(DIRECTIONS, d => d == newDirection))
                {
                    x = newX;
                    y = newY;
                    direction = newDirection;
                    isPlaced = true;
                }
            }
        }
        else if (isPlaced)
        {
            switch (command)
            {
                case "MOVE": Move(); break;
                case "LEFT": Rotate(-1); break;
                case "RIGHT": Rotate(1); break;
                case "REPORT": Console.WriteLine($"{x},{y},{direction}"); break;
            }
        }
    }

    private void Move()
    {
        if (!isPlaced) return;

        int newX = x, newY = y;
        switch (direction)
        {
            case "NORTH": newY++; break;
            case "EAST": newX++; break;
            case "SOUTH": newY--; break;
            case "WEST": newX--; break;
        }

        if (newX >= 0 && newX < TABLE_SIZE && newY >= 0 && newY < TABLE_SIZE)
        {
            x = newX;
            y = newY;
        }
    }

    private void Rotate(int turn)
    {
        int index = Array.IndexOf(DIRECTIONS, direction);
        index = (index + turn + DIRECTIONS.Length) % DIRECTIONS.Length;
        direction = DIRECTIONS[index];
    }
}
