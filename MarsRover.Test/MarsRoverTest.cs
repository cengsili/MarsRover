using MarsRover.Bussiness;
using MarsRover.Interfaces;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using MarsRover.Common.Exceptions;
using MarsRover.Common.Enums;

namespace MarsRover.Test
{
    public class MarsRoverTest
    {
        private IRoverCommandOperation operation;
        [SetUp]
        public void Setup()
        {
            var serviceProvider = DependencyInjection.Configure();
            operation = serviceProvider.GetService<IRoverCommandOperation>();
        }

        [TestCase(5, 5, 2, 1,(int) Directions.N, "LMLMLMLMM","1 3 N")]
        [TestCase(5, 5, 3, 3, (int) Directions.E, "MMRMMRMRRM", "5 1 E")]     
        public void IsValid_GivenCommand_ReturnsExpectedResult(int limitX, int limitY,
                                                                int roverX, int roverY, int direction,
                                                                string commands,string expectedResult)
        {
            ITerrain terrain = new Terrain(new Position(limitX, limitY));
            List<IRover> list = new List<IRover>() { new Rover(new Position(roverX, roverY), direction, commands) };
            operation.RoverCommandOperationInit(terrain, list);
            List<string> results = operation.RunCommands();
            Assert.AreEqual(expectedResult, results[0]);
        }
    }
}