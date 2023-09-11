using System.ComponentModel;
using WindowsShutdownRunner.Shell;

namespace WindowsShutdownRunner.ViewModel
{
    internal class MainWindowVm : INotifyPropertyChanged
    {
        #region Fields
        

        private readonly ShutdownExecuter _shutdownExecuter = new ShutdownExecuter(new ShellProvider());

        private int _seconds;
        private int _minutes;
        private int _hours;

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion Fields
        
        #region Properties

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

        public int TotalSeconds { get; set; }

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
