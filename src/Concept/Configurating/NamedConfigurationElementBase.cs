using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.Configurating
{
    /// <summary>
    /// 定义具有name和description属性的配置元素
    /// name属性作为ConfigurationElementCollection中相应的key
    /// </summary>
    public abstract class NamedConfigurationElementBase:ConfigurationElement
    {
        const string NameItem = "name";
        const string DescriptionItem = "description";

        [ConfigurationProperty(NameItem,IsKey = true,IsRequired = true)]
        public virtual string Name { get { return base[NameItem] as string; } }

        [ConfigurationProperty(DescriptionItem,IsRequired = false)]
        public virtual string Description { get { return base[Description] as string; } }
    }

    public class ExampleConfigurationElement : NamedConfigurationElementBase { }
    public class DiagramConfigurationElement : NamedConfigurationElementBase { }

    public class PictureConfigurationElement:NamedConfigurationElementBase
    {
        const string ColorizedItem = "colorized";

        [ConfigurationProperty(ColorizedItem,IsRequired = true)]
        public bool Colorized { get { return (bool)base[ColorizedItem]; } }
    }
}
