using System.Collections.Generic;
namespace LaunchWait
{
    partial class LaunchWait
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.launchNowButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelAllButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // launchNowButton
            // 
            this.launchNowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.launchNowButton.Location = new System.Drawing.Point(2, 38);
            this.launchNowButton.Name = "launchNowButton";
            this.launchNowButton.Size = new System.Drawing.Size(107, 23);
            this.launchNowButton.TabIndex = 0;
            this.launchNowButton.Text = "Launch Now!";
            this.launchNowButton.UseVisualStyleBackColor = true;
            this.launchNowButton.Click += new System.EventHandler(this.launchNowButton_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel.MaximumSize = new System.Drawing.Size(220, 220);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(220, 30);
            this.flowLayoutPanel.TabIndex = 2;
            // 
            // cancelAllButton
            // 
            this.cancelAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelAllButton.Location = new System.Drawing.Point(115, 38);
            this.cancelAllButton.Name = "cancelAllButton";
            this.cancelAllButton.Size = new System.Drawing.Size(107, 23);
            this.cancelAllButton.TabIndex = 1;
            this.cancelAllButton.Text = "Cancel All";
            this.cancelAllButton.UseVisualStyleBackColor = true;
            this.cancelAllButton.Click += new System.EventHandler(this.cancelAllButton_Click);
            // 
            // LaunchWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(224, 63);
            this.Controls.Add(this.cancelAllButton);
            this.Controls.Add(this.launchNowButton);
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "LaunchWait";
            this.Text = "LaunchWait";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private List<Startup> _startups;
        private System.Windows.Forms.Button launchNowButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button cancelAllButton;
    }
}

