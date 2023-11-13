using Discord;
using DiscordRPC;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace iTunes_RPC
{
    public partial class Form1 : Form
    {
        public string minToTray = "No";

        public Form1()
        {
            InitializeComponent();
            string filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "Apple Music RP", "settings.txt");
            if (System.IO.File.Exists(filePath))
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                if (lines[0] == "Yes")
                {
                    minToTray = "Yes";
                }
                else
                {
                    minToTray = "No";
                }
            }
            else
            {
                minToTray = "No";
            }
        }

        public bool isDiscordRunning()
        {
            Process[] pname = Process.GetProcessesByName("Discord");
            if (pname.Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool isDuplicateRunning()
        {
            Process[] pname = Process.GetProcessesByName("iTunes RPC");
            if (pname.Length == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (isDuplicateRunning())
            {
                MessageBox.Show("iTunes RPC is already running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                Application.DoEvents();

            }
            client.Initialize();
            timer1.Start();

        }

        public DiscordRpcClient client = new DiscordRpcClient("1173654168892870777");

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isDuplicateRunning())
            {
                Form1.ActiveForm.Close();
            }
            if (isDiscordRunning())
            {
                // Set variables
                string songName = iTunesInfo.getSongName();
                string songArtist = iTunesInfo.getSongArtist();
                int songCurrentTime = iTunesInfo.getSongCurrentTime(); // in seconds, not unix time
                int songEndTime = iTunesInfo.getSongEndTime(); // in seconds, not unix time

                // Using songCurrentTime and songEndTime, calculate the unix time for the start and end of the song in DateTime format
                DateTime songStart = DateTime.Now.AddSeconds(-songCurrentTime);
                DateTime songEnd = DateTime.Now.AddSeconds(songEndTime - songCurrentTime);

                Timestamps timestamps = new Timestamps()
                {
                    Start = songStart,
                    End = songEnd
                };

                // Set the Rich Presence



                client.SetPresence(new RichPresence()
                {
                    Details = songName,
                    State = songArtist,
                    Timestamps = timestamps,
                    Assets = new Assets()
                    {
                        LargeImageKey = "apple_music",
                        LargeImageText = "Apple Music",
                        SmallImageKey = "itunes",
                        SmallImageText = "iTunes"
                    }
                });

                // Set text
                songTitleLabel.Text = songName;
                songArtistLabel.Text = songArtist;
                int songCurMin = songCurrentTime / 60;
                int songCurSec = songCurrentTime % 60;
                int songEndMin = songEndTime / 60;
                int songEndSec = songEndTime % 60;
                string songCurSecStr = songCurSec.ToString();
                string songEndSecStr = songEndSec.ToString();
                if (songCurSec < 10)
                {
                    songCurSecStr = "0" + songCurSecStr;
                }
                if (songEndSec < 10)
                {
                    songEndSecStr = "0" + songEndSecStr;
                }
                songDurationLabel.Text = songCurMin + ":" + songCurSecStr + " / " + songEndMin + ":" + songEndSecStr;

            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized
            //hide it from the task bar
            //and show the system tray icon (represented by the NotifyIcon control)
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
            }
            else if (e.Button == MouseButtons.Right)
            {
                notifyIcon1.ContextMenuStrip.Show();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!notifyIcon1.Visible && isDiscordRunning() && minToTray == "Yes")
            {
                Hide();
                notifyIcon1.Visible = true;
                e.Cancel = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Exit
            Application.Exit();

        }

        private void Settings_Click_1(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
            string filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "Apple Music RP", "settings.txt");
            if (System.IO.File.Exists(filePath))
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                if (lines[0] == "Yes")
                {
                    minToTray = "Yes";
                }
                else
                {
                    minToTray = "No";
                }
            }
            else
            {
                minToTray = "No";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void pausePlayButton_Click(object sender, EventArgs e)
        {
            if (isPaused)
            {
                var ei = new iTunesInfo();
                ei.playSong();
                isPaused = false;
                pausePlayButton.BackgroundImage = Properties.Resources.pause;
            }
            else
            {
                var ei = new iTunesInfo();
                ei.pauseSong();
                isPaused = true;
                pausePlayButton.BackgroundImage = Properties.Resources.play;
            }
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            var ei = new iTunesInfo();
            ei.nextSong();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var ei = new iTunesInfo();
            ei.previousSong();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

 
    }
}