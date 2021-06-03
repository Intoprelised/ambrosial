using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ambrosial.Ambrosial.Classes
{
    public class SettingsJson
    {
        [JsonProperty]
        public bool shouldGetVersion;
        [JsonProperty]
        public bool shouldLaunchDebug;

        public SettingsJson()
        {
        }

        public string getEncrypted()
        {
            return AmbrosialEncrypt.Encrypt(JsonConvert.SerializeObject(this));
        }

    }
}
