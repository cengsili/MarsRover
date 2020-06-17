using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Common.Exceptions
{
 
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException(char command)
            : base($"Invalid command {command}. Command should be L,R or M")
        {
            Command = command;
            
        }

        public char Command { get; set; }
        
    }
}
