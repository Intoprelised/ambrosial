using Ambrosial.Ambrosial.Classes;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ambrosial.Ambrosial.Forms
{
    public partial class DeveloperForm : Form
    {
        public DeveloperForm()
        {
            InitializeComponent();
        }
        private string alphaChars;
        private string GenerateRandomString(int length)
        {
            this.alphaChars = @"!#$%&*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{}~";
            VBMath.Randomize();
            string temp = "";
            checked
            {
                for (int x = 0; x <= length; x++)
                {
                    int i = (int)Math.Round(Math.Floor((double)(unchecked((float)(checked(this.alphaChars.Length - 1 + 1)) * VBMath.Rnd())))) + 1;
                    temp += Strings.Mid(this.alphaChars, i, 1);
                }
                return temp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Client c in AmbrosialC.clientRegistry)
            {
                c.bannerphotoPath = "";
                c.hasCachedPanel = false;
            }
            string rand = GenerateRandomString(15);
            richTextBox1.Text = Cipher.Encrypt(richTextBox1.Text, rand);
            richTextBox1.Text += "[AmbrosialPacket]" + rand;
            richTextBox1.Text = Cipher.EncryptBase64(richTextBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Client c in AmbrosialC.clientRegistry)
            {
                c.bannerphotoPath = "";
                c.hasCachedPanel = false;
            }
            string clientRegistrySerialized = "";
            bool islast = false;
            int i = 0;
            foreach (Client c in AmbrosialC.clientRegistry)
            {
                if (i >= AmbrosialC.clientRegistry.Count - 1 )
                    islast = true;
                clientRegistrySerialized += c.getSerialized();
                if (!islast)
                {
                    clientRegistrySerialized += "[<JSON_END>]";
                }
                i++;
            }
            string rand = GenerateRandomString(15);
            clientRegistrySerialized = Cipher.Encrypt(clientRegistrySerialized, rand);
            clientRegistrySerialized += "[AmbrosialPacket]" + rand;
            clientRegistrySerialized = Cipher.EncryptBase64(clientRegistrySerialized);
            richTextBox2.Text = clientRegistrySerialized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(Client c in AmbrosialC.clientRegistry)
            {
                c.bannerphotoPath = "";
                c.hasCachedPanel = false;
            }
            string decryptedBasePacket = Cipher.DecryptBase64(richTextBox3.Text);
            string[] packInfo = decryptedBasePacket.Split(new string[] { "[AmbrosialPacket]" }, StringSplitOptions.RemoveEmptyEntries);
            string decrypted = Cipher.Decrypt(packInfo[0], packInfo[1]);
            richTextBox3.Text = decrypted;
        }

        private void DeveloperForm_Load(object sender, EventArgs e)
        {

        }
    }
}
