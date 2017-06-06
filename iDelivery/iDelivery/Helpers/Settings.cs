// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace iDelivery.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants
        private const string UserNameKey = "UserName";
        private const string UserPasswordKey = "UserPassword";
        #endregion

        public static string UserPassword
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(UserPasswordKey, null);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserPasswordKey, value);
            }
        }

        public static string UserName
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(UserNameKey, null);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserNameKey, value);
            }
        }

    }
}