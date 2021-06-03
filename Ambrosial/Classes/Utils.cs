using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ambrosial.Ambrosial;
using DiscordRPC;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Ambrosial.Ambrosial.Classes;

namespace Ambrosial.Ambrosial
{
    class Utils
    {

        public static int i = 0;
        public static string getVer()
        {
            i = 0;
            string result = "None detected";
            foreach (string path in Directory.GetDirectories(@"C:\Program Files\WindowsApps"))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                if (directoryInfo.Name.StartsWith("Microsoft.MinecraftUWP_"))
                {
                    i++;
                    result = directoryInfo.Name.Split(new char[] { '_' })[1];
                }
            }
            return result;
        }
        public static string TrimEnd(string input, string suffixToRemove, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            if (suffixToRemove != null && input.EndsWith(suffixToRemove, comparisonType))
            {
                return input.Substring(0, input.Length - suffixToRemove.Length);
            }

            return input;
        }

        public static readonly string ambrosialPath = Environment.GetEnvironmentVariable("LocalAppData") + @"\Ambrosial\";


        public static string requestLocalText(string path)
        {
            return File.ReadAllText(ambrosialPath + path);
        }
        public static string getTruePath(string path, string link)
        {
            try
            {
                string[] pathSplit = path.Split('\\');
                string[] linkSplit = link.Split('/');
                string file = linkSplit[linkSplit.Count() - 1];
                string pathFile = pathSplit[pathSplit.Count() - 1];
                if (pathFile.Contains("."))
                    return path;
                string path2 = path;
                if (path2.EndsWith(@"\"))
                    path2.TrimEnd('\\');
                else
                    path2 += @"\";
                return path2 + file;
            }
            catch {  }
            return "";
        }

        public static string getExeNameFromPath(string path)
        {
            try
            {
                string[] pathSplit = path.Split('\\');
                return pathSplit[pathSplit.Length];
            }
            catch { }
            return "";
        }

        public static void Serialize(object obj, string path = "Ambrosial.json")
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj);
                sw.Dispose();
                writer.Close();
            }
        }

        public static string logfilename;
        public static bool doneFirstWrite;

        public static void log(string line)
        {
            string path = Environment.GetEnvironmentVariable("LocalAppData") + @"\Ambrosial\";
            if (!doneFirstWrite)
            {
                Directory.CreateDirectory(path);
                doneFirstWrite = true;
            }
            try
            {
                using (StreamWriter sw = File.AppendText(path + logfilename))
                {
                    sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff") + " || [AMBROSIAL-LAUNCHER] : " + line);
                    Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff") + " || [AMBROSIAL-LAUNCHER] : " + line);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch { }
        }
        public static void applyAppPackages(string DLLPath)
        {
            FileInfo fileInfo = new FileInfo(DLLPath);
            FileSecurity accessControl = fileInfo.GetAccessControl();
            accessControl.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier("S-1-15-2-1"), FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            fileInfo.SetAccessControl(accessControl);
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        // Token: 0x06000038 RID: 56
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        // Token: 0x06000039 RID: 57
        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        // Token: 0x0600003A RID: 58
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        // Token: 0x0600003B RID: 59
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        // Token: 0x0600003C RID: 60
        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        public static void inject(string path)
        {
            if (Process.GetProcessesByName("Minecraft.Windows").Length != 0)
            {
                applyAppPackages(path);
                Process process = Process.GetProcessesByName("Minecraft.Windows")[0];
                IntPtr hProcess = OpenProcess(1082, false, process.Id);
                IntPtr procAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                IntPtr intPtr = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)((path.Length + 1) * Marshal.SizeOf(typeof(char))), 12288U, 4U);
                UIntPtr uintPtr;
                WriteProcessMemory(hProcess, intPtr, Encoding.Default.GetBytes(path), (uint)((path.Length + 1) * Marshal.SizeOf(typeof(char))), out uintPtr);
                CreateRemoteThread(hProcess, IntPtr.Zero, 0U, procAddress, intPtr, 0U, IntPtr.Zero);
                return;
            }
        }
        public static object Deserialize(string path)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamReader(path))
            using (var reader = new JsonTextReader(sw))
            {
                return serializer.Deserialize(reader);
            }
        }
        static WebClient client = new WebClient();
        public static string request(string link)
        {
            return client.DownloadString(link);
        }
    }
}
