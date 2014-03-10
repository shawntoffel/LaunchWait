using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace launchwait
{
    class Startup
    {
        public string Name { get; set; }
        public string Path { get; set; }

        private int _time;
        private Timer _timer;
        private Label _timeLabel;

        public Startup(string name, string path)
        {
            Name = name;
            Path = path;

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(Timer_Tick);

            _timeLabel = new System.Windows.Forms.Label();
        }

        public int Time
        {
            get { return _time; }
            set
            {
                _time = value;
                _timeLabel.Text = Time.ToString();
            }
        }

        public Label Label
        {
            get { return _timeLabel; }
        }

        public void StartCountdown()
        {
            _timeLabel.Text = _time.ToString();
            _timer.Start();
        }

        public void RunNow()
        {
            _timer.Stop();
            Launch();
        }

        public void CancelCountdown()
        {
            _timer.Stop();
            _timeLabel.Text = "Cancelled!";
        }

        /// <summary>
        /// Run the program
        /// </summary>
        public void Launch()
        {
            try
            {
                System.Diagnostics.Process.Start(Path);
            }
            catch
            {
                _timeLabel.Text = "Failed to launch!";
            }

            _timeLabel.Text = "launched!";
        }

        /// <summary>
        /// Tick hadler for timer. Stop when reaches zero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_time > 0)
            {
                _time -= 1;
                _timeLabel.Text = Time.ToString();
            }
            else
            {
                RunNow();
            }
        }
    }
}
