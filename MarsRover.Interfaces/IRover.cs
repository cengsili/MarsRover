using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Interfaces
{
   public interface IRover
    {
        IPosition CurrentPosition { get; set; }
        int Direction { get; set; }
        string Commands { get; set; }

        void Move(int directionX, int directionY);
        void TurnLeft();
        void TurnRight();
    }
}

