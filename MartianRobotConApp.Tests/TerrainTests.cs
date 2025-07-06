using NUnit.Framework;
using MartianRobotConApp;

namespace MartianRobotConApp.Tests
{
    [TestFixture]
    public class TerrainTests
    {
        [Test]
        public void CreateTerrain_CorrectSizeAndEdges()
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
    }
}
