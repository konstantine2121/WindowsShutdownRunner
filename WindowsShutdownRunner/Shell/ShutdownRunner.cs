namespace WindowsShutdownRunner.Shell
{
    internal class ShutdownRunner
    {
        private const string ShutdownCommand = "shutdown";

        private const string AbortKey = "/a";
        private const string ForceKey = "/f";
        private const string ShutdownKey = "/s";
        private const string TimedelayInSecondsKey = "/t";

        private string ShutdownAfterFewSecondsCommandPattern = 
            $"{ShutdownCommand} {ShutdownKey} {ForceKey} {TimedelayInSecondsKey} {{0}}";
        
        private const string AbortShutdownCommand = $"{ShutdownCommand} {AbortKey}";
        
        private readonly ShellExecuter _shellProvider;

        public ShutdownRunner(ShellExecuter shellProvider) 
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
