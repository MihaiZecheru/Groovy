using ChrisTools;
using NAudio.Wave;

namespace Groovy
{
    public partial class Groovy : Form
    {
        /// <summary>Executes: Messagebox.Show(x); where all arguments are of any type</summary>
        /// <param name="args">The values you want to be displayed in the messagebox; can be of any type</param>
        public static void Display(params object[] args)
        {
            string toShow = "";
            foreach (object arg in args)
            {
                if (arg != null)
                {
                    if (arg.GetType().IsArray)
                    {
                        toShow += '\n';
                        foreach (object ele in (object[])arg)
                            toShow += (toShow != "") ? ", " + ele.ToString() : ele.ToString();
                    }
                    toShow += (toShow != "") ? ", " + arg : arg;
                }
            }
            MessageBox.Show(toShow);
        }

        private WaveOutEvent OutputDevice { get; set; }
        private AudioFileReader AudioFile { get; set; }
        private List<Song> MusicQueue { get; set; } = new List<Song>();
        private Song CurrentlyPlayingSong { get; set; }
        private List<Song> PreviouslyPlayedSongs { get; set; } = new List<Song>();
        private float CurrentPlayerVolume { get; set; } = 1f;
        private Playlist PlaylistAll { get; set; }
        private SelectedPlaylistItem SelectedPlaylist { get; set; }
        private List<Song> DisplayedSongs { get; set; } = new List<Song>();

        public Groovy()
        {
            InitializeComponent();
            this.modal.Text = "";
            this.ActiveControl = this.icon_and_name_display;
            this.playlists_list.Items.Clear();
            this.songs_list.Items.Clear();
            this.currently_playing_song_display.Text = "";
            StartPlaybackButtonThread();
            songRemovedFromMusicQueueEventListener();
            SetVolumeFromFile();
            PopulatePlaylistsListbox();
            DisplayFirstPlaylist();
        }

        /// <summary>
        /// Set the volume of the musicplayer to that of last.vol's contents
        /// </summary>
        private void SetVolumeFromFile()
        {
            // volume will be between 0 and 1, with the default volume being 1

            if (!File.Exists("last.vol"))
            {
                File.WriteAllText("last.vol", "1");
            }

            float volume = float.Parse(File.ReadAllText("last.vol"));
            CurrentPlayerVolume = volume;
            this.volume_control_bar.Value = (int)(CurrentPlayerVolume * 100f);
        }

        private List<Playlist> Playlists = new List<Playlist>();

        /// <summary>
        /// Adds all playlists to the playlist_list sidebar element including "All Music", "queue", and ?:\Music
        /// </summary>
        private void PopulatePlaylistsListbox()
        {
            /* add queue, this is not a playlist, it's a collection of the upcoming songs */

            this.playlists_list.Items.Add("Queue");
            this.Playlists.Add(new Playlist(name: "Queue", songlist: MusicQueue));

            /* find and add <char>:\Music (C:\Music, D:\Music, etc) */

            foreach (var d in DriveInfo.GetDrives())
            {
                if (Directory.Exists($"{d}Music"))
                {
                    List<Song> songs = new List<Song>();
                    foreach (string s in Directory.GetFiles($"{d}Music", "*.mp3"))
                    {
                        string name = s.Substring(s.LastIndexOf('\\') + 1, s.Substring(s.LastIndexOf('\\') + 1).Length - 4);
                        Song song = new Song(name: name, path: @$"{d}Music\{name}.mp3");
                        if (!songs.Contains(song)) songs.Add(song);
                    }

                    Playlist playlist = new Playlist(name: $"{d}Music", songlist: songs);
                    this.Playlists.Add(playlist);
                    this.playlists_list.Items.Add(playlist.Name);
                }
            }

            /* add every playlist in C:\groovy */

            foreach (var d in Directory.GetDirectories(@"C:\groovy"))
            {
                List<Song> songs = new List<Song>();
                foreach (string s in Directory.GetFiles(d, "*.mp3"))
                {
                    string name = s.Substring(s.LastIndexOf('\\') + 1, s.Substring(s.LastIndexOf('\\') + 1).Length - 4);
                    Song song = new Song(name: name, path: @$"{d}\{name}.mp3");
                    if (!songs.Contains(song)) songs.Add(song);
                }

                Playlist playlist = new Playlist(name: d.Substring(10), songlist: songs);
                this.playlists_list.Items.Add(playlist.Name);
                this.Playlists.Add(playlist);
            }

            /* add "All Music" playlist, which contains every song from all playlists */

            int length = 0;
            for (int i = 0; i < this.Playlists.Count; i++) length += this.Playlists[i].Count();

            List<Song> _songs = new List<Song>();
            List<string> added_names = new List<string>();
            foreach (Playlist p in this.Playlists)
            {
                foreach (Song s in p)
                {
                    if (!added_names.Contains(s.Name))
                    {
                        added_names.Add(s.Name);
                        _songs.Add(s);
                    }
                }
            }

            PlaylistAll = new Playlist(name: "All Music", songlist: _songs);
            this.Playlists.Insert(0, PlaylistAll);
            this.playlists_list.Items.Insert(0, PlaylistAll.Name);
        }

