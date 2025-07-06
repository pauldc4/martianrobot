public static class Extensions
{
    public static List<Scent> ScentList = new List<Scent>();

    public static bool HasScent(int x, int y, char orientation)
    {
        return ScentList.Any(s => s.x == x && s.y == y && s.orientation == orientation);
    }

    public static void ExecuteRobotCommands(this Robot robot, Terrain[] terrain, string input)
    {
        var rows = terrain.Max(t => t.y) + 1;
        var columns = terrain.Max(t => t.x) + 1;

        foreach (var command in input.ToCharArray())
        {
            if (command == 'F' || command == 'L' || command == 'R')
            {
                if (command == 'F' && HasScent(robot.x, robot.y, robot.orientation))
                {
                    Console.WriteLine($"Robot at ({robot.x}, {robot.y}) facing {robot.orientation} has scent, skipping move.");
                    break;
                }
                
                robot.Move(command);

                if (robot.x < 0 || robot.y < 0 || robot.x > columns - 1 || robot.y > rows - 1)
                {
                    Console.WriteLine("Lost");
                    ScentList.Add(new Scent(robot.x, robot.y, robot.orientation));
                    break;
                }
                else
                {
                    Console.WriteLine($"Robot moved to position ({robot.x}, {robot.y}) facing {robot.orientation}");

                }
            }
            else
            {
                Console.WriteLine($"Invalid command: {command}");
            }
        }
    }
}