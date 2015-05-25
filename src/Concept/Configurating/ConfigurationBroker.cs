using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.Configurating
{
    /// <summary>
    /// 调度App.Config相关Configuration的Broker类型
    /// </summary>
    public static class ConfigurationBroker
    {
        static ChapterConfigrationSectionGroup group;

        static ConfigurationBroker()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            group = (ChapterConfigrationSectionGroup)config.GetSectionGroup
                    ("medikzWorks.practicalPattern.concept");
        }

        public static DelegatingParagramConfigurationSection Delegating
        {
            get { return group.Delegating; }
        }

        public static GenericsParagramConfigurationSection Generics
        {
            get { return group.Generics; }
        }
    }
}
