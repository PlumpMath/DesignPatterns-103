using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.Exercise
{
    public static class ExerciseManager
    {
        public static SingleLineSection SingleLineSetting
        {
            get { return ConfigurationManager.GetSection("singleLine") as SingleLineSection; }
        }

        public static DictionarySection DictSetting
        {
            get { return ConfigurationManager.GetSection("dictionary") as DictionarySection; }
        }
    }

    public class SingleLineSection:ConfigurationSection
    {
        const string nameItem = "name";
        const string ageItem = "age";
        const string levelItem = "level";

        [ConfigurationProperty(nameItem, IsRequired = true)]
        public string Name
        {
            get { return (string)base[nameItem]; }
            set { base[nameItem] = value; }
        }

        [ConfigurationProperty(ageItem, IsRequired = true)]
        public string Age
        {
            get { return (string)base[ageItem]; }
            set { base[ageItem] = value; }
        }

        [ConfigurationProperty(levelItem, IsRequired = true)]
        public string Level
        {
            get { return (string)base[levelItem]; }
            set { base[levelItem] = value; }
        }
    }

    public class DictionarySection:ConfigurationSection
    {
        const string dictItem = "ddd";
        [ConfigurationProperty(dictItem, IsDefaultCollection = true)]
        public AddCollection Dictionary
        {
            get { return base[dictItem] as AddCollection; }
            set { base[dictItem] = value; }
        }
    }

    [ConfigurationCollection(typeof(AddElement),CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class AddCollection:ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new AddElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as AddElement).Key;
        }

        public AddElement this[int index]
        {
            get { return (AddElement)base.BaseGet(index); }
        }

        public new AddElement this[string key]
        {
            get { return (AddElement)base.BaseGet(key); }
        }
    }

    public class AddElement:ConfigurationElement
    {
        const string keyItem = "key";
        const string valueItem = "value";

        [ConfigurationProperty(keyItem,IsRequired = true,IsKey = true)]
        public string Key
        {
            get { return (string)base[keyItem]; }
            set { Key = value; }
        }

        [ConfigurationProperty(valueItem,IsRequired = true)]
        public string Value
        {
            get { return (string)base[valueItem]; }
            set { Value = value; }
        }
    }
}
