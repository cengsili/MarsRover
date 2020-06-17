using MarsRover.Common.Exceptions;
using MarsRover.Common.Helper;
using MarsRover.Interfaces;
using MarsRover.Common.Enums;
using System.Collections.Generic;

namespace MarsRover.Bussiness
{
    public class RoverCommandOperation : IRoverCommandOperation
    {
        public List<IRover> Rovers { get; set; }
        public ITerrain Terrain { get; set; }

        private int[,] dirs = new int[,] { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };

        public RoverCommandOperation()
        {
            this.Rovers = new List<IRover>();
        }
        public void RoverCommandOperationInit(ITerrain terrain, List<IRover> rovers)
        {
            this.Terrain = terrain;
            this.Rovers = rovers;

        }
        private bool CheckTerrainLimit(IRover rover)
        {
            if (rover.CurrentPosition.Y + dirs[rover.Direction, 1] >= 0
                && rover.CurrentPosition.Y + dirs[rover.Direction, 1] <= this.Terrain.Limit.Y
                && rover.CurrentPosition.X + dirs[rover.Direction, 0] >= 0
                && rover.CurrentPosition.X + dirs[rover.Direction, 0] <= this.Terrain.Limit.X)
                return true;
            return false;
        }

        private bool CheckValidCommand(char command)
        {
            if (command == 'L' || command == 'R' || command == 'M')
                return true;
            return false;
        }
        public List<string> RunCommands()
        {
            List<string> results = new List<string>();
            bool isSuccess = true;
            foreach (var rover in this.Rovers)
            {
                isSuccess = true;
                foreach (char command in rover.Commands.ToCharArray())
                {
                    if (CheckValidCommand(command))
                    {
                        if (command == 'L')
                            rover.TurnLeft();
                        else if (command == 'R')
                            rover.TurnRight();
                        else if (command == 'M' && CheckTerrainLimit(rover))
                            rover.Move(dirs[rover.Direction, 0], dirs[rover.Direction, 1]);
                        else
                        {
                            results.Add($"Exceed limits. (Terrain limit Y, X: {this.Terrain.Limit.X}, {this.Terrain.Limit.Y}, current Location Y, X: " +
                                  $"{rover.CurrentPosition.Y}, {rover.CurrentPosition.X})");
                            isSuccess = false;
                            break;
                        }
                    }
                    else
                    {
                        results.Add($"Invalid command {command}. Command should be L, R or M");
                        isSuccess = false;
                        break;
                    }

                }
                if (isSuccess)
                    results.Add($"{rover.CurrentPosition.Y} {rover.CurrentPosition.X} {EnumHelper.GetEnumDescription((Directions)rover.Direction)}");

            }
            return results;

        }


    }
}
