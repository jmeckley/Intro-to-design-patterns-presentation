using System;
using System.IO;

namespace demo.Behavioral
{
    class Command
        : IDemo
    {
        public int Number { get; set; }

        public void Demo(TextWriter writer)
        {
            writer.WriteLine("IDemo is itself an example of the command pattern");
            writer.WriteLine("{0}.Number = {1}", this, Number);
            writer.WriteLine("this is a simple demonstration of encapsulating implementation details of the command.");
        }
    }
}
