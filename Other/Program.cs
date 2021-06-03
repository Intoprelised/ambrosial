using Ambrosial.Ambrosial;
using DiscordRPC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Drawing.Text;
using Microsoft.Win32;
using Ambrosial.Ambrosial.Classes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Ambrosial
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateFile(string lpFileName
            , [MarshalAs(UnmanagedType.U4)] DesiredAccess dwDesiredAccess
            , [MarshalAs(UnmanagedType.U4)] FileShare dwShareMode
            , uint lpSecurityAttributes
            , [MarshalAs(UnmanagedType.U4)] FileMode dwCreationDisposition
            , [MarshalAs(UnmanagedType.U4)] FileAttributes dwFlagsAndAttributes
            , uint hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetStdHandle(StdHandle nStdHandle, IntPtr hHandle);

        private enum StdHandle : int
        {
            Input = -10,
            Output = -11,
            Error = -12
        }

        [Flags]
        enum DesiredAccess : uint
        {
            GenericRead = 0x80000000,
            GenericWrite = 0x40000000,
            GenericExecute = 0x20000000,
            GenericAll = 0x10000000
        }

        public static void CreateConsole()
        {
            if (AllocConsole())
            { 
                var stdOutHandle = CreateFile("CONOUT$", DesiredAccess.GenericRead | DesiredAccess.GenericWrite, FileShare.ReadWrite, 0, FileMode.Open, FileAttributes.Normal, 0);
                if (stdOutHandle == new IntPtr(-1))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                if (!SetStdHandle(StdHandle.Output, stdOutHandle))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                var standardOutput = new StreamWriter(Console.OpenStandardOutput());
                standardOutput.AutoFlush = true;
                Console.SetOut(standardOutput);
            }
        }

        [DllImport("gdi32", EntryPoint = "AddFontResource")]
        public static extern int AddFontResourceA(string lpFileName);
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern int AddFontResource(string lpszFilename);
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern int CreateScalableFontResource(uint fdwHidden, string
            lpszFontRes, string lpszFontFile, string lpszCurrentPath);

        private static void RegisterFont(string contentFontName)
        {
            var fontDestination = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts), contentFontName);
            if (!File.Exists(fontDestination))
            {
                System.IO.File.Copy(Path.Combine(System.IO.Directory.GetCurrentDirectory(), contentFontName), fontDestination);
                PrivateFontCollection fontCol = new PrivateFontCollection();
                fontCol.AddFontFile(fontDestination);
                var actualFontName = fontCol.Families[0].Name;
                AddFontResource(fontDestination);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts", actualFontName, contentFontName, RegistryValueKind.String);
            }
        }

        public static bool hasAllocatedConsole;
        public static void allocateConsole()
        {
            CreateConsole();
            Utils.log("Console allocated");
            hasAllocatedConsole = true;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // register font code here
            if (!File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "Azonix.otf"))
            {
                File.WriteAllBytes("Azonix.otf", Properties.Resources.Azonix);
                RegisterFont("Azonix.otf");
                File.Delete("Azonix.otf");
                Utils.log("Azonix.otf font installed");
            }
            if (!File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "OpenSansLight.ttf"))
            {
                File.WriteAllBytes("OpenSansLight.ttf", Properties.Resources.OpenSansLight);
                RegisterFont("OpenSansLight.ttf");
                File.Delete("OpenSansLight.ttf");
                Utils.log("OpenSansLight.ttf font installed");
            }
            if (!File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "YuGothL.ttc"))
            {
                File.WriteAllBytes("YuGothL.ttc", Properties.Resources.YuGothL);
                RegisterFont("YuGothL.ttc");
                File.Delete("YuGothL.ttc");
                Utils.log("YuGothL.ttc font installed");
            }

            if (args.Length > 0)
            {
                if (args.Contains("-debug"))
                {
                    allocateConsole();
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Utils.logfilename = "log.txt";
            string path = Environment.GetEnvironmentVariable("LocalAppData") + @"\Ambrosial\";
            if (File.Exists(path + Utils.logfilename))
                File.Delete(path + Utils.logfilename);
            Utils.log("Ambrosial launched!");
            AmbrosialC.setupClients();
            Utils.log("Finished calling setupClients function.");
            if(!hasAllocatedConsole && AmbrosialC.SettingsJson.shouldLaunchDebug)
            {
                allocateConsole();
            }
            DiscordRpcClient client = new DiscordRpcClient("835521960767127584");
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                State = "Menu || " + AmbrosialC.installedVersion,
                Assets = new Assets
                {
                    LargeImageKey = "ambrosial",
                }
            });
            Utils.log("Discord Rich Presence initialized.");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Utils.log("Loading main UI...");
            Application.Run(new Launcher());
        }
    }
}
