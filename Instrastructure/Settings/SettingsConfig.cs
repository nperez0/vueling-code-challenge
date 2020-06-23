using System.Configuration;

namespace Instrastructure.Settings
{
    public class SettingsConfig : ISettings
    {
        public string GetString(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public bool GetBool(string key)
        {
            var value = GetString(key);

            return bool.Parse(value);
        }
    }
}
