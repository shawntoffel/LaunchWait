using System.Configuration;

namespace LaunchWait.Configuration
{
    public class Section : ConfigurationSection
    {
        public static readonly string sectionName = "LaunchSettings";

        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(LaunchSettings), AddItemName="Process")]
        public LaunchSettings LaunchSettings
        {
            get
            {
                return this[""] as LaunchSettings;
            }
        }

        public static Section GetSection()
        {
            return (Section)ConfigurationManager.GetSection(sectionName) ?? new Section();
        }
    }
}
