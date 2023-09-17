using System.ComponentModel;
using System.Windows.Input;
using WindowsShutdownRunner.Shell;

namespace WindowsShutdownRunner.ViewModel
{
    internal class MainWindowVm : INotifyPropertyChanged
    {
        private const int MinutesInHour = 60;
        private const int SecondsInMinute = 60;
        private const int SecondsInHour = SecondsInMinute * MinutesInHour;

        #region Fields
        
        private readonly ShutdownRunner _shutdownExecuter = new ShutdownRunner(new ShellExecuter());

        private int _seconds = 10;
        private int _minutes;
        private int _hours;

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion Fields

        #region Properties

        #region Time

        public int Seconds
        {
            get => _seconds;
            set
            {
                _seconds = value < 0 ? 0 : value;
                RaisePropertyChanged(nameof(TotalSeconds));
            }
        }

        public int Minutes
        {
            get => _minutes;
            set
            {
                _minutes = value < 0 ? 0 : value;
                RaisePropertyChanged(nameof(TotalSeconds));
            }
        }

        public int Hours
        {
            get => _hours;
            set
            {
                _hours = value < 0 ? 0 : value;
                RaisePropertyChanged(nameof(TotalSeconds));
            }
        }

        public int TotalSeconds => Seconds + Minutes * SecondsInMinute + Hours * SecondsInHour;

        #endregion Time
                
        #endregion Properties

        #region Functions

        public void Shutdown()
        {
            _shutdownExecuter.ShutdownAfterFewSeconds(TotalSeconds);
        }

        public void Abort()
        {
            _shutdownExecuter.AbortShutdown();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Functions
    }
}
