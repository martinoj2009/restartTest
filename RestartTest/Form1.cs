using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace RestartTest
{
    public partial class Form1 : Form
    {
        public static bool stop = false;
        public static string programPath = System.IO.Path.GetFullPath(Application.ExecutablePath);

        public Form1()
        {
            InitializeComponent();

            //Check to see if a log file exists
            if(File.Exists(Application.StartupPath + "\\log.txt"))
            {
                //The log file exists, log the start and restart
                logCheckBox.Checked = true;
            }

            main();
        }


        private void main()
        {
            writeLog("Application started");
            restartTime.Text = "15";
            BW1.WorkerSupportsCancellation = true;
            BW1.RunWorkerAsync();

            startButton.Enabled = false;
            stopButton.Enabled = true;

        }




        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void BW1_DoWork(object sender, DoWorkEventArgs e)
        {
            //What ever the timer is set that to the counter
            int counter = Int32.Parse(restartTime.Text);

            while (counter > 0)
            {
                //Break if stop has been set
                if(stop == true)
                {
                    return;
                }

                Invoke(new Action(() =>
                restartTime.Text = counter.ToString()));

                Thread.Sleep(1000);

                counter--;
            }

            //Invoke again to show 0
            Invoke(new Action(() =>
                restartTime.Text = counter.ToString()));

            if(restartSystem())
            {
                writeLog("Restarting");
                Invoke(new Action(() =>
                restartLabel.Text = "Restarting!"));

                Invoke(new Action(() =>
                restartTime.Visible = false));
            }

            return;

        }

        private bool restartSystem()
        {
            //If stop is set then don't cont restart
            if(stop == true)
            {
                return false;
            }

            //Launch the restart with no window 
            System.Diagnostics.Process launch = new System.Diagnostics.Process();
            launch.StartInfo.FileName = @"C:\Windows\System32\shutdown.exe";
            launch.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            launch.StartInfo.CreateNoWindow = true;
            launch.StartInfo.Arguments = "/r /t 0";

            try
            {
                launch.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            //Press this button to stop the countdown and quit
            stop = true;
            BW1.CancelAsync();

            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        private void removeStartupButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Only perform this task if the startup key esists
                if (startupExists() == true)
                {
                    RegistryKey startupItems = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    startupItems.DeleteValue("RestartTest");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void addStartupButton_Click(object sender, EventArgs e)
        {
            //As long as there's not an entry in the startup then add one
            if(startupExists() == false)
            {
                try
                {
                    //Entry doesn't exist
                    RegistryKey startupItems = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    startupItems.CreateSubKey("RestartTest");
                    startupItems.SetValue("RestartTest", programPath, RegistryValueKind.String);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private bool startupExists()
        {
            try
            {
                RegistryKey startupItems = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");

                foreach (string item in startupItems.GetValueNames())
                {
                    if (item == "RestartTest")
                    {
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            return false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void BW1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Reset the timer
            Invoke(new Action(() =>
                restartTime.Text = "15"));
        }

        private void writeLog(string message)
        {
            //Only do this if loggin is checked
            if(logCheckBox.Checked == true)
            {
                //This function will write the log for the restart if the user would like to keep track
                try
                {
                    System.IO.File.AppendAllText(Application.StartupPath + "\\log.txt", DateTime.Now.ToString() + " " + message + Environment.NewLine);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            
        }

        private void logCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if(logCheckBox.Checked == true)
            {
                if(File.Exists(Application.StartupPath + "\\log.txt") == false)
                {
                    try
                    {
                        //Create the file since it doesn't exist
                        FileStream file = File.Create(Application.StartupPath + "\\log.txt");
                        file.Close();
                        writeLog("Logging enabled");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }
            else
            {
                if(File.Exists(Application.StartupPath + "\\log.txt"))
                {
                    //The check box has been unchecked, so delete the log
                    try
                    {
                        File.Delete(Application.StartupPath + "\\log.txt");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
