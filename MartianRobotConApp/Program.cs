// See https://aka.ms/new-console-template for more information
Console.WriteLine("Robot Martian World");

bool isTerrainSetup = false;
bool isRobotSetup = false;
bool executing = true;
string input = string.Empty;
Robot robot = new Robot();
List<Robot> robots = new List<Robot>();
Terrain[] terrain = new Terrain[0];
int rows = 0;
int columns = 0;

while (executing)
{
    
    input = Console.ReadLine() ?? string.Empty;

    if (input.Length > 100)
    {
        Console.WriteLine("Cannot add more than 100 commands");
        continue;
    }
    
    if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^[0-9NSEWLFRQ ]*$"))
    {
        Console.WriteLine("Invalid input");
        input = string.Empty;
        continue;
    }

    if (input == "Q")
    {
        executing = false;
        Console.WriteLine("Exiting the application...");
        break;
    }


    if (!isTerrainSetup)
    {
        
        var boundries = input.Split(' ');
        if (boundries.Length != 2)
        {
            Console.WriteLine("Invalid Terrain setup");
            continue;
        }

        if (int.TryParse(boundries[0], out rows) && int.TryParse(boundries[1], out columns))
        {
            terrain = TerrainSetup.CreateTerrain(rows, columns);
        }
        else
        {
            Console.WriteLine("Invalid Terrain setup");
            continue;
        }
        TerrainSetup.ShowTerrain(terrain);

        isTerrainSetup = true;
        input = string.Empty; // Reset input after processing terrain setup
    }
    else if (!isRobotSetup)
    {
        var robotPosition = input.Split(' ');
        if (robotPosition.Length != 3)
        {
            Console.WriteLine("Invalid Robot Initial position");
            continue;
        }

        robot = new Robot(int.Parse(robotPosition[0]), int.Parse(robotPosition[1]), char.Parse(robotPosition[2]));
        Console.WriteLine($"Robot set at position ({robot.x}, {robot.y}) facing {robot.orientation}");
        isRobotSetup = true;
        input = string.Empty;
    }
    else if (isTerrainSetup && isRobotSetup)
    {        
        Console.WriteLine("Executing robot commands...");
        robot.ExecuteRobotCommands(terrain, input);
        input = string.Empty;
        isRobotSetup = false;
    }
}