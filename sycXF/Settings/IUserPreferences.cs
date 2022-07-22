using System;
namespace sycXF.Settings
{
    public interface IUserPreferences
    {
        bool ContainsKey(string key);
        void Set(string key, bool value);
        void Set(string key, string value);
        bool Get(string key, bool defaultValue);
        string Get(string key, string defaultValue);
    }
}

