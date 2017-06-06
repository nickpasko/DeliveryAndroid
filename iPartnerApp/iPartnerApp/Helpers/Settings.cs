// Helpers/Settings.cs
using iPartnerApp.Enums;
using iPartnerApp.Model;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;

namespace iPartnerApp.Helpers
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
        private const string OrderConfirmedFlagKey = "OrderConfirmedFlag";
        private const string DriverConfirmedFlagKey = "DriverConfirmedFlag";
        private const string DriverStartedFlagKey = "DriverStartedFlag";
        private const string DriverBellRingFlagKey = "DriverBellRingFlag";
        private const string DriverComplitedFlagKey = "DriverComplitedFlag";
        private const string DriverOrderStatusKey = "DriverOrdersStatus";
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

        public static bool OrderConfirmedFlag
        {
            get { return AppSettings.GetValueOrDefault<bool>(OrderConfirmedFlagKey, false); }
            set { AppSettings.AddOrUpdateValue(OrderConfirmedFlagKey, value); }
        }

        public static bool DriverConfirmedFlag
        {
            get { return AppSettings.GetValueOrDefault<bool>(DriverConfirmedFlagKey, false); }
            set { AppSettings.AddOrUpdateValue(DriverConfirmedFlagKey, value); }
        }

        public static bool DriverStartedFlag
        {
            get { return AppSettings.GetValueOrDefault<bool>(DriverStartedFlagKey, false); }
            set { AppSettings.AddOrUpdateValue(DriverStartedFlagKey, value); }
        }

        public static bool DriverBellRingFlag
        {
            get { return AppSettings.GetValueOrDefault<bool>(DriverBellRingFlagKey, false); }
            set { AppSettings.AddOrUpdateValue(DriverBellRingFlagKey, value); }
        }

        public static bool DriverComplitedFlag
        {
            get { return AppSettings.GetValueOrDefault<bool>(DriverComplitedFlagKey, false); }
            set { AppSettings.AddOrUpdateValue(DriverComplitedFlagKey, value); }
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