namespace ChrisTools
{
    public class Tools
    {
        private static Random random = new Random();
        static private char[] heavyTrim = {' ', '?', '!', '"', (char)34, '#', '$', '%', '&', (char)39, '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'};
        static private char[] lightTrim = {' ', '?', '!', '.', ',', ';', ':'};

        /// <summary>
        /// Capitalizes the first letter of a string
        /// </summary>
        /// <param name="x">String to capitalize the first letter of</param>
        public static string CapitalizeFirstLetter(string x)
        {
            return x.Substring(0, 1).ToUpper() + x.Substring(1);
        }

        /// <summary>
        /// Capitalizes every letter in a string
        /// </summary>
        /// <param name="x">String to title</param>
        public static string Title(string x)
        {
            return string.Join(" ", x.Split(' ').ToList()
                .ConvertAll(word =>
                    word.Substring(0, 1).ToUpper() + word.Substring(1)
                ));
        }

        /// <summary>
        /// Strips a series of characters from the front and end of a string. Can strip all non-alphanumeric chars (heavy=true) or all punctuation (heavy=false)
        /// </summary>
        /// <param name="x">String to strip</param>
        /// <param name="heavy">Strip mode;
        /// true will trim: {' ', '?', '!', '"', (char)34, '#', '$', '%', '&', (char)39, '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'}
        /// false will trim: {' ', '?', '!', '.', ',', ';', ':'}
        /// </param>
        public static string Strip(string x, bool heavy = false)
        {
            if (heavy)
                return x.Trim(heavyTrim);
            return x.Trim(lightTrim);
        }

        /// <summary>
        /// Gets a random number between x and y
        /// </summary>
        /// <param name="x">Start of range</param>
        /// <param name="y">End of range</param>
        public static int Randint(int x, int y)
        {
            return random.Next(x, y);
        }
    }
}