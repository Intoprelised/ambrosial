using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambrosial.Ambrosial.Classes
{
    public class Packet
    {
        [JsonProperty]
        public string packetData;
        [JsonProperty]
        public bool hasCachedPacketClients = false;
        [JsonProperty]
        public List<Client> cachedPacketClients;
        [JsonProperty]
        public string key;


        public Packet(string packetData)
        {
            if (packetData != "" && packetData != null)
            {
                Utils.log("Requested JSON type packet from URL.");
                string decryptedBasePacket = Cipher.DecryptBase64(packetData);
                string[] packInfo = decryptedBasePacket.Split(new string[] { "[AmbrosialPacket]" }, StringSplitOptions.RemoveEmptyEntries);
                this.key = packInfo[1];
                this.packetData = packInfo[0];
                this.decryptPacket();
            }
            else
            {
                this.key = "";
                this.packetData = "";
            }
        }


        // For decrypting after packet was made
        public void decryptPacket2()
        {
            string decryptedBasePacket = Cipher.DecryptBase64(packetData);
            string[] packInfo = decryptedBasePacket.Split(new string[] { "[AmbrosialPacket]" }, StringSplitOptions.RemoveEmptyEntries);
            this.key = packInfo[1];
            this.packetData = packInfo[0];
            this.decryptPacket();
        }

        public void decryptPacket()
        {
            Utils.log("Decrypted packet at " + DateTime.Now.ToString());
            this.packetData = Cipher.Decrypt(this.packetData, this.key);
        }

        public List<Client> getData()
        {
            if (!hasCachedPacketClients)
            {
                string[] jsonClients = packetData.Split(new string[] { "[<JSON_END>]" }, StringSplitOptions.RemoveEmptyEntries);
                List<Client> clients = new List<Client>();
                foreach (string line in jsonClients)
                    clients.Add(JsonConvert.DeserializeObject<Client>(line));
                if (clients != null)
                {
                    cachedPacketClients = clients;
                    hasCachedPacketClients = true;
                }
                return clients;
            }
            else
            {
                return cachedPacketClients;
            }
        }
    }
}
