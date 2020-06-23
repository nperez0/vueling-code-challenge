namespace Instrastructure.Settings
{
    public interface ISettings
    {
        bool GetBool(string key);
        string GetString(string key);
    }
}