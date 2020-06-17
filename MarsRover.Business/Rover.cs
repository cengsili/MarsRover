using MarsRover.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MarsRover.Bussiness
{
    public class Rover : IRover
    {
        public IPosition CurrentPosition { get; set; }
        public int Direction { get; set; }
        public string Commands { get; set; }


        public Rover(IPosition currentPosion, int direction,string commands = "")
        {
            this.CurrentPosition = currentPosion;
            this.Direction = direction;
            this.Commands = commands;

        }

        public void Move(int directionX , int directionY)
        {
          
                if (directionY != 0)
                {
                    CurrentPosition.Y += directionY;
                }
                else
                {
                    CurrentPosition.X += directionX;
                }
           
        }

        public void TurnLeft()
        {
            Direction = (Direction + 3) % 4; //360-90  4-1=3
        }

        public void TurnRight()
        {
            Direction = (Direction + 1) % 4;
        }

    }
}
