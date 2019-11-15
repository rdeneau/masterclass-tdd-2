using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata
{
    public class CommandHandler
    {
        public IEnumerable<Command> Read(string commandLetters)
        {
            return (commandLetters ?? "").ToCharArray()
                                         .Select(c => Command.Create($"{c}"));
        }
    }
}