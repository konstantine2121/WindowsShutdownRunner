using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsShutdownRunner.Shell;
using WindowsShutdownRunner.ViewModel;

namespace WindowsShutdownRunner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private readonly MainWindowVm _vm = new MainWindowVm();

        public MainWindow()
        {
            DataContext = _vm;
            InitializeComponent();
        }

        private void Shutdown_Click(object sender, RoutedEventArgs e)
        {
            _vm.Shutdown();
        }

        private void Abort_Click(object sender, RoutedEventArgs e)
        {
            _vm.Abort();
        }
    }
}
