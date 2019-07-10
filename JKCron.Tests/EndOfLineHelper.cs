using System.Runtime.InteropServices;

namespace JKCron.Tests
{
    public static class EndOfLineHelper
    {
        private static string WindowsEndLine = "\r\n";
        private static string LinuxEndLine = "\n";

        public static string GetEndLine()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return WindowsEndLine;
            }

            return LinuxEndLine;
        }
    }
}
