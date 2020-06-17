using MarsRover.Interfaces;
using System;

namespace MarsRover.Bussiness
{
    public class Terrain : ITerrain
    {
         public IPosition Limit { get; set; }


        public Terrain(IPosition limit)
        {

            this.Limit=limit;
           

        }
    }
}
