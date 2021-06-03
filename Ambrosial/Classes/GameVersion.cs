using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambrosial.Ambrosial.Classes
{
    public class GameVersion
    {
        [JsonProperty]
        public string name;
        public List<Client> clients = new List<Client>();

        public GameVersion(string name)
        {
            this.name = name;
        }
    }
}
