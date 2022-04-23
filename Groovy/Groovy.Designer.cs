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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Groovy));
            this.playlists_list = new System.Windows.Forms.ListBox();
            this.playlists_sidebar = new System.Windows.Forms.Panel();
            this.icon_and_name_display = new System.Windows.Forms.PictureBox();
            this.search_magnifying_glass_icon = new System.Windows.Forms.PictureBox();
            this.playlist_searchbox = new System.Windows.Forms.TextBox();
            this.songs_list = new System.Windows.Forms.ListBox();
            this.replaySong_button = new System.Windows.Forms.Button();
            this.current_playlist_display = new System.Windows.Forms.Label();
            this.filter_music_textbox = new System.Windows.Forms.TextBox();
            this.filter_music_search_picturebox = new System.Windows.Forms.PictureBox();
            this.playNextSongButton = new System.Windows.Forms.Button();
            this.togglePlaybackButton = new System.Windows.Forms.Button();
            this.playLastSongButton = new System.Windows.Forms.Button();
            this.scrub15forwardButton = new System.Windows.Forms.Button();
            this.scrub15backwardButton = new System.Windows.Forms.Button();
            this.playlists_sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_and_name_display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_magnifying_glass_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filter_music_search_picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // playlists_list
            // 
            this.playlists_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.playlists_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playlists_list.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.search_magnifying_glass_icon.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.playlist_searchbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.playlist_searchbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(50)))));
            this.playlist_searchbox.Location = new System.Drawing.Point(44, 77);
            this.playlist_searchbox.Name = "playlist_searchbox";
            this.playlist_searchbox.PlaceholderText = "Find New Music";
            this.playlist_searchbox.Size = new System.Drawing.Size(213, 23);
            this.playlist_searchbox.TabIndex = 4;
            this.playlist_searchbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.playlist_searchbox_KeyPress);
            // 
            // songs_list
            // 
            this.songs_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.songs_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.songs_list.Cursor = System.Windows.Forms.Cursors.Hand;
            this.songs_list.Font = new System.Drawing.Font("Calibri", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.songs_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(50)))));
            this.songs_list.FormattingEnabled = true;
            this.songs_list.ItemHeight = 28;
            this.songs_list.Items.AddRange(new object[] {
            "list of songs in a selected playlist"});
            this.songs_list.Location = new System.Drawing.Point(334, 70);
            this.songs_list.MaximumSize = new System.Drawing.Size(200000, 200000);
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
            this.replaySong_button.Cursor = System.Windows.Forms.Cursors.Hand;
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
            // filter_music_textbox
            // 
            this.filter_music_textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.filter_music_textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.filter_music_textbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(50)))));
            this.filter_music_textbox.Location = new System.Drawing.Point(1554, 77);
            this.filter_music_textbox.Name = "filter_music_textbox";
            this.filter_music_textbox.PlaceholderText = "Filter Music";
            this.filter_music_textbox.Size = new System.Drawing.Size(203, 23);
            this.filter_music_textbox.TabIndex = 7;
            this.filter_music_textbox.TextChanged += new System.EventHandler(this.filter_songs_textbox_TextChanged);
            // 
            // filter_music_search_picturebox
            // 
            this.filter_music_search_picturebox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filter_music_search_picturebox.Image = global::Groovy.Properties.Resources.searchMagnifyingGlassLighterBackground;
            this.filter_music_search_picturebox.Location = new System.Drawing.Point(1525, 77);
            this.filter_music_search_picturebox.Name = "filter_music_search_picturebox";
            this.filter_music_search_picturebox.Size = new System.Drawing.Size(23, 23);
            this.filter_music_search_picturebox.TabIndex = 7;
            this.filter_music_search_picturebox.TabStop = false;
            // 
            // playNextSongButton
            // 
            this.playNextSongButton.BackColor = System.Drawing.Color.Red;
            this.playNextSongButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.playNextSongButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playNextSongButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.playNextSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playNextSongButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.playNextSongButton.Location = new System.Drawing.Point(276, 150);
            this.playNextSongButton.Name = "playNextSongButton";
            this.playNextSongButton.Size = new System.Drawing.Size(40, 34);
            this.playNextSongButton.TabIndex = 9;
            this.playNextSongButton.UseVisualStyleBackColor = false;
            this.playNextSongButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // togglePlaybackButton
            // 
            this.togglePlaybackButton.BackColor = System.Drawing.Color.Lime;
            this.togglePlaybackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.togglePlaybackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.togglePlaybackButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.togglePlaybackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.togglePlaybackButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.togglePlaybackButton.Location = new System.Drawing.Point(276, 110);
            this.togglePlaybackButton.Name = "togglePlaybackButton";
            this.togglePlaybackButton.Size = new System.Drawing.Size(40, 34);
            this.togglePlaybackButton.TabIndex = 10;
            this.togglePlaybackButton.UseVisualStyleBackColor = false;
            this.togglePlaybackButton.Click += new System.EventHandler(this.togglePlaybackButton_Click);
            // 
            // playLastSongButton
            // 
            this.playLastSongButton.BackColor = System.Drawing.Color.Orange;
            this.playLastSongButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.playLastSongButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playLastSongButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.playLastSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playLastSongButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.playLastSongButton.Location = new System.Drawing.Point(276, 190);
            this.playLastSongButton.Name = "playLastSongButton";
            this.playLastSongButton.Size = new System.Drawing.Size(40, 34);
            this.playLastSongButton.TabIndex = 11;
            this.playLastSongButton.UseVisualStyleBackColor = false;
            this.playLastSongButton.Click += new System.EventHandler(this.playLastSongButton_Click);
            // 
            // scrub15forwardButton
            // 
            this.scrub15forwardButton.BackColor = System.Drawing.Color.Pink;
            this.scrub15forwardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.scrub15forwardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scrub15forwardButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.scrub15forwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scrub15forwardButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.scrub15forwardButton.Location = new System.Drawing.Point(276, 363);
            this.scrub15forwardButton.Name = "scrub15forwardButton";
            this.scrub15forwardButton.Size = new System.Drawing.Size(40, 34);
            this.scrub15forwardButton.TabIndex = 12;
            this.scrub15forwardButton.UseVisualStyleBackColor = false;
            // 
            // scrub15backwardButton
            // 
            this.scrub15backwardButton.BackColor = System.Drawing.Color.Blue;
            this.scrub15backwardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.scrub15backwardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scrub15backwardButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.scrub15backwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scrub15backwardButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.scrub15backwardButton.Location = new System.Drawing.Point(276, 403);
            this.scrub15backwardButton.Name = "scrub15backwardButton";
            this.scrub15backwardButton.Size = new System.Drawing.Size(40, 34);
            this.scrub15backwardButton.TabIndex = 13;
            this.scrub15backwardButton.UseVisualStyleBackColor = false;
            // 
            // Groovy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.scrub15backwardButton);
            this.Controls.Add(this.scrub15forwardButton);
            this.Controls.Add(this.playLastSongButton);
            this.Controls.Add(this.togglePlaybackButton);
            this.Controls.Add(this.playNextSongButton);
            this.Controls.Add(this.filter_music_search_picturebox);
            this.Controls.Add(this.filter_music_textbox);
            this.Controls.Add(this.current_playlist_display);
            this.Controls.Add(this.replaySong_button);
            this.Controls.Add(this.songs_list);
            this.Controls.Add(this.playlists_sidebar);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Groovy";
            this.Text = "Groovy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.playlists_sidebar.ResumeLayout(false);
            this.playlists_sidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_and_name_display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_magnifying_glass_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filter_music_search_picturebox)).EndInit();
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
        private TextBox filter_music_textbox;
        private PictureBox filter_music_search_picturebox;
        private Button togglePlaybackButton;
        private Button playLastSongButton;
        private Button scrub15forwardButton;
        private Button playNextSongButton;
        private Button scrub15backwardButton;
    }
}