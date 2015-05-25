using System;
using System.Collections.Generic;
using System.Linq;

namespace MedikzWorks.PracticalPattern.Concept.Attributing
{
    public interface IAttributedBuilder
    {
        IList<string> Log { get; }
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
    }

    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    public sealed class DirectorAttribute : Attribute, IComparable<DirectorAttribute>,IComparable
    {
        public int Priority { get; set; }
        public string MethodName { get; set; }

        public DirectorAttribute(int priority,string methodName)
        {
            if (priority <= 0)
                throw new ArgumentOutOfRangeException("priority");
            if (string.IsNullOrEmpty(methodName))
                throw new ArgumentNullException("methodName");

            Priority = priority;
            MethodName = methodName;
        }
        public int CompareTo(object obj)
        {
            if (!(obj is DirectorAttribute))
                throw new ArgumentException("Argument is not a Customer", "obj");

            return this.CompareTo(obj as DirectorAttribute);
        }

        public int CompareTo(DirectorAttribute other)
        {
            return other.Priority.CompareTo(this.Priority);
        }

    }

    public class Director
    {
        public void BuildUp(IAttributedBuilder builder)
        {
            var attributes = builder.GetType().GetCustomAttributes(typeof(DirectorAttribute), false) as DirectorAttribute[];
            if (attributes == null)
                return;

            attributes.OrderByDescending(x => x.Priority)
                .ToList()
                .ForEach(x => InvokeBuildPartMethod(builder, x));
        }

        void InvokeBuildPartMethod(IAttributedBuilder builder, DirectorAttribute attribute)
        {
            switch (attribute.MethodName)
            {
                case "BuildPartA": builder.BuildPartA(); break;
                case "BuildPartB": builder.BuildPartB(); break;
                case "BuildPartC": builder.BuildPartC(); break;
            }
        }
    }
}
