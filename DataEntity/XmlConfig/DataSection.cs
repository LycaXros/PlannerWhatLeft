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

        [ConfigurationProperty("entry")]
        public Entry Entry
        {
            get => (Entry)this["entry"];
            set => this["entry"] = value;
        }
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
