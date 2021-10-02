using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            // Make empty packet
            Packet jsonpacket = new Packet(null);

            // URL to encrypted JSON with serialized clients
            // Temporary fix (hopefully): change request URL to GitHub
            string requestEnd = "https://raw.githubusercontent.com/disepi/ambrosial/main/cachedclients.json";

        getPkt:
            // Attempt to get info
            try
            {
                string result = Utils.request(requestEnd);
                if(result == "")
                    throw new JsonException("JSON could not be downloaded");

                // Error will be thrown before it can reach this
                jsonpacket = new Packet(Utils.request(requestEnd));

                // Make folder to fix error...
                Directory.CreateDirectory(Utils.ambrosialPath + $@"\assets\clients\");


                File.WriteAllText(Utils.ambrosialPath + $@"\assets\clients\cachedclients.json", result);
                Utils.log($"Downloaded & cached clients.");
            }
            catch(Exception e)
            {
                // error logging
                MessageBox.Show("Error!\n" + e.Message.ToString() + "\n\nStacktrace: \n" + e.StackTrace.ToString(), "Error");


                // sorta spaghetti code but it works
                DialogResult dialogResult = MessageBox.Show("Server couldnt be contacted. Do you wish to use the client cache?", "Error", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (File.Exists(Utils.ambrosialPath + $@"\assets\clients\cachedclients.json"))
                        jsonpacket = new Packet(File.ReadAllText(Utils.ambrosialPath + $@"\assets\clients\cachedclients.json"));
                    else
                    {
                        DialogResult dialogResult2 = MessageBox.Show("Cache has not been made yet. Do you wish to redirect the request URL?", "Error", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            string url = Microsoft.VisualBasic.Interaction.InputBox("Change request URL", "Ambrosial", "");
                            if(url != "" && url != null)
                            {
                                requestEnd = url;
                                goto getPkt;
                            }
                            else
                                Process.GetCurrentProcess().Kill();
                        }
                        else
                            Process.GetCurrentProcess().Kill();
                    }
                }
                else
                    Process.GetCurrentProcess().Kill();
            }



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
