using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace Ambrosial.Ambrosial.Classes
{
    public class Client
    {
        [JsonProperty]
        public string name;
        [JsonProperty]
        public string[] types;
        [JsonProperty]
        public string link;
        [JsonProperty]
        public string bannerPhoto;
        [JsonProperty]
        public string latestUpdateInfo;
        [JsonProperty]
        public string exeName;
        [JsonProperty]
        public ClientTypes.Type clientType;
        [JsonProperty]
        public string version;
        [JsonProperty]
        public string clientVersion;
        [JsonProperty]
        public bool storedInZip;
        [JsonProperty]
        public bool ignoreCache;
        [JsonProperty]
        public string externalLink = "";
        [JsonIgnore]
        public string bannerphotoPath;
        [JsonIgnore]
        public bool hasCachedPanel = false;

        public Client(string name, string[] types, string link, string bannerPhoto, string latestUpdateInfo, string exeName, ClientTypes.Type clientType, string version, string clientVersion, bool storedInZip, bool ignoreCache = false)
        {
            this.name = name;
            this.types = types;
            this.link = link;
            this.bannerPhoto = bannerPhoto;
            this.latestUpdateInfo = latestUpdateInfo;
            this.exeName = exeName;
            this.clientType = clientType;
            this.version = version;
            this.clientVersion = clientVersion;
            this.storedInZip = storedInZip;
            this.ignoreCache = ignoreCache;
        }

        public string getSerialized()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void downloadResources()
        {
            if (!bannerPhoto.Contains(@"\"))
            {
                string pathToFolder = Environment.GetEnvironmentVariable("LocalAppData") + @"\Ambrosial\" + $@"assets\clients\{version}\{name}\launcherAssets\";
                Directory.CreateDirectory(pathToFolder);
                bool isClientCached = false;
                string truePath = Utils.getTruePath(pathToFolder, bannerPhoto);
                bannerphotoPath = truePath;
                Utils.log($"Downloading banner asset: Attempted to find true path - {truePath}");
                if (File.Exists(truePath))
                    isClientCached = true;
                if (!isClientCached)
                {
                    Utils.log($"{this.name}'s banner photo hasn't been cached! Starting download...");
                    WebClient client = new WebClient();
                    try
                    {
                        Utils.log("Downloading banner...");
                        client.DownloadFile(this.bannerPhoto, truePath);
                        Utils.log("Downloaded banner, cached.");
                    }
                    catch
                    {
                        Utils.log($"Failed to download banner photo for {this.name}! Downloading fallback picture");
                        try
                        {
                            // backup img
                            client.DownloadFile("https://picsum.photos/624/191?blur=10", truePath);
                            Utils.log("Downloaded fallback banner, cached.");
                        }
                        catch
                        {
                            Utils.log("Failed to download fallback picture, path may be wrong!");
                        }
                    }
                }
                else
                {
                    Utils.log($"Banner photo for {this.name} seems to be cached!");
                }
            }
            else
            {
                Utils.log($"Banner photo for {this.name} seems to be local file");
            }
        }

        private void initInstall()
        {
            bool isClientCached = false;
            string pathToFolder = Environment.GetEnvironmentVariable("LocalAppData") + @"\Ambrosial\" + $@"assets\clients\{version}\{name}\{clientVersion}\";
            Directory.CreateDirectory(pathToFolder);
            Utils.log($"Attempted to create dir {pathToFolder}");
            if (File.Exists(pathToFolder + exeName))
                isClientCached = true;

            // If client requires to be dynamically downloaded all the time
            if (ignoreCache)
            {
                isClientCached = false;
                // Delete otherwise DownloadFile will throw exception
                try
                {
                    File.Delete(pathToFolder + exeName);
                }
                catch
                {
                    MessageBox.Show("Couldn't replace client's file. Is the file open/injected?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (this.clientType == ClientTypes.Type.Exe)
            {
                Utils.log($"Client {name} seems to be an EXE type file, downloading...");
                if (!isClientCached)
                {
                    Utils.log($"{name} is not cached!");
                    WebClient client = new WebClient();
                    if (!storedInZip)
                    {
                        try
                        {
                            client.DownloadFile(link, pathToFolder + exeName);
                        }
                        catch (Exception e)
                        {
                            Utils.log($"net.downloadfile error: {e.Message}");
                        }
                        Utils.log($"Downloaded file {exeName}");
                    }
                    else
                    {
                        foreach (FileInfo file in new DirectoryInfo(pathToFolder).GetFiles())
                            file.Delete();
                        try
                        {
                            client.DownloadFile(link, $@"{pathToFolder}{name}{clientVersion}.zip");
                        }
                        catch (Exception e)
                        {
                            Utils.log($"net.downloadfile error: {e.Message}");
                        }
                        Utils.log($"Downloaded file {name}{clientVersion}.zip");
                        try
                        {
                            ZipFile.ExtractToDirectory($@"{pathToFolder}{name}{clientVersion}.zip", pathToFolder);
                        }
                        catch (Exception e)
                        {
                            Utils.log($"zip.extract error: {e.Message}");
                        }
                        Utils.log($"Extracted file {name}{clientVersion}.zip");
                    }
                    Utils.log($"{name} downloaded. Cached.");
                    client.Dispose();
                    isClientCached = true;
                }
                else
                {
                    Utils.log($"{name} seems to be cached! Canceled download.");
                }
                string trueExeName;
                if (!exeName.Contains(@"\"))
                    trueExeName = exeName;
                else
                    trueExeName = Utils.getExeNameFromPath(exeName);
                if (Process.GetProcessesByName(Utils.TrimEnd(trueExeName, ".exe")).Length == 0)
                {
                    Process.Start(pathToFolder + exeName);
                    Utils.log($"{name} has been launched at {DateTime.Now}");
                }
                else
                {
                    MessageBox.Show($"{name} is already open! Close it to launch again.", "Already open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Utils.log($"{name} attempted to launch at {DateTime.Now}, already opened!");
                }
            }
            if (this.clientType == ClientTypes.Type.Dll)
            {
                Utils.log($"Client {name} seems to be an DLL type file, downloading...");
                if (!isClientCached)
                {
                    Utils.log($"{name} is not cached!");
                    WebClient client = new WebClient();
                    if (!storedInZip)
                    {
                        try
                        {
                            client.DownloadFile(link, pathToFolder + exeName);
                        }
                        catch (Exception e)
                        {
                            Utils.log($"net.downloadfile error: {e.Message}");
                        }
                        Utils.log($"Downloaded file {exeName}");
                    }
                    else
                    {
                        foreach (FileInfo file in new DirectoryInfo(pathToFolder).GetFiles())
                            file.Delete();
                        try
                        {
                            client.DownloadFile(link, $@"{pathToFolder}{name}{clientVersion}.zip");
                        }
                        catch (Exception e)
                        {
                            Utils.log($"net.downloadfile error: {e.Message}");
                        }
                        Utils.log($"Downloaded file {name}{clientVersion}.zip");
                        try
                        {
                            ZipFile.ExtractToDirectory($@"{pathToFolder}{name}{clientVersion}.zip", pathToFolder);
                        }
                        catch (Exception e)
                        {
                            Utils.log($"zip.extract error: {e.Message}");
                        }
                        Utils.log($"Extracted file {name}{clientVersion}.zip");
                    }
                    Utils.log($"{name} downloaded. Cached.");
                    client.Dispose();
                    isClientCached = true;
                }
                else
                    Utils.log($"{name} seems to be cached! Canceled download.");
                foreach (FileInfo file in new DirectoryInfo(pathToFolder).GetFiles())
                {
                    if (!file.FullName.Contains(exeName) && file.FullName.Contains(@"\"))
                        Utils.inject(file.FullName);
                }
                Utils.inject(pathToFolder + exeName);
                Utils.log($"{name} ({exeName}) has been injected at {DateTime.Now}");
            }
        }

        public void install()
        {
            Utils.log("Install function called for " + this.name);
            if (Process.GetProcessesByName("Minecraft.Windows").Length != 0)
            {
                if (AmbrosialC.SettingsJson.shouldGetVersion)
                {
                    if (!AmbrosialC.installedVersion.Contains(version))
                    {
                        Utils.log($"Comparing versions - Client version is {this.version}, installed version is {AmbrosialC.installedVersion}.");
                        MessageBox.Show($"This utility is not compatible with your version. Please downgrade/upgrade to be able to use it. (You are on {AmbrosialC.installedVersion}, required version is {this.version}", "Version mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                initInstall();
            }
            else
                MessageBox.Show("Open Minecraft first!", "Minecraft process not found.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
    public class ClientTypes
    {
        public enum Type
        {
            Exe,
            Dll
        }
    }
}
