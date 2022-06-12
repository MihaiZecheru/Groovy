namespace Groovy
{
    internal class Song
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Song(string name, string path)
        {
            this.Name = name;
            this.Path = path;
        }
    }
}
