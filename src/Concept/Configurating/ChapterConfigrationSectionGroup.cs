using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.Configurating
{
    /// <summary>
    /// 整个配置节组的对象，包括<delegating>和<generics>两个配置节
    /// </summary>
    public class ChapterConfigrationSectionGroup:ConfigurationSectionGroup
    {
        const string DelegatingItem = "delegating";
        const string GenericsItem = "generics";

        public ChapterConfigrationSectionGroup():base(){}

        [ConfigurationProperty(DelegatingItem,IsRequired = true)]
        public virtual DelegatingParagramConfigurationSection Delegating
        {
            get
            {
                return base.Sections[DelegatingItem]
                    as DelegatingParagramConfigurationSection;
            }
        }

        public virtual GenericsParagramConfigurationSection Generics
        {
            get
            {
                return base.Sections[GenericsItem]
                    as GenericsParagramConfigurationSection;
            }
        }
    }
}
