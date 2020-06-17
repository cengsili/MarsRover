using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Common.Exceptions
{
  
    public class ExceedLimitsException : Exception
    {
        public ExceedLimitsException(int limitX, int limitY, int roverX,int roverY )
            : base($"Exceed limits. (Terrain limit X, Y: {limitX}, {limitY}, current Location X, Y: {roverX}, {roverY})")
        {
            LimitX = limitX;
            LimitY = limitY;
            RoverX = roverX;
            RoverY = roverY;

        }

        public int LimitX { get; set; }
        public int LimitY { get; set; }
        public int RoverX { get; set; }
        public int RoverY { get; set; }
       
    }
}
