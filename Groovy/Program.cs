namespace Groovy
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetupSystemFiles();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Groovy());
        }

        /// <summary>
        /// Create C:\groovy if it does not exist. This will typically only be used the first time the application is launched
        /// </summary>
        static void SetupSystemFiles()
        {
            if (!Directory.Exists(@"C:\groovy"))
                Directory.CreateDirectory(@"C:\groovy\Favorites");
        }
    }
}