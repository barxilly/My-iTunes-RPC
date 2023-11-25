using DiscordRPC;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace iTunes_RPC
{
    public partial class Form1 : Form
    {
        private Label[] labels;
        private System.Windows.Forms.Button[] buttons;

        public string minToTray = "No";

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

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
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            labels = new Label[] { songTitleLabel, songArtistLabel, songDurationLabel };
            buttons = new System.Windows.Forms.Button[] { pausePlayButton, skipButton, backButton, settings, Xbutton, minButton };
            // Set form properties
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Gray;  // Adjust background color as needed

            // Hook up event handlers
            this.MouseDown += MyForm_MouseDown;
            this.MouseMove += MyForm_MouseMove;
            this.Paint += MyForm_Paint;
        }

        private Point lastPoint;

        private void MyForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Remember the last mouse position when the left button is pressed
            if (e.Button == MouseButtons.Left)
            {
                lastPoint = new Point(e.X, e.Y);
            }
        }

        private void MyForm_MouseMove(object sender, MouseEventArgs e)
        {
            // Move the form when the left button is held down
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MyForm_Paint(object sender, PaintEventArgs e)
        {
            // Draw a custom border around the form
            using (Pen pen = new Pen(Color.Black, 2))
            {
               
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

        private bool isWindowsDarkMode()
        {
            string registryKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            string keyName = "AppsUseLightTheme";
            int keyValue = (int)Registry.GetValue(registryKey, keyName, 1);
            if (keyValue == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isWindowsDarkMode())
            {
                string keyy = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Accent";
                string keyNamee = "AccentColorMenu";
                int keyValue = (int)Registry.GetValue(keyy, keyNamee, 1);
                // Convert from bgr to rgb
                int alpha = 255;
                int blue = (keyValue & 0xFF0000) >> 16;
                int green = (keyValue & 0xFF00) >> 8;
                int red = keyValue & 0xFF;
                int keyVal = (alpha << 24) + (red << 16) + (green << 8) + blue;
                Color bg = Color.FromArgb(keyVal);
                panel1.BackColor = bg;
                songTitleLabel.BackColor = bg;
                songArtistLabel.BackColor = bg;
                songDurationLabel.BackColor = bg;
                settings.FlatStyle = FlatStyle.Flat;
                this.BackColor = bg;
                FormBorderStyle = FormBorderStyle.None;
                foreach (Label label in labels)
                {
                    label.ForeColor = System.Drawing.Color.White;
                }
                foreach (System.Windows.Forms.Button button in buttons)
                {
                    button.ForeColor = System.Drawing.Color.White;
                    if (button.BackgroundImage != null)
                    {
                        Bitmap pic = new Bitmap(button.BackgroundImage);
                        // Loop through the images pixels to flip black to white. If it isn't black, make it bg.
                        for (int x = 0; x < pic.Width; x++)
                        {
                            for (int y = 0; y < pic.Height; y++)
                            {
                                Color pixelColor = pic.GetPixel(x, y);
                                if (pixelColor == Color.Black)
                                {
                                    pic.SetPixel(x, y, Color.White);
                                }
                                else
                                {
                                    pic.SetPixel(x, y, bg);
                                }
                            }
                        }
                    }

                }
            }
            else
            {
                // Get the windows theme color
                string keyy = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Accent";
                string keyNamee = "AccentColorMenu";
                int keyValue = (int)Registry.GetValue(keyy, keyNamee, 1);
                // Convert from bgr to rgb
                int alpha = 255;
                int blue = (keyValue & 0xFF0000) >> 16;
                int green = (keyValue & 0xFF00) >> 8;
                int red = keyValue & 0xFF;
                int keyVal = (alpha << 24) + (red << 16) + (green << 8) + blue;
                Color bg = Color.FromArgb(keyVal);
                panel1.BackColor = bg;
                songTitleLabel.BackColor = bg;
                songArtistLabel.BackColor = bg;
                songDurationLabel.BackColor = bg;
                settings.FlatStyle = FlatStyle.Popup;
                this.BackColor = bg;
                FormBorderStyle = FormBorderStyle.None;
                foreach (Label label in labels)
                {
                    label.ForeColor = System.Drawing.Color.Black;
                }
                foreach (System.Windows.Forms.Button button in buttons)
                {
                    button.ForeColor = System.Drawing.Color.Black;
                }
            }
            if (isDuplicateRunning())
            {
                Form1.ActiveForm.Close();
            }
            if (isDiscordRunning())
            {
                try
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
                    // Strip to 15 characters and add ellipsis
                    if (songName.Length > 40)
                    {
                        songName = songName.Substring(0, 40) + "...";
                    }
                    songTitleLabel.Text = songName;
                    // Strip to 15 characters and add ellipsis
                    if (songArtist.Length > 20)
                    {
                        songArtist = songArtist.Substring(0, 20) + "...";
                    }
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
                    progressBar1.Maximum = songEndTime;
                    progressBar1.Value = songCurrentTime;
                    Application.DoEvents();
                    bool p = iTunesInfo.isPaused();
                    if (p)
                    {
                        isPaused = true;
                        pausePlayButton.BackgroundImage = Properties.Resources.play;
                    }
                    else
                    {
                        isPaused = false;
                        pausePlayButton.BackgroundImage = Properties.Resources.pause;
                    }
                }
                catch (Exception)
                {
                    // iTunes is not running
                    client.ClearPresence();
                    songTitleLabel.Text = "No Song Playing";
                    songArtistLabel.Text = "";
                    songDurationLabel.Text = "";
                    progressBar1.Value = 0;
                    Application.DoEvents();
                    return;
                }
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
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

        private void Xbutton_Click(object sender, EventArgs e)
        {
            // Press close button
            Form1_FormClosing(sender, new FormClosingEventArgs(CloseReason.UserClosing, false));
        }

        private void minButton_Click(object sender, EventArgs e)
        {
            // Press minimize button
            this.WindowState = FormWindowState.Minimized;
            Form1_Resize(sender, e);
        }
    }
}