using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity.XmlConfig
{
    public class DataSection : ConfigurationSection
    {
        [ConfigurationProperty("remoteOnly", DefaultValue = "false", IsRequired = false)]
        public Boolean RemoteOnly
        {
            get => (Boolean)this["remoteOnly"];
            set => this["remoteOnly"] = value;
        }

        [ConfigurationProperty("dataEntry", IsRequired = true, IsDefaultCollection = true)]
        public DataSectionCollection Instances
        {
            get { return (DataSectionCollection)(base["dataEntry"]); }
            set { base["dataEntry"] = value; }
        }

        //[ConfigurationProperty("entry")]
        //public Entry Entry
        //{
        //    get => (Entry)this["entry"];
        //    set => this["entry"] = value;
        //}
    }

    [ConfigurationCollection(typeof(Entry))]
    public class DataSectionCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "entry";

        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMapAlternate;

        protected override string ElementName => PropertyName;

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName,
                StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool IsReadOnly() => false;

        protected override ConfigurationElement CreateNewElement()
        {
            return new Entry();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Entry)element).Name;
        }

        public Entry this[string name] => (Entry)BaseGet(name);
    }

    public class Entry : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MaxLength = 100)]
        public string Name
        {
            get => (string)this["name"];
            set => this["name"] = value;
        }

        [ConfigurationProperty("value", IsRequired = false)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MaxLength = 100)]
        public string Value
        {
            get => (string)this["value"];
            set => this["value"] = value;
        }
    }
}
