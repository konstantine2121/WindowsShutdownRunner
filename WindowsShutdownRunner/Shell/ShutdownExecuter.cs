namespace WindowsShutdownRunner.Shell
{
    internal class ShutdownExecuter
    {
        private const string Shutdown = "shutdown";

        private const string AbortKey = "/a";
        private const string ForseKey = "/f";
        private const string ShutdownKey = "/s";
        private const string TimedelayInSecondsKey = "/t";

        private string ShutdownAfterFewSecondsCommandPattern = 
            $"{Shutdown} {ShutdownKey} {ForseKey} {TimedelayInSecondsKey} {{0}}";
        
        private const string AbortShutdownCommand = $"{Shutdown} {AbortKey}";
        
        private readonly ShellProvider _shellProvider;

        public ShutdownExecuter(ShellProvider shellProvider) 
        {
            _shellProvider = shellProvider;
        }

        public void ShutdownAfterFewSeconds(int seconds) 
        {
            if (seconds < 0)
            {
                seconds = 0;
            }

            _shellProvider.ExecuteCommand(string.Format(ShutdownAfterFewSecondsCommandPattern, seconds));
        }

        public void AbortShutdown()
        {
            _shellProvider.ExecuteCommand(AbortShutdownCommand);
        }
    }
}
