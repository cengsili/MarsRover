using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace MarsRover.Interfaces
{
    public interface IRoverCommandOperation
    {
        ITerrain Terrain { get; set; }

        List<IRover> Rovers { get; set; }

        void RoverCommandOperationInit(ITerrain terrain, List<IRover> rovers);
        
        List<string> RunCommands();


    }
}
