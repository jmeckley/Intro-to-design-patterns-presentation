using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace demo
{
    class Program
    {
        static bool run = true;
        static void Main(string[] args)
        {
            while (run)
            {
                WriteOptions();
                RunDemo();
            }
        }

        static void WriteOptions()
        {
            var index = 1;
            foreach (var demo in Demos)
            {
                Console.WriteLine("{0}. {1}", index++, demo);
            }
            Console.Write("Run Demo: ");
        }

        static void RunDemo()
        {
            int choice;
            var input = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);

            if (input == "x")
            {
                run = false;
                return;
            }

            if (int.TryParse(input, out choice))
            {
                var index = choice - 1;
                Demos.ElementAt(index).Demo(Console.Out);
            }
            Console.WriteLine(Environment.NewLine);
        }

        static IEnumerable<IDemo> Demos
        {
            get 
            {
                yield return new Creational.SimplestObjectFactory();
                yield return new Creational.ObjectAndMethodFactories();
                yield return new Creational.Singleton();
                yield return new Creational.BclBuilder();
                yield return new Creational.FluentValidationBuilder();

                yield return new Behavioral.Strategy();
                yield return new Behavioral.NullObject();
                yield return new Behavioral.Iterator();
                yield return new Behavioral.Observer();
                yield return new Behavioral.Command { Number = new Random().Next(1, 100)};
                
                yield return new Structural.Adaptor();
                yield return new Structural.Decorator();
                yield return new Structural.Proxy();
            }
        }
    }
}
