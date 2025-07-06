using NUnit.Framework;
using System.Linq;
using MartianRobotConApp;


namespace MartianRobotConApp.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void CreateTerrain_CreatesCorrectSizeAndEdges()
        {
            int rows = 3;
            int columns = 4;
            var terrain = TerrainSetup.CreateTerrain(rows, columns);
            Assert.AreEqual(rows * columns, terrain.Length);
            // Check corners are Edge
            Assert.AreEqual(TerrainType.Edge, terrain[0].type); // bottom-left
            Assert.AreEqual(TerrainType.Edge, terrain[columns - 1].type); // bottom-right
            Assert.AreEqual(TerrainType.Edge, terrain[(rows - 1) * columns].type); // top-left
            Assert.AreEqual(TerrainType.Edge, terrain[rows * columns - 1].type); // top-right
        }

        [Test]
        public void ShowTerrain_PrintsMatrixWithoutError()
        {
            int rows = 2;
            int columns = 2;
            var terrain = TerrainSetup.CreateTerrain(rows, columns);
            using (var sw = new System.IO.StringWriter())
            {
                var originalOut = System.Console.Out;
                System.Console.SetOut(sw);
                TerrainSetup.ShowTerrain(terrain);
                System.Console.SetOut(originalOut);
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Matrix has 2 rows and 2 columns"));
                Assert.IsTrue(output.Contains("E E"));
                Assert.IsTrue(output.Contains("Done printing Terrain"));
            }
        }
    }
}
