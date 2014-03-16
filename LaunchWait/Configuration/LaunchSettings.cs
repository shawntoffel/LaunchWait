using System.Configuration;

namespace LaunchWait.Configuration
{
    public class LaunchSettings : ConfigurationElementCollection
    {
        public LaunchSettings()
        {
            this.AddElementName = "LaunchSettings";
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new Process();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as Process).Name;
        }
        
        public new Process this[string key]
        {
            get
            {
                return BaseGet(key) as Process;
            }
        }

        public Process this[int index]
        {
            get
            {
                return this.BaseGet(index) as Process;
            }
        }
    }
}
