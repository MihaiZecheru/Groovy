using ChrisTools;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Groovy
{
    public partial class Groovy : Form
    {
        /// <summary>
        /// Executes: Messagebox.Show(x); where x is any type
        /// </summary>
        /// <param name="x">The thing you want to be displayed on the screen; can be of any type</param>
        public static void display(object x, object y = null, object z = null, object a = null, object b = null)
        {
            string[] args = { x != null ? x.ToString(): null, y != null ? y.ToString() : null, z != null ? z.ToString() : null, a != null ? a.ToString() : null, b != null ? b.ToString() : null };
            string toShow = "";
            foreach (string arg in args)
            {
                if (arg != null)
                {
                    if (arg.GetType().IsArray)
                    {
                        foreach (object ele in arg)
                            toShow += (toShow != "") ? ", " + ele : ele;
                    }
                    toShow += (toShow != "") ? ", " + arg : arg;
                }
            }
            MessageBox.Show(toShow);
        }

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private List<string> MusicQueue = new List<string>();

        public Groovy()
        {
            InitializeComponent();
            this.ActiveControl = this.icon_and_name_display;
            this.playlists_list.Items.Clear();
            this.songs_list.Items.Clear();
            PopulatePlaylistsListbox();
            DisplayFirstPlaylist();
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

            /* add queue, this is not a playlist */

            this.playlists_list.Items.Add("queue");

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

        private int previouslySelectedPlaylistIndex = 0; // default playlist is always the first in the users line
        private void playlists_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int currentlySelectedIndex = this.playlists_list.SelectedIndex;
                if (previouslySelectedPlaylistIndex == currentlySelectedIndex)
                    return; // only activate this function when a new playlist is clicked

                string playlist = (string)this.playlists_list.SelectedItems[0];
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
            playlist = playlist.Contains(":\\") ? musicfilePath : (playlist == "all" || playlist == "queue") ? playlist : @$"C:\groovy\{playlist}";
            List<string> songs = new List<string>();
            if (playlist != "all" && playlist != "queue")
            {
                this.songs_list.Sorted = true;
                foreach (string s in Directory.GetFiles(playlist, "*.mp3"))
                {
                    string so = s.Substring(s.LastIndexOf('\\') + 1, s.Substring(s.LastIndexOf('\\') + 1).Length - 4);
                    if (!songs.Contains(so))
                        songs.Add(so);
                }
            }
            else if (playlist == "all")
            {
                this.songs_list.Sorted = true;
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
            else if (playlist == "queue")
            {
                this.songs_list.Sorted = false;
                foreach (string song in MusicQueue)
                {
                    songs.Add(song.Substring(song.LastIndexOf('\\') + 1, song.Substring(song.LastIndexOf('\\') + 1).Length - 4));
                }
            }

            this.songs_list.Items.Clear();
            foreach (string s in songs)
            {
                // append each song, removing the leading parent dirs and .mp3 trail
                this.songs_list.Items.Add(s);
            }

            if (playlist != "queue")
                filter_songs_textbox_TextChanged(null, null);
        }

        private void songs_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (current_playlist_display.Text == "queue")
            {
                this.songs_list.ClearSelected();
                this.ActiveControl = this.icon_and_name_display;
                return;
            }
            //if (previouslySelectedPlaylistIndex == -2)
            //    return; // no playlist has been selected, therefore no songs could have been chosen

            int currentlySelectedSongIndex = this.songs_list.SelectedIndex;

            //if (currentlySelectedSongIndex == previouslySelectedSongIndex && indexOfPlaylistWhenLastSongWasPlayed == previouslySelectedPlaylistIndex)
            //    return; // the song should only play if the index is the same and the playlists are different

            try
            {
                string song = (string)this.songs_list.SelectedItems[0];
                string playlist = (string)this.playlists_list.Items[previouslySelectedPlaylistIndex];
                playlist = (playlist == "all") ? findPlaylist(song) : playlist;
                string playSongCommand = playlist.Contains(":\\") ? $"{musicfilePath}\\{song}.mp3" : $@"C:\groovy\{playlist}\{song}.mp3";
                previouslyPlayedSongFilepath = playSongCommand;
                //previouslySelectedSongIndex = currentlySelectedSongIndex;
                this.songs_list.ClearSelected();
                this.ActiveControl = this.icon_and_name_display;
                addSongToQueue(playSongCommand);
                playSong();
            } catch (IndexOutOfRangeException) { };
        }

        private string previouslyPlayedSongFilepath = "{empty}";
        private void playSong()
        {
            if (outputDevice?.PlaybackState == PlaybackState.Playing || outputDevice?.PlaybackState == PlaybackState.Paused)
                return;

            // play music
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += this.OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                if (MusicQueue.Count > 0)
                {
                    audioFile = new AudioFileReader(MusicQueue[0]);
                    outputDevice.Init(audioFile);
                }
                else
                    return; // no music is left in the queue
            }
            // remove song from queue
            MusicQueue.RemoveAt(0);
            outputDevice.Play();
        }

        private void replaySong_button_Click(object sender, EventArgs e)
        {
            if (previouslyPlayedSongFilepath == "{empty}")
                return;

            // add to beginning of queue
            MusicQueue.Insert(0, previouslyPlayedSongFilepath);
            playSong();
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
            return null; // prevent none-returned exception (CS0161)
        }

        private List<string> temporarilyRemovedSongs = new List<string>();
        private int previousTextLength = 0;
        private void filter_songs_textbox_TextChanged(object sender, EventArgs e)
        {
            List<string> toRemove = new List<string>();
            string text = Tools.Strip(this.filter_music_textbox.Text.ToLower());

            if (text.Length >= this.previousTextLength)
            {
                // a char was added, remove songs that do not start with the search-phrase
                foreach (string song in this.songs_list.Items)
                {
                    if (!song.ToLower().Contains(text))
                    {
                        this.temporarilyRemovedSongs.Add(song);
                        toRemove.Add(song);
                    }
                }

                foreach (string song in toRemove)
                {
                    this.songs_list.Items.Remove(song);
                }
            }
            else
            {
                // a char was removed; look through removed songs to add back
                foreach (string song in this.temporarilyRemovedSongs)
                {
                    if (song.Contains(text) && !this.songs_list.Items.Contains(song))
                        this.songs_list.Items.Add(song);
                }
            }
            previousTextLength = text.Length;
        }

        private void DisplayFirstPlaylist()
        {
            string playlist = (string)this.playlists_list.Items[0];
            this.playlists_list.ClearSelected();
            this.ActiveControl = this.icon_and_name_display;
            this.current_playlist_display.Text = playlist;
            this.current_playlist_display.Location = new Point((this.songs_list.Width - this.current_playlist_display.Width) / 2 + this.songs_list.Location.X, this.current_playlist_display.Location.Y);
            ShowPlaylistSongs(playlist);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            // stop playlist music
            outputDevice?.Stop();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            try
            {
                outputDevice.Dispose();
                outputDevice = null;
                audioFile.Dispose();
                audioFile = null;
            }
            catch (NullReferenceException) { };
            playSong();
        }

        private void addSongToQueue(string path)
        {
            MusicQueue.Add(path);
        }
    }
}