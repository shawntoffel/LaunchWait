using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace LaunchWait.UserControls
{
    /// <summary>
    /// Interaction logic for ProgramTimer.xaml
    /// </summary>
    public partial class ProcessTimer : UserControl
    {
        private string _path;
        private string _arguments;
        private int _delay;
        private int _remainingTime;
        private DispatcherTimer _timer;

        public event EventHandler Complete;

        public ProcessTimer(string name, string path, string arguments, int delay)
        {
            InitializeComponent();

            _path = path;
            _delay = delay;
            _arguments = arguments;

            // set the process name to display
            nameTextBlock.Text = name;

            // initialize the timer
            InitializeTimer();

            UpdateDisplay();
        }

        /// <summary>
        /// Initialize and start a DispatcherTimer
        /// </summary>
        private void InitializeTimer()
        {
            _remainingTime = _delay;

            // create a new timer with a 1 second tick
            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Tick += new EventHandler(timer_Tick);
            _timer.Interval = new TimeSpan(0, 0, 1);

            _timer.Start();
        }

        /// <summary>
        /// Update the delay countdown progess
        /// </summary>
        private void UpdateDisplay()
        {
            // update the displayed number
            delayLabel.Content = _remainingTime.ToString();

            // update the progress bar
            progressBar.Value = (_delay > 0) ? ((_remainingTime * 100) / _delay) : 0;
        }

        /// <summary>
        /// Send a complete event
        /// </summary>
        private void SendComplete()
        {
            if (this.Complete != null)
            {
                this.Complete(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Run the process
        /// </summary>
        public void RunProcess()
        {
            // stop the timer
            _timer.Stop();

            try
            {
                System.Diagnostics.Process.Start(_path, _arguments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, nameTextBlock.Text);
            }

            // We are finished tracking this process
            SendComplete();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // decrement the remaining time
            if (_remainingTime > 0)
            {
                _remainingTime -= 1;
            }

            // update the displayed remaining time
            UpdateDisplay();

            // launch the process
            if (_remainingTime == 0)
            {
                RunProcess();
            }
        }

        private void nameButton_Click(object sender, RoutedEventArgs e)
        {
            RunProcess();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            // just stop the timer and send complete
            _timer.Stop();
            SendComplete();
        }
    }
}
