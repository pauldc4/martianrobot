using NUnit.Framework;
using MartianRobotConApp;
using System;
using System.IO;
using System.Linq;

namespace MartianRobotConApp.Tests
{
    [TestFixture]
    public class TerrainSetupTests
    {
        [Test]
        public void CreateTerrain_CreatesCorrectSizeAndEdges()
        {
            int rows = 4;
            int columns = 5;
            var terrain = TerrainSetup.CreateTerrain(rows, columns);
            Assert.AreEqual(rows * columns, terrain.Length);
            foreach (var t in terrain)
            {
                if (t.x == 0 || t.x == columns - 1 || t.y == 0 || t.y == rows - 1)
                    Assert.AreEqual(TerrainType.Edge, t.type, $"Edge cell at ({t.x},{t.y}) should be Edge");
                else
                    Assert.AreEqual(TerrainType.Sand, t.type, $"Inner cell at ({t.x},{t.y}) should be Sand");
            }
        }

        [Test]
        public void ShowTerrain_PrintsExpectedOutput()
        {
            int rows = 2;
            int columns = 2;
            var terrain = TerrainSetup.CreateTerrain(rows, columns);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                TerrainSetup.ShowTerrain(terrain);
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Matrix has 2 rows and 2 columns"));
                Assert.IsTrue(output.Contains("E E"));
                Assert.IsTrue(output.Contains("Done printing Terrain"));
            }
        }
    }
}
