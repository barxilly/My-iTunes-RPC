using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;

namespace iTunes_RPC
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            panel1 = new Panel();
            backButton = new Button();
            skipButton = new Button();
            pausePlayButton = new Button();
            songDurationLabel = new Label();
            songArtistLabel = new Label();
            songTitleLabel = new Label();
            toolStrip1 = new ToolStrip();
            Settings = new ToolStripButton();
            timer1 = new System.Windows.Forms.Timer(components);
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.MouseClick += notifyIcon1_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RenderMode = ToolStripRenderMode.System;
            contextMenuStrip1.Size = new Size(123, 52);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(122, 24);
            toolStripMenuItem1.Text = "Config";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(122, 24);
            toolStripMenuItem2.Text = "Exit";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(backButton);
            panel1.Controls.Add(skipButton);
            panel1.Controls.Add(pausePlayButton);
            panel1.Controls.Add(songDurationLabel);
            panel1.Controls.Add(songArtistLabel);
            panel1.Controls.Add(songTitleLabel);
            panel1.Controls.Add(toolStrip1);
            panel1.Location = new Point(0, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 450);
            panel1.TabIndex = 1;
            // 
            // backButton
            // 
            backButton.BackgroundImage = Properties.Resources.back;
            backButton.BackgroundImageLayout = ImageLayout.Stretch;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Location = new Point(84, 260);
            backButton.Name = "backButton";
            backButton.Size = new Size(60, 60);
            backButton.TabIndex = 6;
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // skipButton
            // 
            skipButton.BackgroundImage = Properties.Resources.skip;
            skipButton.BackgroundImageLayout = ImageLayout.Stretch;
            skipButton.FlatAppearance.BorderSize = 0;
            skipButton.FlatStyle = FlatStyle.Flat;
            skipButton.Location = new Point(216, 260);
            skipButton.Name = "skipButton";
            skipButton.Size = new Size(60, 60);
            skipButton.TabIndex = 5;
            skipButton.UseVisualStyleBackColor = true;
            skipButton.Click += skipButton_Click;
            // 
            // pausePlayButton
            // 
            pausePlayButton.BackgroundImage = Properties.Resources.pause;
            pausePlayButton.BackgroundImageLayout = ImageLayout.Stretch;
            pausePlayButton.FlatAppearance.BorderSize = 0;
            pausePlayButton.FlatStyle = FlatStyle.Flat;
            pausePlayButton.Location = new Point(150, 260);
            pausePlayButton.Name = "pausePlayButton";
            pausePlayButton.Size = new Size(60, 60);
            pausePlayButton.TabIndex = 4;
            pausePlayButton.UseVisualStyleBackColor = true;
            pausePlayButton.Click += pausePlayButton_Click;
            // 
            // songDurationLabel
            // 
            songDurationLabel.BackColor = SystemColors.Control;
            songDurationLabel.Font = new Font("Segoe UI Black", 10F, FontStyle.Regular, GraphicsUnit.Point);
            songDurationLabel.Location = new Point(12, 215);
            songDurationLabel.Name = "songDurationLabel";
            songDurationLabel.Size = new Size(337, 30);
            songDurationLabel.TabIndex = 3;
            songDurationLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // songArtistLabel
            // 
            songArtistLabel.BackColor = SystemColors.Control;
            songArtistLabel.Font = new Font("Segoe UI Black", 10F, FontStyle.Regular, GraphicsUnit.Point);
            songArtistLabel.Location = new Point(12, 185);
            songArtistLabel.Name = "songArtistLabel";
            songArtistLabel.Size = new Size(337, 30);
            songArtistLabel.TabIndex = 2;
            songArtistLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // songTitleLabel
            // 
            songTitleLabel.BackColor = SystemColors.Control;
            songTitleLabel.Font = new Font("Segoe UI Black", 13F, FontStyle.Regular, GraphicsUnit.Point);
            songTitleLabel.Location = new Point(12, 57);
            songTitleLabel.Name = "songTitleLabel";
            songTitleLabel.Size = new Size(337, 128);
            songTitleLabel.TabIndex = 1;
            songTitleLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { Settings });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(360, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // Settings
            // 
            Settings.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Settings.Image = Properties.Resources.Settings_L_icon;
            Settings.ImageTransparentColor = Color.Magenta;
            Settings.Name = "Settings";
            Settings.Size = new Size(29, 24);
            Settings.Text = "toolStripButton1";
            Settings.Click += Settings_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 450);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "iTunes RPC";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Resize += Form1_Resize;
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label songTitleLabel;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripButton Settings;
        private TextBox appID;
        private Button button1;
        private TextBox details;
        private System.Windows.Forms.Timer timer1;
        private Dictionary<string, int> song = new Dictionary<string, int>();
        private Label songArtistLabel;
        private Label songDurationLabel;
        private Button pausePlayButton;
        private bool isPaused = false;
        private Button skipButton;
        private Button backButton;
    }
}