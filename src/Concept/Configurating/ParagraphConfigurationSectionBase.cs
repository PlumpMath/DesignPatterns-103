using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.Configurating
{
    /// <summary>
    /// 文章段落的配置节类型 包括：
    /// 1.<examples>的ConfigrationElementCollection 可选
    /// 2.<diagrams>的ConfigrationElementCollection 可选
    /// </summary>
    public abstract class ParagraphConfigurationSectionBase:ConfigurationSection
    {
        const string ExamplesItem = "examples";
        const string DiagramsItem = "diagrams";

        [ConfigurationProperty(ExamplesItem,IsRequired = false)]
        public virtual ExampleConfigurationElementCollection Examples
        {
            get
            {
                return base[ExamplesItem] as ExampleConfigurationElementCollection;
            }
        }

        [ConfigurationProperty(DiagramsItem,IsRequired = false)]
        public virtual DiagramConfigurationElementCollection Diagrams
        {
            get
            {
                return base[DiagramsItem] as DiagramConfigurationElementCollection;
            }
        }
    }

    public class DelegatingParagramConfigurationSection:
        ParagraphConfigurationSectionBase
    {
        const string PicturesItem = "pictures";

        [ConfigurationProperty(PicturesItem,IsRequired = false)]
        public virtual PictureConfigurationElementCollection Pictures
        {
            get
            {
                return base[PicturesItem] as PictureConfigurationElementCollection;
            }
        }
    }

    public class GenericsParagramConfigurationSection:
        ParagraphConfigurationSectionBase { }
}
