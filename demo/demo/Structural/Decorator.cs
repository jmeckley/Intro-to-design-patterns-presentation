using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace demo.Structural
{
    class Decorator
        : IDemo
    {
        public void Demo(TextWriter writer)
        {
            new DecoratedComponent(new Componet()).DoSomething(writer);
        }
    }

    interface IComponent
    {
        void DoSomething(TextWriter writer);
    }

    class Componet 
        : IComponent
    {
        public void DoSomething(TextWriter writer)
        {
            writer.WriteLine("doing something really cool.");
        }
    }

    class DecoratedComponent
        : IComponent
    {
        readonly IComponent component;
        public DecoratedComponent(IComponent component)
        {
            this.component = component;
        }

        public void DoSomething(TextWriter writer)
        {
            writer.WriteLine("decorating ...");
            component.DoSomething(writer);
            writer.WriteLine("... decorated");
        }
    }
}
