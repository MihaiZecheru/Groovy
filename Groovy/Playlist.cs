using System.Collections;

namespace Groovy
{
    internal class Playlist : IEnumerable<Song>
    {
        /// <summary>
        /// <see cref="Name"/> of the <see cref="Playlist"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <see cref="IList{T}"/> of songs in the <see cref="Playlist"/>
        /// </summary>
        public IList<Song> Songs { get; set; }

        public Playlist(string name, List<Song> songlist)
        {
            this.Name = name;
            this.Songs = songlist;
        }

        public Playlist(string name, params Song[] songs)
        {
            this.Name = name;
            this.Songs = songs.ToList();
        }

        /// <summary>
        /// Iterates through <see cref="Songs"/>
        /// </summary>
        public IEnumerator<Song> GetEnumerator()
        {
            foreach (Song song in Songs) yield return song;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
