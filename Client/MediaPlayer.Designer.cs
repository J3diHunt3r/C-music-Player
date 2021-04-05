namespace Client
{
    partial class MediaPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaPlayer));
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.songlistlb = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentsongtb = new System.Windows.Forms.TextBox();
            this.findsongtb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.findbtn = new System.Windows.Forms.Button();
            this.Firstbtn = new System.Windows.Forms.Button();
            this.Nextbtn = new System.Windows.Forms.Button();
            this.Previousbtn = new System.Windows.Forms.Button();
            this.Lastbtn = new System.Windows.Forms.Button();
            this.Savebtn = new System.Windows.Forms.Button();
            this.Sortbtn = new System.Windows.Forms.Button();
            this.Loadbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(12, 108);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(450, 323);
            this.axWindowsMediaPlayer.TabIndex = 0;
            // 
            // songlistlb
            // 
            this.songlistlb.FormattingEnabled = true;
            this.songlistlb.Location = new System.Drawing.Point(494, 108);
            this.songlistlb.Name = "songlistlb";
            this.songlistlb.Size = new System.Drawing.Size(259, 277);
            this.songlistlb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "All songs";
            // 
            // currentsongtb
            // 
            this.currentsongtb.Location = new System.Drawing.Point(12, 82);
            this.currentsongtb.Name = "currentsongtb";
            this.currentsongtb.Size = new System.Drawing.Size(450, 20);
            this.currentsongtb.TabIndex = 3;
            // 
            // findsongtb
            // 
            this.findsongtb.Location = new System.Drawing.Point(494, 27);
            this.findsongtb.Name = "findsongtb";
            this.findsongtb.Size = new System.Drawing.Size(259, 20);
            this.findsongtb.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Search for a song";
            // 
            // findbtn
            // 
            this.findbtn.Location = new System.Drawing.Point(494, 53);
            this.findbtn.Name = "findbtn";
            this.findbtn.Size = new System.Drawing.Size(259, 23);
            this.findbtn.TabIndex = 6;
            this.findbtn.Text = "Find";
            this.findbtn.UseVisualStyleBackColor = true;
            this.findbtn.Click += new System.EventHandler(this.findbtn_Click);
            // 
            // Firstbtn
            // 
            this.Firstbtn.Location = new System.Drawing.Point(13, 53);
            this.Firstbtn.Name = "Firstbtn";
            this.Firstbtn.Size = new System.Drawing.Size(75, 23);
            this.Firstbtn.TabIndex = 7;
            this.Firstbtn.Text = "First";
            this.Firstbtn.UseVisualStyleBackColor = true;
            this.Firstbtn.Click += new System.EventHandler(this.Firstbtn_Click);
            // 
            // Nextbtn
            // 
            this.Nextbtn.Location = new System.Drawing.Point(132, 53);
            this.Nextbtn.Name = "Nextbtn";
            this.Nextbtn.Size = new System.Drawing.Size(75, 23);
            this.Nextbtn.TabIndex = 8;
            this.Nextbtn.Text = "Next";
            this.Nextbtn.UseVisualStyleBackColor = true;
            this.Nextbtn.Click += new System.EventHandler(this.Nextbtn_Click);
            // 
            // Previousbtn
            // 
            this.Previousbtn.Location = new System.Drawing.Point(258, 53);
            this.Previousbtn.Name = "Previousbtn";
            this.Previousbtn.Size = new System.Drawing.Size(75, 23);
            this.Previousbtn.TabIndex = 9;
            this.Previousbtn.Text = "Previous";
            this.Previousbtn.UseVisualStyleBackColor = true;
            this.Previousbtn.Click += new System.EventHandler(this.Previousbtn_Click);
            // 
            // Lastbtn
            // 
            this.Lastbtn.Location = new System.Drawing.Point(387, 51);
            this.Lastbtn.Name = "Lastbtn";
            this.Lastbtn.Size = new System.Drawing.Size(75, 23);
            this.Lastbtn.TabIndex = 10;
            this.Lastbtn.Text = "Last";
            this.Lastbtn.UseVisualStyleBackColor = true;
            this.Lastbtn.Click += new System.EventHandler(this.Lastbtn_Click);
            // 
            // Savebtn
            // 
            this.Savebtn.Location = new System.Drawing.Point(494, 401);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(75, 23);
            this.Savebtn.TabIndex = 11;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // Sortbtn
            // 
            this.Sortbtn.Location = new System.Drawing.Point(585, 401);
            this.Sortbtn.Name = "Sortbtn";
            this.Sortbtn.Size = new System.Drawing.Size(75, 23);
            this.Sortbtn.TabIndex = 12;
            this.Sortbtn.Text = "Sort";
            this.Sortbtn.UseVisualStyleBackColor = true;
            this.Sortbtn.Click += new System.EventHandler(this.Sortbtn_Click);
            // 
            // Loadbtn
            // 
            this.Loadbtn.Location = new System.Drawing.Point(678, 401);
            this.Loadbtn.Name = "Loadbtn";
            this.Loadbtn.Size = new System.Drawing.Size(75, 23);
            this.Loadbtn.TabIndex = 13;
            this.Loadbtn.Text = "Load";
            this.Loadbtn.UseVisualStyleBackColor = true;
            this.Loadbtn.Click += new System.EventHandler(this.Loadbtn_Click);
            // 
            // MediaPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 449);
            this.Controls.Add(this.Loadbtn);
            this.Controls.Add(this.Sortbtn);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.Lastbtn);
            this.Controls.Add(this.Previousbtn);
            this.Controls.Add(this.Nextbtn);
            this.Controls.Add(this.Firstbtn);
            this.Controls.Add(this.findbtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.findsongtb);
            this.Controls.Add(this.currentsongtb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.songlistlb);
            this.Controls.Add(this.axWindowsMediaPlayer);
            this.Name = "MediaPlayer";
            this.Text = "7";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private System.Windows.Forms.ListBox songlistlb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentsongtb;
        private System.Windows.Forms.TextBox findsongtb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button findbtn;
        private System.Windows.Forms.Button Firstbtn;
        private System.Windows.Forms.Button Nextbtn;
        private System.Windows.Forms.Button Previousbtn;
        private System.Windows.Forms.Button Lastbtn;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.Button Sortbtn;
        private System.Windows.Forms.Button Loadbtn;
    }
}