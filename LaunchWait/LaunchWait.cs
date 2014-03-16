using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LaunchWait.Configuration;

namespace LaunchWait
{
    public partial class LaunchWait : Form
    {
        public LaunchWait()
        {
            InitializeComponent();
            _startups = new List<Startup>();

            var allProcesses = Configuration.Section.GetSection();
            
            foreach (Process key in allProcesses.LaunchSettings)
            {
                
                var startup = new Startup(key.Name, key.Path);
                startup.Time = key.Delay;
                _startups.Add(startup);

                var label = new Label();
                label.Text = startup.Name;

                flowLayoutPanel.Controls.Add(label);
                flowLayoutPanel.Controls.Add(startup.Label);
                Console.WriteLine(key);
            }
        
            foreach(Startup startup in _startups)
            {
                startup.StartCountdown();
            }

        }

        private void launchNowButton_Click(object sender, EventArgs e)
        {
            foreach (Startup startup in _startups)
            {
                startup.RunNow();
            }
        }

        private void cancelAllButton_Click(object sender, EventArgs e)
        {
            foreach (Startup startup in _startups)
            {
                startup.CancelCountdown();
            }
        }
    }
}