        private void search(string query)
        {
            // TODO: make a class called Search with different methods like "get" and such, for interacting with spotify api and retrieving the data
        }

        /// <summary>
        /// Calls the <see cref="search(string)"/> function when the <see cref="search_magnifying_glass_icon"/> is clicked
        /// </summary>
        private void search_magnifying_glass_icon_Click(object sender, EventArgs e)
        {
            string text = Tools.Strip(this.find_new_music_searchbox.Text, true);
            if (text != "")
                search(text);
        }

        /// <summary>
        /// Listen for the enter keypress event on the <see cref="find_new_music_searchbox"/>
        /// </summary>
        private void find_new_music_searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                string text = Tools.Strip(this.find_new_music_searchbox.Text, true);
                search(text);
            }
        }

        /// <summary>
        /// Called when the user selects a new playlist from the <see cref="playlists_list"/>
        /// </summary>
        private void playlists_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = this.playlists_list.SelectedIndex;

                // only activate this function when a new playlist is clicked
                if (SelectedPlaylist.Index == selectedIndex) return;

                this.filter_music_textbox.Text = "";
                this.ActiveControl = this.filter_music_textbox;

                Playlist playlist = GetPlaylistByName((string)this.playlists_list.Items[selectedIndex]);
                SelectedPlaylist = new SelectedPlaylistItem(playlist, selectedIndex);

                this.playlists_list.ClearSelected();
                ShowPlaylistSongs(playlist);
            }
            catch (IndexOutOfRangeException) { }
            catch (ArgumentOutOfRangeException) { };
        }

        /// <summary>
        /// Searches through <see cref="Playlists"/> and returns the one with the matching <paramref name="name"/>
        /// </summary>
        /// <param name="name">The <see cref="Playlist"/> if found; otherwise <c>null</c></param>
        /// <returns>The <see cref="Playlist"/> if found; otherwise <c>null</c></returns>
        private Playlist GetPlaylistByName(string name)
        {
            for (int i = 0; i < this.Playlists.Count(); i++)
            {
                if (name == this.Playlists[i].Name) return this.Playlists[i];
            }

            return null;
        }

        /// <summary>
        /// Display the given <paramref name="playlist"/>'s songs to <see cref="songs_list"/>
        /// </summary>
        /// <param name="playlist">The <see cref="Playlist"/> to display songs from</param>
        private void ShowPlaylistSongs(Playlist playlist)
        {
            temporarilyRemovedSongs.Clear();
            this.songs_list.Sorted = (playlist.Name != "Queue");

            // Checks if an Invoke is required, preventing the cross-thread error
            if (this.songs_list.InvokeRequired)
            {
                // An invoke is a method that calls the given Delegate/Action in the same thread as the one the Control this.songs_list was made on
                this.songs_list.Invoke(new MethodInvoker(delegate { ShowPlaylistSongs(playlist); }));
                return;
            }
            
            this.songs_list.Items.Clear();

            DisplayedSongs.Clear();
            foreach (Song song in playlist.Songs)
            {
                this.songs_list.Items.Add(song.Name);
                DisplayedSongs.Add(song);
            }

            if (playlist.Name != "Queue")
                filter_songs_textbox_TextChanged(null, null);
        }

        /// <summary>
        /// Searches through all songs in the <see cref="SelectedPlaylist"/> and returns the one that matches with the given <paramref name="name"/>
        /// </summary>
        /// <param name="name">The <paramref name="name"/> to search for</param>
        /// <returns>The <see cref="Song"/> if found; otherwise <c>null</c></returns>
        private Song GetSongByName(string name)
        {
            foreach (Song song in this.SelectedPlaylist.Playlist.Songs)
            {
                if (song.Name == name) return song;
            }

            return null;
        }

        /// <summary>
        /// Called when the user selects a new song from the <see cref="songs_list"/>
        /// <br></br><br></br>
        /// Left click will add the song to queue. Middle click will play the song immediately. Right click will show an options menu.
        /// </summary>
        private void songs_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currently_playing_song_display.Text == "Queue")
            {
                this.songs_list.ClearSelected();
                this.ActiveControl = this.icon_and_name_display;
                return;
            }

            // TODO: the part with the modals will have to be changed once you redesign the songs_list button clicks, as there will be more functions
            // and therefore more actions that will need to be displayed


            try
            {
                Song song = GetSongByName((string)this.songs_list.SelectedItems[0]);
                this.songs_list.ClearSelected();
                this.ActiveControl = this.icon_and_name_display;
                addSongToQueue(song);
                playSong();
            } catch (IndexOutOfRangeException) { };
        }

        /// <summary>
        /// Play the next song in the <see cref="MusicQueue"/>
        /// </summary>
        private void playSong()
        {
            if (OutputDevice?.PlaybackState == PlaybackState.Playing || OutputDevice?.PlaybackState == PlaybackState.Paused)
                return;

            // prevent a song from playing twice in a row
            if (MusicQueue.Count > 1)
            {
                if (MusicQueue[0] == MusicQueue[1])
                {
                    MusicQueue.RemoveAt(0);
                }
            }
            // clear the currently playing song display
            else this.currently_playing_song_display.Text = $"{SelectedPlaylist.Playlist.Name} - Queue Empty";

            try
            {
                // play music
                if (OutputDevice == null)
                {
                    OutputDevice = new WaveOutEvent();
                    OutputDevice.Volume = CurrentPlayerVolume;
                    OutputDevice.PlaybackStopped += this.OnPlaybackStopped;
                }
                if (AudioFile == null)
                {
                    if (MusicQueue.Count > 0)
                    {
                        AudioFile = new AudioFileReader(MusicQueue[0].Path);
                        try
                        {
                            OutputDevice.Init(AudioFile);
                        }
                        catch (NAudio.MmException)
                        {
                            MessageBox.Show("Could not find an audio device. Try connecting headphones or a speaker", "Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            OutputDevice.Dispose();
                            AudioFile.Dispose();
                            AudioFile = null;
                            OutputDevice = null;

                            return;
                        }
                    }
                    else
                        return; // no music is left in the queue
                }

                // update the CurrentlyPlayingSong variable
                CurrentlyPlayingSong = MusicQueue[0];

                // do not keep track of songs that have been played over 50 songs ago
                if (PreviouslyPlayedSongs.Count >= 50)
                    PreviouslyPlayedSongs.RemoveAt(PreviouslyPlayedSongs.Count - 1);

                // remove song from queue
                MusicQueue.RemoveAt(0);

                // play the music
                OutputDevice.Play();

                // display the currently playing song
                this.currently_playing_song_display.Text = $"{SelectedPlaylist.Playlist.Name} - {CurrentlyPlayingSong.Name}";
                this.currently_playing_song_display.Location = new Point((this.songs_list.Width - this.currently_playing_song_display.Width) / 2 + this.songs_list.Location.X, this.currently_playing_song_display.Location.Y);
            }
            catch (NAudio.MmException) { };
        }

        /// <summary>
        /// Restart the current song if it is currently playlist, otherwise play it again by playing the first song in the <see cref="PreviouslyPlayedSongs"/> list
        /// </summary>
        private void replaySong_button_Click(object sender, EventArgs e)
        {
            if (AudioFile != null)
                AudioFile.Position = 0;
            else playLastSongButton_Click(null, null);
        }

        /// <summary>
        /// List of the songs that have been filtered out by the searchbox text
        /// </summary>
        private List<Song> temporarilyRemovedSongs = new List<Song>();

        /// <summary>
        /// Amount of chars in the searchbox's text
        /// </summary>
        private int previousTextLength = 0;
        
        /// <summary>
        /// Filter songs based on the searchbox text
        /// </summary>
        private void filter_songs_textbox_TextChanged(object sender, EventArgs e)
        {
            if (SelectedPlaylist.Playlist.Name == "queue") return;

            string text = Tools.Strip(this.filter_music_textbox.Text.ToLower());

            if (text.Length >= this.previousTextLength)
            {
                // new char was added, remove songs that do not start with the search-phrase
                foreach (Song song in DisplayedSongs.ToList())
                {
                    if (!song.Name.ToLower().Contains(text))
                    {
                        this.temporarilyRemovedSongs.Add(song);
                        DisplayedSongs.Remove(song);
                        this.songs_list.Items.Remove(song.Name);
                    }
                }
            }
            else
            {
                // a char was removed; look through removed songs to add back
                foreach (Song song in temporarilyRemovedSongs)
                {
                    if (song.Name.Contains(text) && !this.songs_list.Items.Contains(song.Name))
                    {
                        this.songs_list.Items.Add(song.Name);
                        DisplayedSongs.Add(song);
                    }
                }
            }
            previousTextLength = text.Length;
        }

        /// <summary>
        /// When <see cref="Groovy"/> first loads up, load the first playlist into the <see cref="songs_list"/>
        /// </summary>
        private void DisplayFirstPlaylist()
        {
            Playlist playlist = this.Playlists[0];
            SelectedPlaylist = new SelectedPlaylistItem(playlist, 0);

            this.playlists_list.ClearSelected();
            this.ActiveControl = this.filter_music_textbox;
            this.currently_playing_song_display.Text = $"{SelectedPlaylist.Playlist.Name} - Queue Empty";

            ShowPlaylistSongs(playlist);
        }

        /// <summary>
        /// Stops the music
        /// </summary>
        private void stopButton_Click(object sender, EventArgs e)
        {
            // stop playlist music
            OutputDevice?.Stop();
        }

        /// <summary>
        /// When the music stops, clear the music player then play the next song
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            try
            {
                OutputDevice.Dispose();
                OutputDevice = null;
                AudioFile.Dispose();
                AudioFile = null;
            }
            catch (NullReferenceException) { };

            // add the currently playing song 
            if (CurrentlyPlayingSong != null)
                PreviouslyPlayedSongs.Insert(0, CurrentlyPlayingSong);
            playSong();
        }

        /// <summary>
        /// Delete the modal automatically after 2.75 seconds
        /// </summary>
        private async void AutoDeleteModal()
        {
            string startingText = this.modal.Text;
            await Task.Delay(2750);
            if (startingText == this.modal.Text)
                this.modal.Text = "";
        }

        /// <summary>
        /// Add a song to the queue
        /// </summary>
        private void addSongToQueue(Song song)
        {
            // only show the "song added" message if the song isn't played right away
            if (OutputDevice?.PlaybackState == PlaybackState.Playing || OutputDevice?.PlaybackState == PlaybackState.Paused)
            {
                // display modal
                this.modal.Text = $"Added {song.Name} to queue";

                // center modal
                this.modal.Location = new Point((this.modalcontainer.Width - this.modal.Width) / 2, (this.modalcontainer.Height - this.modal.Height) / 2);

                // trigger auto-delete timer
                AutoDeleteModal();
            }

            MusicQueue.Add(song);
        }

        /// <summary>
        /// Pause or play the music when the playback button is clicked
        /// </summary>
        private void togglePlaybackButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (OutputDevice?.PlaybackState == PlaybackState.Playing)
                    OutputDevice.Pause();
                else if (OutputDevice?.PlaybackState == PlaybackState.Paused)
                    OutputDevice?.Play();
            }
            catch (NAudio.MmException) { };
        }

        private void playLastSongButton_Click(object sender, EventArgs e)
        {
            try
            {
                // add the previously played song to the current queue so it plays when the current song is skipped
                MusicQueue.Insert(0, PreviouslyPlayedSongs[0]);

                // add the currently playing song to the queue, behind the previously played song that will play soon
                // this is to have the song that was skipped to play the one before (which is right now the CurrentlyPlayingSong)
                // be next in line after the one that will be played now (PreviouslyPlayedMusic[0])
                MusicQueue.Insert(1, CurrentlyPlayingSong);

                // set CurrentlyPlayingSong to null so it's not added to the previouslyPlayedMusic again
                CurrentlyPlayingSong = null;

                // remove it from the previously played queue
                PreviouslyPlayedSongs.RemoveAt(0);

                // stop playing music to trigger the reset sequence for the player
                if (OutputDevice?.PlaybackState == PlaybackState.Playing || OutputDevice?.PlaybackState == PlaybackState.Paused)
                    OutputDevice?.Stop();
                else
                    OnPlaybackStopped(null, null);
            } catch (ArgumentOutOfRangeException) { }
            catch (IndexOutOfRangeException) { };
        }

        /// <summary>
        /// Go forward 15 seconds in the current song
        /// </summary>
        private void scrub15forwardButton_Click(object sender, EventArgs e)
        {
            if (AudioFile != null)
                AudioFile.Position += AudioFile.WaveFormat.AverageBytesPerSecond * 15;
        }

        /// <summary>
        /// Go back 15 seconds in the current song
        /// </summary>
        private void scrub15backwardButton_Click(object sender, EventArgs e)
        {
            if (AudioFile != null)
                AudioFile.Position -= AudioFile.WaveFormat.AverageBytesPerSecond * 15;
        }

        /// <summary>
        /// Activates when <see cref="volume_control_bar"/> is scrolled. The <see cref="CurrentPlayerVolume"/> will be updated and the new volume will be written to last.vol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volume_control_bar_Scroll(object sender, EventArgs e)
        {
            CurrentPlayerVolume = this.volume_control_bar.Value / 100f;
            File.WriteAllText("last.vol", CurrentPlayerVolume.ToString());

            try
            {
                if (OutputDevice != null)
                    OutputDevice.Volume = CurrentPlayerVolume;
            }
            catch (NAudio.MmException)
            {
                MessageBox.Show("Could not find an audio device. Try connecting headphones or a speaker", "Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// change the icon of the play/pause button based on the current state of the music player
        /// </summary>
        private void playbackButtonIconUpdateEventListener()
        {
            bool alreadySet_pauseImage = false;
            bool alreadySet_playImage = true;

            while (true)
            {
                if (OutputDevice?.PlaybackState == PlaybackState.Playing)
                {
                    if (!alreadySet_pauseImage)
                    {
                        this.togglePlaybackButton.Image = Properties.Resources.pause_button;
                        alreadySet_pauseImage = true;
                        alreadySet_playImage = false;
                    }
                }
                else if (OutputDevice?.PlaybackState == PlaybackState.Paused || OutputDevice?.PlaybackState == PlaybackState.Stopped)
                {
                    if (!alreadySet_playImage)
                    {
                        this.togglePlaybackButton.Image = Properties.Resources.play_button; 
                        alreadySet_playImage = true;
                        alreadySet_pauseImage = false;
                    }
                }
            }
        }

        /// <summary>
        /// Starts a thread on the <see cref="playbackButtonIconUpdateEventListener"/> function
        /// </summary>
        private void StartPlaybackButtonThread()
        {
            Thread thread = new Thread(playbackButtonIconUpdateEventListener);
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// Event listener to update the "queue" playlist each time a song is removed if a user has the "queue" playlist open
        /// </summary>
        private async void songRemovedFromMusicQueueEventListener()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                int musicQueueCount = Convert.ToInt32(MusicQueue.Count.ToString()); // deep copy syntax

                while (true)
                {
                    if (musicQueueCount != MusicQueue.Count)
                    {
                        musicQueueCount = Convert.ToInt32(MusicQueue.Count.ToString());
                        if (SelectedPlaylist.Playlist.Name == "Queue")
                            ShowPlaylistSongs(new Playlist(name: "Queue", songlist: MusicQueue));
                    }
                }
            }).Start();
        }

        /// <summary>
        /// MouseDown event for the <see cref="this.songs_list"/> element.
        /// </summary>
        private void songs_list_MouseDown(object sender, MouseEventArgs e)
        {
            // todo: different actions for right, left, and middle clicks on the songs list
        }

        /// <summary>
        /// Triggers <see cref="togglePlaybackButton_Click"/> when the spacebar is pressed
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space ) togglePlaybackButton_Click(null, null);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Opens an options menu for the currently playing song when the <see cref="currently_playing_song_display"/> is right-clicked
        /// </summary>
        private void currently_playing_song_display_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // todo: open the options menu
            }
        }

        private void currently_playing_song_display_MouseEnter(object sender, EventArgs e)
        {
            this.currently_playing_song_display.Cursor = Cursors.Hand;
        }
    }

    internal struct SelectedPlaylistItem
    {
        public Playlist Playlist { get; }
        public int Index { get; }

        public SelectedPlaylistItem(Playlist playlist, int index)
        {
            this.Playlist = playlist;
            this.Index = index;
        }
    }
}