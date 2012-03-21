using System;
using System.Data.Common;
using System.IO;

namespace demo.Creational
{
    class SimplestObjectFactory
        : IDemo
    {
        public void Demo(TextWriter writer)
        {
            var instance = Activator.CreateInstance<DateTime>();
            writer.WriteLine(instance);
        }
    }

    class ObjectAndMethodFactories
        : IDemo
    {
        public void Demo(TextWriter writer)
        {
            //"System.Data.OleDb"

            //factory class
            var factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            writer.WriteLine(factory);

            //example of factory method
            using (var connection = factory.CreateConnection())
            using (var command = factory.CreateCommand())
            {
                writer.WriteLine(connection);
                writer.WriteLine(command);
            }
        }
    }
}