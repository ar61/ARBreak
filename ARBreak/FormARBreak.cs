using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARBreak
{
    public partial class FormARBreak : Form
    {
        Process batchProcess;
        bool isProcessRunning = true;
        string absolutePath = @"C:\Users\User\Desktop\";
        public FormARBreak()
        {
            InitializeComponent();
        }

        public Task WaitForExitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.AttachedToParent);
            batchProcess.EnableRaisingEvents = true;
            batchProcess.Exited += (sender, args) => tcs.TrySetResult(null);
            if (cancellationToken != default(CancellationToken))
                cancellationToken.Register( () => { tcs.TrySetCanceled(); } );
            return tcs.Task;
        }

        private void UpdateTimeLeftLabel()
        {
            while ( isProcessRunning )
            {
                System.IO.StreamReader file = new System.IO.StreamReader(absolutePath + @"ARBreak_.txt");
                string readLine = "", line;
                while ((line = file.ReadLine()) != null)
                {
                    readLine = line;
                }
                file.Close();
                // To pass back control to Main Thread to update UI
                // Since UI can only be updated on the main thread
                this.lblTimeLeft.Invoke( (MethodInvoker) delegate {
                    this.lblTimeLeft.Text = readLine.Split(' ')[0] + " minutes left";
                } );
                Thread.Sleep(1000);
            }
        }

        private void StartBatchScript()
        {
            batchProcess = new Process();
            batchProcess.StartInfo.FileName = absolutePath + "ARBreak_Start.bat";
            batchProcess.StartInfo.UseShellExecute = false;
            batchProcess.StartInfo.RedirectStandardInput = true;
            batchProcess.StartInfo.CreateNoWindow = true;
            batchProcess.Start();
            isProcessRunning = true;
            new Task(UpdateTimeLeftLabel).Start();
        }

        private void CloseBatchScript()
        {
            if (batchProcess != null && batchProcess.StartInfo != null)
            {
                try
                {
                    batchProcess.CloseMainWindow();
                    foreach (var process in Process.GetProcessesByName("cscript"))
                    {
                        process.Kill();
                    }
                }
                catch(InvalidOperationException)
                {

                }
            }
            isProcessRunning = false;
            lblTimeLeft.Text = "-- minutes left";
        }

        private async void BtnStart_ClickAsync(object sender, EventArgs e)
        {
            StartBatchScript();
            await WaitForExitAsync();
        }

        private void OnQuit_Clicked(object sender, FormClosingEventArgs e)
        {
            CloseBatchScript();
        }

        private async void btnRestart_ClickAsync(object sender, EventArgs e)
        {
            CloseBatchScript();
            StartBatchScript();
            await WaitForExitAsync();
        }

        private void FormARBreak_Load(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            CloseBatchScript();
        }
    }
}
