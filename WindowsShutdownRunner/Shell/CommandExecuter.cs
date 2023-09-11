namespace WindowsShutdownRunner.Shell
{
    internal class CommandExecuter
    {
        private const string Shutdown = "shutdown";
        private const string Splitter = " ";



        private const string AbortKey = "/a";
        private const string ForseKey = "/f";
        private const string ShutdownKey = "/s";
        private const string TimedelayInSecondsKey = "/t";

        private string ShutdownAfterFewSecondsCommandPattern
        {
            get
            {
                return $"{Shutdown} {ShutdownKey} {ForseKey} {TimedelayInSecondsKey} {{0}}";
            }
        }

        private string AbortShutdownCommand
        {
            get
            {
                return $"{Shutdown} {AbortKey}";
            }
        }
    }
}
