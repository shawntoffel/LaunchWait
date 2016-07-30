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

            // Load configuration and populate panel
            LoadConfiguration();
        }

        /// <summary>
        /// Load configuration from CustomConfiguration, and add process UserControls to Panel
        /// </summary>
        private void LoadConfiguration()
        {
            // Read process and delay information from the configuation
            var allProcesses = Configuration.Section.GetSection();

            foreach (Configuration.Process process in allProcesses.LaunchSettings)
            {
                // create a new process timer with the configuration information
                var control = new ProcessTimer(process.Name, process.Path, process.Arguments, process.Delay);
                control.Complete += processTimer_Complete;

                // add the process control to the panel
                stackPanel.Children.Add(control);
            }
        }

        /// <summary>
        /// Drag the window via left mouse button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Reset the window if currently maximixed
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }

            DragMove();
        }

        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Minimize the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Cancel all processes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelAllButton_Click(object sender, RoutedEventArgs e)
        {
            // Just close the window
            Close();
        }

        /// <summary>
        /// Launch all processes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void launchNowButton_Click(object sender, RoutedEventArgs e)
        {
            while(stackPanel.Children.Count > 0)
            {
                (stackPanel.Children[0] as ProcessTimer).RunProcess();
            }
        }

        /// <summary>
        /// Removes completed processes from the panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processTimer_Complete(object sender, System.EventArgs e)
        {
            stackPanel.Children.Remove(sender as ProcessTimer);

            // Close the window when no processes remain
            if (stackPanel.Children.Count == 0)
            {
                Close();
            }
        }

        /// <summary>
        /// Loads the window in the bottom right corner of the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // get the working area of the screen
            var workArea = System.Windows.SystemParameters.WorkArea;

            // define the max and min window height
            this.MaxHeight = workArea.Height;
            this.MinHeight = this.ActualHeight;

            // place window in the bottom right corner
            this.Left = workArea.Right - this.Width;
            this.Top = workArea.Bottom - this.Height;
        }
    }
}
