using System.Configuration;

namespace LaunchWait.Configuration
{
    public class Process : ConfigurationElement
    {
        [ConfigurationProperty("name")]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("path")]
        public string Path
        {
            get
            {
                return (string)this["path"];
            }
            set
            {
                this["path"] = value;
            }
        }

        [ConfigurationProperty("delay")]
        public int Delay
        {
            get
            {
                return (int)this["delay"];
            }
            set
            {
                this["delay"] = value;
            }
        }

        [ConfigurationProperty("arguments")]
        public string Arguments
        {
            get
            {
                return (string)this["arguments"];
            }
            set
            {
                this["arguments"] = value;
            }
        }
    }
}
