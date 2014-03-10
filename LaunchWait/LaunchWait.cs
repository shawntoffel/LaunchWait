using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace launchwait
{
    public partial class LaunchWait : Form
    {
        public LaunchWait()
        {
            InitializeComponent();
            _startups = new List<Startup>();

            var allPrograms = System.Configuration.ConfigurationManager.AppSettings;

            foreach (string key in allPrograms)
            {
                var startup = new Startup(key, allPrograms[key]);
                startup.Time = 5;
                _startups.Add(startup);

                var label = new Label();
                label.Text = startup.Name;

                flowLayoutPanel.Controls.Add(label);
                flowLayoutPanel.Controls.Add(startup.Label);
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
