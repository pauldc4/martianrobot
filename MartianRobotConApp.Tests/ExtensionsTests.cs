using NUnit.Framework;
using MartianRobotConApp;
using System.Collections.Generic;
using System;
using System.IO;

namespace MartianRobotConApp.Tests
{
    [TestFixture]
    public class ExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
            Extensions.ScentList.Clear();
        }

        [Test]
        public void HasScent_ReturnsTrueIfScentExists()
        {
            Extensions.ScentList.Add(new Scent(1, 2, 'N'));
            Assert.IsTrue(Extensions.HasScent(1, 2, 'N'));
        }

        [Test]
        public void HasScent_ReturnsFalseIfScentDoesNotExist()
        {
            Assert.IsFalse(Extensions.HasScent(5, 5, 'E'));
        }

        [Test]
        public void ExecuteRobotCommands_InvalidCommand_PrintsInvalidCommand()
        {
            var robot = new Robot(0, 0, 'N');
            var terrain = TerrainSetup.CreateTerrain(2, 2);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                robot.ExecuteRobotCommands(terrain, "X");
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Invalid command: X"));
            }
        }

        [Test]
        public void ExecuteRobotCommands_LostRobot_AddsScentAndPrintsLost()
        {
            var robot = new Robot(0, 0, 'S');
            var terrain = TerrainSetup.CreateTerrain(2, 2);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                robot.ExecuteRobotCommands(terrain, "F");
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Lost"));
                Assert.IsTrue(Extensions.ScentList.Exists(s => s.x < 0 || s.y < 0));
            }
        }

        [Test]
        public void ExecuteRobotCommands_ValidMove_PrintsMoved()
        {
            var robot = new Robot(0, 0, 'N');
            var terrain = TerrainSetup.CreateTerrain(2, 2);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                robot.ExecuteRobotCommands(terrain, "F");
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Robot moved to position (0, 1) facing N"));
            }
        }
    }
}
