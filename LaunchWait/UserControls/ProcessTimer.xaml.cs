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
        private int _delay;
        private int _remainingTime;
        private DispatcherTimer _timer = new DispatcherTimer(DispatcherPriority.Render);

        public ProcessTimer(string name, string path, int delay)
        {
            InitializeComponent();

            nameTextBlock.Text = name;
            _path = path;
            _delay = delay;

            InitializeTimer();

            UpdateDisplay();
        }

        private void InitializeTimer()
        {
            _remainingTime = _delay;
            _timer.Tick += new EventHandler(timer_Tick);
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
        }

        private void UpdateDisplay()
        {
            delayLabel.Content = _remainingTime.ToString();

            if (_delay <= 0)
            {
                progressBar.Value = 0;
            }
            else
            {
                progressBar.Value = (_remainingTime * 100) / _delay;
            }
        }

        public void RunProcess()
        {

            try
            {
                System.Diagnostics.Process.Start(_path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, nameTextBlock.Text);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!checkBox.IsChecked.Value)
            {
                return;
            }

            if (_remainingTime > 0)
            {
                _remainingTime -= 1;
            }

            UpdateDisplay();

            if (_remainingTime == 0)
            {
                _timer.Stop();
                RunProcess();
            }

        }

        private void nameButton_Click(object sender, RoutedEventArgs e)
        {
            checkBox.IsChecked = false;
            RunProcess();
        }
    }
}
