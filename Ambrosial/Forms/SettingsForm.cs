using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ambrosial.Ambrosial.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minbut_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void shouldcheck_CheckedChanged(object sender, EventArgs e)
        {

            //loading
            AmbrosialC.SettingsJson.shouldGetVersion = shouldcheck.Checked;
        }

        private void saveBut_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Utils.ambrosialPath + $@"\assets\userimport\");
            if (File.Exists(Utils.ambrosialPath + $@"\assets\userimport\AmbrosialConfig-SettingsJson.amb"))
                File.Delete(Utils.ambrosialPath + $@"\assets\userimport\AmbrosialConfig-SettingsJson.amb");
            File.WriteAllText(Utils.ambrosialPath + $@"\assets\userimport\AmbrosialConfig-SettingsJson.amb", AmbrosialC.SettingsJson.getEncrypted());
        }



        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            AmbrosialC.SettingsJson.shouldLaunchDebug = guna2CheckBox1.Checked;
        }

        private void SettingsForm_Load_1(object sender, EventArgs e)
        {
            // startup
            shouldcheck.Checked = AmbrosialC.SettingsJson.shouldGetVersion;
            guna2CheckBox1.Checked = AmbrosialC.SettingsJson.shouldLaunchDebug;
        }
    }
}
