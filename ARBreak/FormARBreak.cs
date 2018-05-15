using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARBreak
{
    public partial class FormARBreak : Form
    {
        Process vbProcess;
        bool isProcessRunning = true;
        string tmpPath = @"";
        string absolutePath;
        int processId = 0;
        
        public FormARBreak()
        {
            InitializeComponent();
        }

        private void FormARBreak_Load(object sender, EventArgs e)
        {
            setTempFolderPath();
#if DEBUG
            absolutePath = @"C:\Users\arathod16\Desktop\ARBreak-master\ARBreak-master\Helper_Files\";
#else
            absolutePath = @"";
#endif
        }

        public void setTempFolderPath()
        {
            tmpPath = System.Environment.GetEnvironmentVariable("tmp");
        }

        public Task<int> WaitForExitAsync()//CancellationToken cancellationToken = default(CancellationToken))
        {
            var tcs = new TaskCompletionSource<int>(TaskCreationOptions.AttachedToParent);
            vbProcess.EnableRaisingEvents = true;
            vbProcess.Exited += (sender, args) => tcs.TrySetResult(0);
            //if (cancellationToken != default(CancellationToken))
            //    cancellationToken.Register( () => { tcs.TrySetCanceled(); } );
            return tcs.Task;
        }

        private void UpdateTimeLeftLabel()
        {
            // Wait for 5 seconds for the vb script to write the correct value to file
            Thread.Sleep(1000 * 5);
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

        private void StartVbScript()
        {
            vbProcess = new Process();
            vbProcess.StartInfo.FileName = @"C:\WINDOWS\SysWOW64\cscript.exe";
            vbProcess.StartInfo.Arguments = absolutePath + @"ARBreak.vbs";
            vbProcess.StartInfo.UseShellExecute = false;
            //vbProcess.StartInfo.RedirectStandardInput = true;
            vbProcess.StartInfo.CreateNoWindow = true;
            vbProcess.Start();
            isProcessRunning = true;
            // create a new file in %tmp% unique to this instance
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
                    //vbProcess.CloseMainWindow();
                    vbProcess.Kill();
                }
                catch(InvalidOperationException)
                {
                    // Ignore as process may not exist on multiple 
                }
            }
            isProcessRunning = false;
            lblTimeLeft.Text = "-- minutes left";
            CleanupFile();
        }

        private async void BtnStart_ClickAsync(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            StartVbScript();
            await WaitForExitAsync();
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
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            CloseVbScript();
        }
    }
}
