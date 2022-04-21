namespace Groovy
{
    partial class Groovy
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
            this.playlists_list = new System.Windows.Forms.ListBox();
            this.playlists_sidebar = new System.Windows.Forms.Panel();
            this.icon_and_name_display = new System.Windows.Forms.PictureBox();
            this.search_magnifying_glass_icon = new System.Windows.Forms.PictureBox();
            this.playlist_searchbox = new System.Windows.Forms.TextBox();
            this.songs_list = new System.Windows.Forms.ListBox();
            this.replaySong_button = new System.Windows.Forms.Button();
            this.current_playlist_display = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.playlists_sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_and_name_display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_magnifying_glass_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // playlists_list
            // 
            this.playlists_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.playlists_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playlists_list.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playlists_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(50)))));
            this.playlists_list.FormattingEnabled = true;
            this.playlists_list.ItemHeight = 23;
            this.playlists_list.Items.AddRange(new object[] {
            "list of playlists in C:\\groovy"});
            this.playlists_list.Location = new System.Drawing.Point(12, 125);
            this.playlists_list.Name = "playlists_list";
            this.playlists_list.Size = new System.Drawing.Size(245, 897);
            this.playlists_list.TabIndex = 1;
            this.playlists_list.SelectedIndexChanged += new System.EventHandler(this.playlists_list_SelectedIndexChanged);
            // 
            // playlists_sidebar
            // 
            this.playlists_sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.playlists_sidebar.Controls.Add(this.icon_and_name_display);
            this.playlists_sidebar.Controls.Add(this.search_magnifying_glass_icon);
            this.playlists_sidebar.Controls.Add(this.playlist_searchbox);
            this.playlists_sidebar.Controls.Add(this.playlists_list);
            this.playlists_sidebar.Location = new System.Drawing.Point(0, 0);
            this.playlists_sidebar.Name = "playlists_sidebar";
            this.playlists_sidebar.Size = new System.Drawing.Size(270, 1041);
            this.playlists_sidebar.TabIndex = 3;
            // 
            // icon_and_name_display
            // 
            this.icon_and_name_display.Location = new System.Drawing.Point(12, 10);
            this.icon_and_name_display.Name = "icon_and_name_display";
            this.icon_and_name_display.Size = new System.Drawing.Size(245, 28);
            this.icon_and_name_display.TabIndex = 6;
            this.icon_and_name_display.TabStop = false;
            // 
            // search_magnifying_glass_icon
            // 
            this.search_magnifying_glass_icon.Image = global::Groovy.Properties.Resources.searchMagnifyingGlass;
            this.search_magnifying_glass_icon.Location = new System.Drawing.Point(12, 77);
            this.search_magnifying_glass_icon.Name = "search_magnifying_glass_icon";
            this.search_magnifying_glass_icon.Size = new System.Drawing.Size(23, 23);
            this.search_magnifying_glass_icon.TabIndex = 5;
            this.search_magnifying_glass_icon.TabStop = false;
            this.search_magnifying_glass_icon.Click += new System.EventHandler(this.search_magnifying_glass_icon_Click);
            // 
            // playlist_searchbox
            // 
            this.playlist_searchbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.playlist_searchbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(50)))));
            this.playlist_searchbox.Location = new System.Drawing.Point(44, 77);
            this.playlist_searchbox.Name = "playlist_searchbox";
            this.playlist_searchbox.PlaceholderText = "Search";
            this.playlist_searchbox.Size = new System.Drawing.Size(213, 23);
            this.playlist_searchbox.TabIndex = 4;
            this.playlist_searchbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.playlist_searchbox_KeyPress);
            // 
            // songs_list
            // 
            this.songs_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.songs_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.songs_list.Font = new System.Drawing.Font("Calibri", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.songs_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(50)))));
            this.songs_list.FormattingEnabled = true;
            this.songs_list.ItemHeight = 28;
            this.songs_list.Items.AddRange(new object[] {
            "list of songs in a selected playlist"});
            this.songs_list.Location = new System.Drawing.Point(334, 70);
            this.songs_list.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.songs_list.Name = "songs_list";
            this.songs_list.Size = new System.Drawing.Size(1452, 926);
            this.songs_list.Sorted = true;
            this.songs_list.TabIndex = 4;
            this.songs_list.SelectedIndexChanged += new System.EventHandler(this.songs_list_SelectedIndexChanged);
            // 
            // replaySong_button
            // 
            this.replaySong_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.replaySong_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.replaySong_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.replaySong_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replaySong_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.replaySong_button.Image = global::Groovy.Properties.Resources.replay;
            this.replaySong_button.Location = new System.Drawing.Point(276, 70);
            this.replaySong_button.Name = "replaySong_button";
            this.replaySong_button.Size = new System.Drawing.Size(40, 34);
            this.replaySong_button.TabIndex = 5;
            this.replaySong_button.UseVisualStyleBackColor = false;
            this.replaySong_button.Click += new System.EventHandler(this.replaySong_button_Click);
            // 
            // current_playlist_display
            // 
            this.current_playlist_display.AutoSize = true;
            this.current_playlist_display.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.current_playlist_display.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(50)))));
            this.current_playlist_display.Location = new System.Drawing.Point(877, 16);
            this.current_playlist_display.Name = "current_playlist_display";
            this.current_playlist_display.Size = new System.Drawing.Size(290, 37);
            this.current_playlist_display.TabIndex = 6;
            this.current_playlist_display.Text = "current_playlist_display";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(50)))));
            this.textBox1.Location = new System.Drawing.Point(1554, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Filter Songs";
            this.textBox1.Size = new System.Drawing.Size(203, 23);
            this.textBox1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Groovy.Properties.Resources.searchMagnifyingGlassLighterBackground;
            this.pictureBox1.Location = new System.Drawing.Point(1525, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Groovy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.current_playlist_display);
            this.Controls.Add(this.replaySong_button);
            this.Controls.Add(this.songs_list);
            this.Controls.Add(this.playlists_sidebar);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Groovy";
            this.Text = "Groovy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.playlists_sidebar.ResumeLayout(false);
            this.playlists_sidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_and_name_display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_magnifying_glass_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox playlists_list;
        private Panel playlists_sidebar;
        private PictureBox icon_and_name_display;
        private PictureBox search_magnifying_glass_icon;
        private TextBox playlist_searchbox;
        private ListBox songs_list;
        private Button replaySong_button;
        private Label current_playlist_display;
        private TextBox textBox1;
        private PictureBox pictureBox1;
    }
}