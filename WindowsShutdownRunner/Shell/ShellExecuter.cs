using System.Diagnostics;

namespace WindowsShutdownRunner.Shell
{
    /// <summary>
    /// Provide shell to execute commands
    /// See help here<br/>
    /// https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/cmd
    /// </summary>
    internal class ShellExecuter
    {
        private const string CmdFileName = "cmd.exe";

        /// <summary>
        /// Carries out the command specified by string and then exits the command processor.
        /// </summary>
        private const string cParameter = "/c";

        private static void ExecuteCommandExample()
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
            process.StartInfo = startInfo;
            process.Start();
        }
        
        public void ExecuteCommand(string commandWithArgumentsString) 
        {
            var process = new Process();
            process.StartInfo = CreateStartInfo(commandWithArgumentsString);
            process.Start();
        }

        private static ProcessStartInfo CreateStartInfo(string commandWithArgumentsString) 
        {
            var startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = CmdFileName;
            startInfo.Arguments = CreateArgumentsString(commandWithArgumentsString);

            return startInfo;
        }

        private static string CreateArgumentsString(string commandWithArgumentsString)
        {
            return $"{cParameter} {commandWithArgumentsString}";
        }
    }
}
