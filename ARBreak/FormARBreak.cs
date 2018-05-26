using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARBreak
{
    public partial class FormARBreak : Form
    {
        Process vbProcess = null;
        int currentInterval = 0;
        bool isProcessRunning = true;
        bool isForceQuit = false;
        string tmpPath = @"";
        string absolutePath;
        int processId = 0;
        int timeLeftMins = 0;
        Status prevStatus = Status.NOT_RUNNING;
        
        enum Status
        {
            NOT_RUNNING,
            TIME_TO_WORK,
            TAKE_A_BREAK,
            SNOOZE,
        }
        Status timerStatus;

        public FormARBreak()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void FormARBreak_Load(object sender, EventArgs e)
        {
            setTempFolderPath();
#if DEBUG
            absolutePath = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetEntryAssembly().Location) + @"\..\..\..\Helper_Files\";
#else
            absolutePath = @"";
#endif
            timerStatus = Status.NOT_RUNNING;
            UpdateStatusColor();

        }

        public void setTempFolderPath()
        {
            tmpPath = System.Environment.GetEnvironmentVariable("tmp");
        }

        private void SetInterval()
        {
            if(timerStatus == Status.TAKE_A_BREAK)
            {
                currentInterval = (int)numBreak.Value;
            }
            else if (timerStatus == Status.SNOOZE)
            {
                currentInterval = timeLeftMins + 5;
            }
            else
            {
                currentInterval = (int)numWork.Value;
            }
        }

        private void UpdateStatusColor()
        {
            lblStatus.Text = timerStatus.ToString();
            if (timerStatus == Status.TIME_TO_WORK)
            {
                lblStatus.BackColor = System.Drawing.Color.GreenYellow;
            }
            else if (timerStatus == Status.TAKE_A_BREAK)
            {
                lblStatus.BackColor = System.Drawing.Color.Orchid;
            }
        }

        public Task<int> WaitForExitAsync()
        {
            var tcs = new TaskCompletionSource<int>(TaskCreationOptions.AttachedToParent);
            vbProcess.EnableRaisingEvents = true;
            vbProcess.Exited += (sender, args) => tcs.TrySetResult(0);
            return tcs.Task;
        }

        private void UpdateTimeLeftLabel()
        {
            // Wait for 2 seconds for the vb script to write the correct value to file
            Thread.Sleep(1000*2);
            processId = vbProcess.Id;
            while ( isProcessRunning )
            {
                try
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(tmpPath + @"\ARBreak_data_" + processId + ".txt");
                    string readLine = "", line;
                    while ((line = file.ReadLine()) != null)
                    {
                        readLine = line;
                    }
                    file.Close();
                    timeLeftMins = Int32.Parse( readLine.Split(' ')[0] );
                    // To pass back control to Main Thread to update UI
                    // Since UI can only be updated on the main thread
                    this.lblTimeLeft.Invoke((MethodInvoker)delegate {
                        this.lblTimeLeft.Text = readLine.Split(' ')[0] + " minutes left";
                    });
                }
                catch(System.IO.FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Thread.Sleep(1000 * 30);
            }
        }

        private void ShowPopup()
        {
            Popup popup = new Popup();
            popup.data = timerStatus.ToString();
            popup.Owner = this;
            popup.TopMost = true;
            popup.ShowInTaskbar = false;
            popup.StartPosition = FormStartPosition.CenterScreen;
            popup.ShowDialog();
        }

        private void UpdateLoop()
        {
            while(isProcessRunning)
            {
                Thread.Sleep(1000);
            }
            // If we press quit/restart we should not automatically start a new process
            // else we start our break timer
            if (!isForceQuit)
            {
                if (timerStatus == Status.TIME_TO_WORK)
                {
                    timerStatus = Status.TAKE_A_BREAK;
                }
                else
                {
                    timerStatus = Status.TIME_TO_WORK;
                }
                this.Invoke((MethodInvoker) delegate { ShowPopup(); });
                this.flMain.Invoke((MethodInvoker)delegate {
                    this.flMain.Visible = true;
                });
                //Thread.Sleep(1000);
                this.btnStart.Invoke((MethodInvoker)delegate {
                    this.btnStart.PerformClick();
                });
                //Thread.Sleep(1000);
                this.flMain.Invoke((MethodInvoker)delegate {
                    this.flMain.Visible = false;
                });
            }
            else
            {
                timerStatus = Status.NOT_RUNNING;
            }
        }

        private void StartVbScript()
        {
            if(vbProcess != null)
            {
                vbProcess.Dispose();
                vbProcess = null;
            }
            btnStart.Enabled = false;
            SetInterval();
            vbProcess = new Process();
            vbProcess.StartInfo.FileName = @"C:\WINDOWS\SysWOW64\cscript.exe";
            vbProcess.StartInfo.Arguments = absolutePath + @"ARBreak.vbs" + " " + currentInterval;
            vbProcess.StartInfo.UseShellExecute = false;
            vbProcess.StartInfo.CreateNoWindow = true;
            vbProcess.Start();
            isProcessRunning = true;
            isForceQuit = false;
            if( timerStatus == Status.NOT_RUNNING)
                timerStatus = Status.TIME_TO_WORK;
            UpdateStatusColor();
            new Task(UpdateLoop).Start();
            new Task(UpdateTimeLeftLabel).Start();
        }

        private void CleanupFile()
        {
            // Delete temp log file if vb script is killed by force
            if (System.IO.File.Exists(tmpPath + @"\ARBreak_data_" + processId + ".txt"))
            {
                System.IO.File.Delete(tmpPath + @"\ARBreak_data_" + processId + ".txt");
            }
        }

        private void CloseVbScript()
        {
            if (vbProcess != null && vbProcess.StartInfo != null)
            {
                try
                {
                    vbProcess.Kill();
                }
                catch(InvalidOperationException)
                {
                    // Ignore as process may not exist
                }
            }
            isForceQuit = true;
            isProcessRunning = false;
            btnStart.Enabled = true;
            lblTimeLeft.Text = "-- minutes left";
            CleanupFile();
            timerStatus = Status.NOT_RUNNING;
            UpdateStatusColor();
            SetInterval();
        }

        private async void BtnStart_ClickAsync(object sender, EventArgs e)
        {
            StartVbScript();
            await WaitForExitAsync();
            isProcessRunning = false;
            btnStart.Enabled = true;
        }

        private void OnQuit_Clicked(object sender, FormClosingEventArgs e)
        {
            CloseVbScript();
        }

        private async void btnRestart_ClickAsync(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            CloseVbScript();
            StartVbScript();
            await WaitForExitAsync();
            isProcessRunning = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            CloseVbScript();
        }

        private async void btnSnooze_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            CloseVbScript();
            prevStatus = timerStatus;
            timerStatus = Status.SNOOZE;
            StartVbScript();
            await WaitForExitAsync();
            isProcessRunning = false;
            btnSnooze.Enabled = false;
        }

        private void btnSizeController_MouseEnter(object sender, EventArgs e)
        {
            btnSizeController.Text = btnSizeController.Text == "+" ? "-" : "+";
            flMain.Visible = flMain.Visible ? false : true;
        }
    }
}
