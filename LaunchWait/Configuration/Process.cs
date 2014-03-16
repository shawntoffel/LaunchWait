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
    }
}
