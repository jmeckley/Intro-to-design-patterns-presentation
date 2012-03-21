using System;
using System.IO;

namespace demo.Creational
{
    class Singleton
        : IDemo
    {
        public void Demo(TextWriter writer)
        {
            var firstInstance = new Application();
            writer.WriteLine(firstInstance.Identifier);

            var secondInstance = new Application();
            writer.WriteLine(secondInstance.Identifier);
        }
    }

    class Application
    {
        public static readonly Application Instance = new Application();

        public Application()
        {
            Identifier = Guid.NewGuid();
        }

        public Guid Identifier { get; private set; }
    }
}