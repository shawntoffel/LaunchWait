using LaunchWait.UserControls;
using System.Windows;
using System.Windows.Input;

namespace LaunchWait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            var allProcesses = Configuration.Section.GetSection();

            foreach (Configuration.Process process in allProcesses.LaunchSettings)
            {
                var control = new ProcessTimer(process.Name, process.Path, process.Delay);

                stackPanel.Children.Add(control);
            }
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }

            DragMove();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void cancelAllButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void launchNowButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (ProcessTimer process in stackPanel.Children)
            {
                process.RunProcess();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var workArea = System.Windows.SystemParameters.WorkArea;

            this.MaxHeight = workArea.Height;
            this.Left = workArea.Right - this.Width;
            this.Top = workArea.Bottom - this.Height;
        }
    }
}
