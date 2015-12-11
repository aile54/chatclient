using System;
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
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

    [StructLayout(LayoutKind.Sequential)]
    private struct FLASHWINFO
    {
        /// <summary>
        /// The size of the structure in bytes.
        /// </summary>
        public uint cbSize;
        /// <summary>
        /// A Handle to the Window to be Flashed. The window can be either opened or minimized.
        /// </summary>
        public IntPtr hwnd;
        /// <summary>
        /// The Flash Status.
        /// </summary>
        public uint dwFlags;
        /// <summary>
        /// The number of times to Flash the window.
        /// </summary>
        public uint uCount;
        /// <summary>
        /// The rate at which the Window is to be flashed, in milliseconds. If Zero, the function uses the default cursor blink rate.
        /// </summary>
        public uint dwTimeout;
    }

    /// <summary>
    /// Stop flashing. The system restores the window to its original stae.
    /// </summary>
    public const uint FLASHW_STOP = 0;

    /// <summary>
    /// Flash the window caption.
    /// </summary>
    public const uint FLASHW_CAPTION = 1;

    /// <summary>
    /// Flash the taskbar button.
    /// </summary>
    public const uint FLASHW_TRAY = 2;

    /// <summary>
    /// Flash both the window caption and taskbar button.
    /// This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
    /// </summary>
    public const uint FLASHW_ALL = 3;

    /// <summary>
    /// Flash continuously, until the FLASHW_STOP flag is set.
    /// </summary>
    public const uint FLASHW_TIMER = 4;

    /// <summary>
    /// Flash continuously until the window comes to the foreground.
    /// </summary>
    public const uint FLASHW_TIMERNOFG = 12;


    /// <summary>
    /// Flash the spacified Window (Form) until it recieves focus.
    /// </summary>
    /// <param name="form">The Form (Window) to Flash.</param>
    /// <returns></returns>
    public static bool Flash(System.Windows.Forms.Form form)
    {
        // Make sure we're running under Windows 2000 or later
        if (Win2000OrLater)
        {
            FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL | FLASHW_TIMERNOFG, uint.MaxValue, 0);
            return FlashWindowEx(ref fi);
        }
        return false;
    }

    private static FLASHWINFO Create_FLASHWINFO(IntPtr handle, uint flags, uint count, uint timeout)
    {
        FLASHWINFO fi = new FLASHWINFO();
        fi.cbSize = Convert.ToUInt32(Marshal.SizeOf(fi));
        fi.hwnd = handle;
        fi.dwFlags = flags;
        fi.uCount = count;
        fi.dwTimeout = timeout;
        return fi;
    }

    /// <summary>
    /// Flash the specified Window (form) for the specified number of times
    /// </summary>
    /// <param name="form">The Form (Window) to Flash.</param>
    /// <param name="count">The number of times to Flash.</param>
    /// <returns></returns>
    public static bool Flash(System.Windows.Forms.Form form, uint count)
    {
        if (Win2000OrLater)
        {
            FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, count, 0);
            return FlashWindowEx(ref fi);
        }
        return false;
    }

    /// <summary>
    /// Start Flashing the specified Window (form)
    /// </summary>
    /// <param name="form">The Form (Window) to Flash.</param>
    /// <returns></returns>
    public static bool Start(System.Windows.Forms.Form form)
    {
        if (Win2000OrLater)
        {
            FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, uint.MaxValue, 0);
            return FlashWindowEx(ref fi);
        }
        return false;
    }

    /// <summary>
    /// Stop Flashing the specified Window (form)
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public static bool Stop(System.Windows.Forms.Form form)
    {
        if (Win2000OrLater)
        {
            FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_STOP, uint.MaxValue, 0);
            return FlashWindowEx(ref fi);
        }
        return false;
    }

    /// <summary>
    /// A boolean value indicating whether the application is running on Windows 2000 or later.
    /// </summary>
    private static bool Win2000OrLater
    {
        get { return System.Environment.OSVersion.Version.Major >= 5; }
    }
}