namespace Wiki_App_Devel
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new WikiDevel());
        }
    }
}