using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Test
{
    public interface IFruit { }
    public class Apple : IFruit { }
    public class Orange : IFruit { }

    public interface IVehicle { }
    public class Bicycle : IVehicle { }
    public class Train : IVehicle { }
    public class Car : IVehicle { }

    public interface IEntry { }

    public class EntryWithName : IEntry
    {
        public string Name { get; private set; }
        public EntryWithName(string name)
        {
            Name = name;
        }
    }

    public class EntryWithNameAndTitle:EntryWithName
    {
        public const int DefaultAge = 24;
        public const string DefaultTitle = "unknown";

        public int Age { get; private set; }
        public string Title { get; private set; }

        public EntryWithNameAndTitle(string name,int age,string title)
            :base(name)
        {
            Age = age;
            Title = title;
        }

        public EntryWithNameAndTitle(string name):
            this(name,DefaultAge,DefaultTitle)
        {

        }

        public EntryWithNameAndTitle(string name,int age)
            :this(name,age,DefaultTitle)
        {

        }
    }
}
