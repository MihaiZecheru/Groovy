using ChrisTools;

namespace Groovy
{
    public partial class Groovy : Form
    {
        /// <summary>
        /// Executes: Messagebox.Show(x); where x is any type
        /// </summary>
        /// <param name="x">The thing you want to be displayed on the screen; can be of any type</param>
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        public static void display(object x, object y = null, object z = null, object a = null, object b = null)
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            string[] args = { x != null ? x.ToString(): null, y != null? y.ToString() : null, z != null ? z.ToString() : null, a != null ? a.ToString() : null, b != null ? b.ToString() : null };
#pragma warning restore CS8601 // Possible null reference assignment.
            string toShow = "";
            foreach (string arg in args)
            {
                if (arg != null)
                    toShow += (toShow != "") ? ", " + arg : arg;
            }
            MessageBox.Show(toShow);
        }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.


        public Groovy()
        {
            InitializeComponent();
            this.ActiveControl = this.icon_and_name_display;
            this.playlists_list.Items.Clear();
            this.songs_list.Items.Clear();
            PopulatePlaylistsListbox();
        }

        private List<string> all_playlists = new List<string>();
        private string musicfilePath { get; set; }
        /// <summary>
        /// Adds all playlists to the playlist_list sidebar element
        /// </summary>
        private void PopulatePlaylistsListbox()
        {
            /* add "all" playlist, which contains every song from all playlists */

            this.playlists_list.Items.Add("all");
            this.all_playlists.Add("all");

            /* find and add <char>:\Music (C:\Music, D:\Music, etc)*/

            string musicDir = "";
            foreach (var d in DriveInfo.GetDrives())
            {
                if (Directory.Exists($"{d}Music"))
                    musicDir = $"{d}Music";
            }

            if (musicDir != "")
            {
                this.playlists_list.Items.Add(musicDir);
                this.all_playlists.Add(musicDir);
                musicfilePath = musicDir;
            }

            /* add every playlist in C:\groovy */

            var directories = Directory.GetDirectories(@"C:\groovy");
            foreach (var d in directories)
            {
                // append to listbox
                this.playlists_list.Items.Add(d.Substring(10));
                // add to all playlists collection
                this.all_playlists.Add(d);
            }
        }

        private void search(string query)
        {
            // TODO: make a class called Search with different methods like "get" and such, for interacting with spotify api and retrieving the data
        }

        private void search_magnifying_glass_icon_Click(object sender, EventArgs e)
        {
            string text = Tools.Strip(this.playlist_searchbox.Text, true);
            if (text != "")
                search(text);
        }

        private void playlist_searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                string text = Tools.Strip(this.playlist_searchbox.Text, true);
                search(text);
            }
        }

        private int previouslySelectedPlaylistIndex = -2; // default number that will not be an index in the listbox
        private void playlists_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int currentlySelectedIndex = this.playlists_list.SelectedIndex;
                if (previouslySelectedPlaylistIndex == currentlySelectedIndex)
                    return; // only activate this function when a new playlist is clicked

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string playlist = this.playlists_list.SelectedItems[0].ToString();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                previouslySelectedPlaylistIndex = currentlySelectedIndex;
                this.playlists_list.ClearSelected();
                this.ActiveControl = this.icon_and_name_display;
                this.current_playlist_display.Text = playlist;
                this.current_playlist_display.Location = new Point((this.songs_list.Width - this.current_playlist_display.Width) / 2 + this.songs_list.Location.X, this.current_playlist_display.Location.Y);
                ShowPlaylistSongs(playlist);
            }
            catch (IndexOutOfRangeException) { };
        }

        private void ShowPlaylistSongs(string playlist)
        {
            playlist = playlist.Contains(":\\") ? musicfilePath : (playlist == "all") ? playlist : @$"C:\groovy\{playlist}";
            List<string> songs = new List<string>();
            if (playlist != "all")
            {
                foreach (string s in Directory.GetFiles(playlist, "*.mp3"))
                {
                    string so = s.Substring(s.LastIndexOf('\\') + 1, s.Substring(s.LastIndexOf('\\') + 1).Length - 4);
                    if (!songs.Contains(so))
                        songs.Add(so);
                }
            }
            else
            {
                for (int i = 0; i < this.all_playlists.Count; i++)
                {
                    string pl = this.all_playlists[i];
                    if (pl == "all") continue;
                    playlist = pl.Contains(":\\") ? pl : $@"C:\groovy\{pl}";
                    foreach (string s in Directory.GetFiles(playlist, "*.mp3"))
                    {
                        string so = s.Substring(s.LastIndexOf('\\') + 1, s.Substring(s.LastIndexOf('\\') + 1).Length - 4);
                        if (!songs.Contains(so))
                            songs.Add(so);
                    }
                }
            }

            this.songs_list.Items.Clear();
            foreach (string s in songs)
            {
                // append each song, removing the leading parent dirs and .mp3 trail
                this.songs_list.Items.Add(s);
            }
        }

        private int previouslySelectedSongIndex = -2;
        private int indexOfPlaylistWhenLastSongWasPlayed = -2;
        private void songs_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (previouslySelectedPlaylistIndex == -2)
                return; // no playlist has been selected, therefore no songs could have been chosen

            int currentlySelectedSongIndex = this.songs_list.SelectedIndex;

            if (currentlySelectedSongIndex == previouslySelectedSongIndex && indexOfPlaylistWhenLastSongWasPlayed == previouslySelectedPlaylistIndex)
                return; // the song should only play if the index is the same and the playlists are different

            try
            {
                string song = this.songs_list.SelectedItems[0].ToString();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string playlist = this.playlists_list.Items[previouslySelectedPlaylistIndex].ToString();
                playlist = (playlist == "all") ? findPlaylist(song) : playlist;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.                  start "" "C:\file\path\of\song.mp3"
                string playSongCommand = playlist.Contains(":\\") ? $"start \"\" \"{musicfilePath}\\{song}.mp3\"" : $"start \"\" \"C:\\groovy\\{playlist}\\{song}.mp3\"";
                previouslyPlayedSongCommand = playSongCommand;
                previouslySelectedSongIndex = currentlySelectedSongIndex;
                indexOfPlaylistWhenLastSongWasPlayed = previouslySelectedPlaylistIndex;
                this.songs_list.ClearSelected();
                this.ActiveControl = this.icon_and_name_display;
                playSong(playSongCommand);
            } catch (IndexOutOfRangeException) { };
        }

        private string previouslyPlayedSongCommand = "{empty}";
        private void playSong(string command)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;
            process.Start();
        }


        private void replaySong_button_Click(object sender, EventArgs e)
        {
            if (previouslyPlayedSongCommand == "{empty}")
                return;

            playSong(previouslyPlayedSongCommand);
        }

        private string findPlaylist(string song)
        {
            for (int i = 0; i < this.all_playlists.Count; i++)
            {
                string pl = this.all_playlists[i];
                if (pl == "all") continue;
                pl = pl.Contains(":\\") ? pl : $@"C:\groovy\{pl}";
                foreach (string s in Directory.GetFiles(pl, "*.mp3"))
                {
                    if (s.Substring(s.LastIndexOf('\\') + 1, s.Substring(s.LastIndexOf('\\') + 1).Length - 4) == song)
                    {
                        return pl;
                    }
                }
            }
            return null; // this will never be reached
        }
    }
}