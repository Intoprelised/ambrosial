using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ambrosial.Ambrosial;
using Ambrosial.Ambrosial.Classes;
using Newtonsoft.Json;

namespace Ambrosial.Ambrosial
{
    public class AmbrosialC
    {
        public static string installedVersion;
        public static List<Client> clientRegistry = new List<Client>();
        public static SettingsJson SettingsJson = new SettingsJson();
        public static List<GameVersion> versionRegistry = new List<GameVersion>();

        public static void setupClients()
        {
            Utils.log("Attempting to get installed version");
            installedVersion = Utils.getVer();
            Utils.log("Found installed game version: " + installedVersion);
            Packet jsonpacket = new Packet(Utils.request("https://sefrum.tech/Ambrosial/main.json"));
            foreach (Client c in jsonpacket.getData())
            {
                if (!versionRegistry.Any(gver => gver.name == c.version))
                {
                    versionRegistry.Add(new GameVersion(c.version));
                    Utils.log("Version added to Version Registry - (" + c.version + ")");
                }
                clientRegistry.Add(c);
                c.downloadResources();
                Utils.log("Client added to Client Registry - (\"" + c.name + "\")");
            }
            if (File.Exists(Utils.ambrosialPath + $@"\assets\userimport\AmbrosialConfig-SettingsJson.amb"))
            {
                Utils.log("Found AmbrosialConfig-SettingsJson.amb");
                SettingsJson = JsonConvert.DeserializeObject<SettingsJson>(AmbrosialEncrypt.Decrypt(Utils.requestLocalText($@"\assets\userimport\AmbrosialConfig-SettingsJson.amb")));
            }
            int i = 0;
            if (Directory.Exists(Utils.ambrosialPath + $@"\assets\userimport\importedclients\"))
            {
                Utils.log("Found UserImport folder");
                foreach (FileInfo file in new DirectoryInfo(Utils.ambrosialPath + $@"\assets\userimport\importedclients\").GetFiles())
                {
                    Utils.log("Scanning file " + file.FullName);
                    Client c = JsonConvert.DeserializeObject<Client>(AmbrosialEncrypt.Decrypt(File.ReadAllText(file.FullName + "")));
                    if (!versionRegistry.Any(gver => gver.name == c.version))
                    {
                        versionRegistry.Add(new GameVersion(c.version));
                        Utils.log("Custom version added to Version Registry - (" + c.version + ")");
                    }
                    clientRegistry.Add(c);
                    c.downloadResources();
                    Utils.log("Imported client added to Client Registry - (\"" + c.name + "\")");
                    i++;
                }
                Utils.log("Total of " + i + " custom clients imported");
            }
            foreach (GameVersion version in versionRegistry)
            {
                foreach(Client c in clientRegistry)
                {
                    if(c.version == version.name)
                    {
                        version.clients.Add(c);
                        Utils.log($"Matched client to version - ({c.name} matched for version {version.name})");
                    }    
                }
            }
        }
    }
}
