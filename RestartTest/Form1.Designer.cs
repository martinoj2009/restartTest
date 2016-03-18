namespace RestartTest
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BW1 = new System.ComponentModel.BackgroundWorker();
            this.restartLabel = new System.Windows.Forms.Label();
            this.restartTime = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.removeStartupButton = new System.Windows.Forms.Button();
            this.addStartupButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.logCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BW1
            // 
            this.BW1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW1_DoWork);
            this.BW1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW1_RunWorkerCompleted);
            // 
            // restartLabel
            // 
            this.restartLabel.AutoSize = true;
            this.restartLabel.Location = new System.Drawing.Point(39, 44);
            this.restartLabel.Name = "restartLabel";
            this.restartLabel.Size = new System.Drawing.Size(72, 13);
            this.restartLabel.TabIndex = 0;
            this.restartLabel.Text = "Restarting in: ";
            // 
            // restartTime
            // 
            this.restartTime.AutoSize = true;
            this.restartTime.Location = new System.Drawing.Point(117, 44);
            this.restartTime.Name = "restartTime";
            this.restartTime.Size = new System.Drawing.Size(13, 13);
            this.restartTime.TabIndex = 1;
            this.restartTime.Text = "0";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(11, 80);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(84, 70);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // removeStartupButton
            // 
            this.removeStartupButton.Location = new System.Drawing.Point(13, 156);
            this.removeStartupButton.Name = "removeStartupButton";
            this.removeStartupButton.Size = new System.Drawing.Size(82, 70);
            this.removeStartupButton.TabIndex = 3;
            this.removeStartupButton.Text = "Remove Startup";
            this.removeStartupButton.UseVisualStyleBackColor = true;
            this.removeStartupButton.Click += new System.EventHandler(this.removeStartupButton_Click);
            // 
            // addStartupButton
            // 
            this.addStartupButton.Location = new System.Drawing.Point(101, 156);
            this.addStartupButton.Name = "addStartupButton";
            this.addStartupButton.Size = new System.Drawing.Size(82, 70);
            this.addStartupButton.TabIndex = 4;
            this.addStartupButton.Text = "Add Startup";
            this.addStartupButton.UseVisualStyleBackColor = true;
            this.addStartupButton.Click += new System.EventHandler(this.addStartupButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(99, 80);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(84, 70);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "RESTART";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // logCheckBox
            // 
            this.logCheckBox.AutoSize = true;
            this.logCheckBox.Location = new System.Drawing.Point(86, 232);
            this.logCheckBox.Name = "logCheckBox";
            this.logCheckBox.Size = new System.Drawing.Size(44, 17);
            this.logCheckBox.TabIndex = 6;
            this.logCheckBox.Text = "Log";
            this.logCheckBox.UseVisualStyleBackColor = true;
            this.logCheckBox.CheckStateChanged += new System.EventHandler(this.logCheckBox_CheckStateChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 261);
            this.Controls.Add(this.logCheckBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.addStartupButton);
            this.Controls.Add(this.removeStartupButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.restartTime);
            this.Controls.Add(this.restartLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restart Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BW1;
        private System.Windows.Forms.Label restartLabel;
        private System.Windows.Forms.Label restartTime;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button removeStartupButton;
        private System.Windows.Forms.Button addStartupButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox logCheckBox;
    }
}

