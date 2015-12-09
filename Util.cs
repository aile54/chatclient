﻿using System;
using System.Collections;
using System.IO;
using System.Text;
using Matrix.Xml;
using Matrix.Xmpp;
using Matrix.Xmpp.Client;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows;

namespace MiniClient
{
    public class Util
    {

        private static string _settingsFolder;
        private static string _settingsFilename;

        private static Hashtable _chatForms = new Hashtable();


        public static Hashtable ChatForms
        {
            get { return _chatForms; }
        }

        private static string SettingsFolder
        {
            get
            {
                if (_settingsFolder == null)
                {
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                               "MiniClient");
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    _settingsFolder = path;
                }
                return _settingsFolder;
            }
        }

        private static string SettingsFilename
        {
            get
            {
                if (_settingsFilename == null)
                    _settingsFilename = Path.Combine(SettingsFolder, "settings.xml");
                
                return _settingsFilename;
            }
        }
        
        public static Settings.Settings LoadSettings()
        {
            XmppXElement set = null;
            if (File.Exists(SettingsFilename))
            {
                set = XmppXElement.LoadXml(File.ReadAllText(SettingsFilename));
                
            }
            if (set is Settings.Settings)
                    return set as Settings.Settings;
            
            return new Settings.Settings();
        }

        public static void SaveSettings(Settings.Settings set)
        {
            set.Save(SettingsFilename);
        }

        public static int GetRosterImageIndex(Presence pres)
        {
            if (pres.Type == PresenceType.Unavailable)
                return 0;

            switch (pres.Show)
            {
                case Show.Chat:
                    return 1;
                case Show.Away:
                    return 2;
                case Show.ExtendedAway:
                    return 2;
                case Show.DoNotDisturb:
                    return 3;
                default:
                    return 1;
            }
        }

        /// <summary>
        /// Converts the Numer of bytes to a human readable string
        /// </summary>
        /// <param name="lBytes"></param>
        /// <returns></returns>
        public static string HumanReadableFileSize(long lBytes)
        {
            var sb = new StringBuilder();
            string strUnits = "Bytes";
            float fAdjusted = 0.0F;

            if (lBytes > 1024)
            {
                if (lBytes < 1024 * 1024)
                {
                    strUnits = "KB";
                    fAdjusted = Convert.ToSingle(lBytes) / 1024;
                }
                else
                {
                    strUnits = "MB";
                    fAdjusted = Convert.ToSingle(lBytes) / 1048576;
                }
                sb.AppendFormat("{0:0.0} {1}", fAdjusted, strUnits);
            }
            else
            {
                fAdjusted = Convert.ToSingle(lBytes);
                sb.AppendFormat("{0:0} {1}", fAdjusted, strUnits);
            }

            return sb.ToString();
        }

    }
}

public static class FlashWindow
{
    public const int FLASHW_STOP = 0;
    public const int FLASHW_CAPTION = 0x00000001;
    public const int FLASHW_TRAY = 0x00000002;
    public const int FLASHW_ALL = (FLASHW_CAPTION | FLASHW_TRAY);
    public const int FLASHW_TIMER = 0x00000004;
    public const int FLASHW_TIMERNOFG = 0x0000000C;

    [StructLayout(LayoutKind.Sequential)]
    public struct FLASHWINFO
    {
        [MarshalAs(UnmanagedType.U4)]
        public int cbSize;
        public IntPtr hwnd;
        [MarshalAs(UnmanagedType.U4)]
        public int dwFlags;
        [MarshalAs(UnmanagedType.U4)]
        public int uCount;
        [MarshalAs(UnmanagedType.U4)]
        public int dwTimeout;
    }

    [DllImport("user32.dll")]
    public static extern bool FlashWindowEx([MarshalAs(UnmanagedType.Struct)]
                  ref FLASHWINFO pfwi);
}