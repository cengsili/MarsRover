using MarsRover.Common.Enums;
using MarsRover.Common.Helper;
using MarsRover.Interfaces;
using MarsRover.Bussiness;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DependencyInjection.Configure();           
            IRoverCommandOperation roverCommandOperation = serviceProvider.GetService<IRoverCommandOperation>();        
            
            List<IRover> rovers = new List<IRover>();            
            string initialValues = string.Empty, limits = string.Empty, commandString = string.Empty;
            bool isAddingRover = true;

            Console.WriteLine("-----Welcome To The Mars-----");
            Console.Write("Please enter the limit of terrain : ");

            ITerrain terrain = null;
            while (!CheckTerainLimitValid())
            {
                Console.Write("Please enter the limit of terrain : ");
                limits = Console.ReadLine();
            }


            while (isAddingRover)
            {
                IRover rover = null;
                while (!CheckInitialValuesvalid(ref rover))
                {
                    Console.Write("Please enter the initial location :");
                    initialValues = Console.ReadLine();
                }
                Console.Write("Please enter the command :");
                commandString = Console.ReadLine();
                rover.Commands = commandString;
                rovers.Add(rover);

                Console.Write("Do you want to add new rover? (Y/N) :");
                isAddingRover = Console.ReadLine() == "Y" ? true : false;
                initialValues = string.Empty;
            };

            roverCommandOperation.RoverCommandOperationInit(terrain, rovers);
            Console.WriteLine("Output");
            Console.WriteLine(String.Join(Environment.NewLine, roverCommandOperation.RunCommands()));
            Console.Write("Press enter for exit...");

            Console.ReadLine();
            #region local - function
            bool CheckTerainLimitValid()
            {
                int x, y;
                if (!String.IsNullOrWhiteSpace(limits))
                {
                    string[] limitArr = limits.Split(" ");

                    if (limitArr.Length == 2)
                    {
                        if (int.TryParse(limitArr[0], out y) && int.TryParse(limitArr[1], out x))
                        {

                            terrain = new Terrain(new Position(x,y));
                            return true;
                        }
                    }
                }
                Console.WriteLine("Limit of terrain should be N M  like 5 5");
                return false;

            }
            bool CheckInitialValuesvalid(ref IRover rover)
            {
                int x, y;
                if (!String.IsNullOrWhiteSpace(initialValues))
                {
                    string[] initialValuesArr = initialValues.Split(" ");

                    if (initialValuesArr.Length == 3)
                    {
                        int direction = (int)EnumHelper.GetEnumValueFromDescription<Directions>(initialValuesArr[2]);
                        if (int.TryParse(initialValuesArr[0], out y) && int.TryParse(initialValuesArr[1], out x) && direction != -1)
                        {
                            rover = new Rover(new Position(x, y), direction);
                            return true;
                        }
                    }
                }
                Console.WriteLine("Initial values of rover should be N M ( N,S,E,W) like 1 2 N");
                return false;
            }
            #endregion

        }
    }
}
