using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace demo.Structural
{
    class Proxy
        : IDemo
    {
        public void Demo(TextWriter writer)
        {
            writer.WriteLine("ORMs require proxy calls for lazy loading");
            writer.WriteLine("simliar to decorator except that it may completely intercept the call to the original component");
        }
    }
}
