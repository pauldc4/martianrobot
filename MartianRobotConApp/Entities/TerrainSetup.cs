public static class TerrainSetup
{
    public static Terrain[] CreateTerrain(int rows, int columns)
    {
        var newMatrix = new Terrain[rows * columns];
        int index = 0;
        for (int i = rows - 1; i >= 0; i--)
        {
            for (int j = 0; j < columns; j++)
            {
                TerrainType terrainType = (i == 0 || i == rows - 1 || j == 0 || j == columns - 1)
                                                ? TerrainType.Edge : TerrainType.Sand;
                newMatrix[index] = new Terrain(j, i, terrainType);
                index++;
            }
        }
        return newMatrix;
    }

    public static void ShowTerrain(Terrain[] terrain)
    {
        var rows = terrain.Max(t => t.y) + 1; // Assuming y is the row index
        var columns = terrain.Max(t => t.x) + 1; // Assuming x is
        Console.WriteLine($"Matrix has {rows} rows and {columns} columns");
        int currentRow = rows - 1; // Start from the last row
        string data = "";
        foreach (var t in terrain)
        {
            if (t.x >= columns || t.y >= rows)
            {
                Console.WriteLine($"Invalid terrain data at ({t.x}, {t.y})");
                return;
            }
            if (t.y != currentRow)
            {
                data += "\n";
                currentRow = t.y;
            }

            data += $"{t.type.ToString().Substring(0, 1).PadRight(2)}";

        }

        Console.WriteLine(data.TrimEnd());
        Console.WriteLine("Done printing Terrain");
    }
}