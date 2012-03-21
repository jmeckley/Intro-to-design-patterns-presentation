using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace demo.Behavioral
{
    class Iterator
        : IDemo
    {
        public void Demo(TextWriter writer)
        {
            var collections = new IListOfItems[]
            {
                new EnumerationOfItems(),
                new ArrayOfItems
                {
                    Array = new ArrayList{1,2,3,"a","b","c"}
                },
                new ListOfItems
                {
                    Numbers = new []{1,2,3,4,5,6,7,8,9,10}.ToList()
                }
            };

            foreach (var collection in collections)
            {
                writer.WriteLine(collection);
                foreach (var item in collection.Items)
                {
                    writer.WriteLine("\t{0}", item);
                }
            }
        }
    }

    interface IListOfItems
    {
        IEnumerable<object> Items { get; }
    }

    class ArrayOfItems
        : IListOfItems
    {
        public ArrayList Array { get; set; }

        public IEnumerable<object> Items 
        {
            get { return Array.Cast<object>(); }
        }
    }

    class EnumerationOfItems
        : IListOfItems
    {
        public IEnumerable<object> Items
        {
            get 
            {
                yield return 1;
                yield return "foo";
                yield return DateTime.Now;
            }
        }
    }

    class ListOfItems
        : IListOfItems
    {
        public IList<int> Numbers { get; set; }

        public IEnumerable<object> Items
        {
            get { return Numbers.Cast<object>(); }
        }
    }
}
