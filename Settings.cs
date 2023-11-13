using Discord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTunes_RPC
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            getSettings();
        }

        private void getSettings()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Apple Music RP", "settings.txt");
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines[0] == "Yes")
                {
                    comboBox1.Text = "Yes";
                }
                else
                {
                    comboBox1.Text = "No";
                }
            }
            else
            {
                comboBox1.Text = "No";
            }
        }

        private void Settings_FormClosing(Object sender, FormClosingEventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Apple Music RP", "settings.txt");
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Apple Music RP"));
            }
            if (comboBox1.Text == "Yes")
            {
                File.WriteAllText(filePath, "Yes");
            }
            else
            {
                File.WriteAllText(filePath, "No");
            }
        }
    }
}
