namespace ARBreak
{
    partial class FormARBreak
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
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.numBreak = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numWork = new System.Windows.Forms.NumericUpDown();
            this.btnSnooze = new System.Windows.Forms.Button();
            this.flButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.flInput = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSnoozeName = new System.Windows.Forms.Label();
            this.numSnooze = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.flMain = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSizeController = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numBreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWork)).BeginInit();
            this.flButtons.SuspendLayout();
            this.flInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSnooze)).BeginInit();
            this.flMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Lime;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(140, 62);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_ClickAsync);
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft.Location = new System.Drawing.Point(81, 39);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(193, 31);
            this.lblTimeLeft.TabIndex = 1;
            this.lblTimeLeft.Text = "-- minutes left";
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.Location = new System.Drawing.Point(3, 71);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(140, 64);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_ClickAsync);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Location = new System.Drawing.Point(83, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 24);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "N.A.";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(3, 141);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(140, 70);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // numBreak
            // 
            this.numBreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBreak.Location = new System.Drawing.Point(3, 86);
            this.numBreak.Name = "numBreak";
            this.numBreak.Size = new System.Drawing.Size(84, 29);
            this.numBreak.TabIndex = 5;
            this.numBreak.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Minutes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Break Interval:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Work Interval:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Minutes";
            // 
            // numWork
            // 
            this.numWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWork.Location = new System.Drawing.Point(3, 27);
            this.numWork.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numWork.Name = "numWork";
            this.numWork.Size = new System.Drawing.Size(84, 29);
            this.numWork.TabIndex = 9;
            this.numWork.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // btnSnooze
            // 
            this.btnSnooze.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSnooze.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnooze.Location = new System.Drawing.Point(3, 217);
            this.btnSnooze.Name = "btnSnooze";
            this.btnSnooze.Size = new System.Drawing.Size(140, 64);
            this.btnSnooze.TabIndex = 12;
            this.btnSnooze.Text = "Snooze";
            this.btnSnooze.UseVisualStyleBackColor = false;
            this.btnSnooze.Click += new System.EventHandler(this.btnSnooze_Click);
            // 
            // flButtons
            // 
            this.flButtons.Controls.Add(this.btnStart);
            this.flButtons.Controls.Add(this.btnRestart);
            this.flButtons.Controls.Add(this.btnStop);
            this.flButtons.Controls.Add(this.btnSnooze);
            this.flButtons.Location = new System.Drawing.Point(220, 3);
            this.flButtons.Name = "flButtons";
            this.flButtons.Size = new System.Drawing.Size(158, 291);
            this.flButtons.TabIndex = 13;
            // 
            // flInput
            // 
            this.flInput.Controls.Add(this.label4);
            this.flInput.Controls.Add(this.numWork);
            this.flInput.Controls.Add(this.label5);
            this.flInput.Controls.Add(this.label2);
            this.flInput.Controls.Add(this.numBreak);
            this.flInput.Controls.Add(this.label1);
            this.flInput.Controls.Add(this.lblSnoozeName);
            this.flInput.Controls.Add(this.numSnooze);
            this.flInput.Controls.Add(this.label7);
            this.flInput.Location = new System.Drawing.Point(3, 3);
            this.flInput.Name = "flInput";
            this.flInput.Size = new System.Drawing.Size(211, 277);
            this.flInput.TabIndex = 14;
            // 
            // lblSnoozeName
            // 
            this.lblSnoozeName.AutoSize = true;
            this.lblSnoozeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSnoozeName.Location = new System.Drawing.Point(3, 118);
            this.lblSnoozeName.Name = "lblSnoozeName";
            this.lblSnoozeName.Size = new System.Drawing.Size(144, 24);
            this.lblSnoozeName.TabIndex = 12;
            this.lblSnoozeName.Text = "Snooze Interval:";
            // 
            // numSnooze
            // 
            this.numSnooze.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSnooze.Location = new System.Drawing.Point(3, 145);
            this.numSnooze.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSnooze.Name = "numSnooze";
            this.numSnooze.Size = new System.Drawing.Size(84, 29);
            this.numSnooze.TabIndex = 13;
            this.numSnooze.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(93, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "Minutes";
            // 
            // flMain
            // 
            this.flMain.AutoSize = true;
            this.flMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flMain.Controls.Add(this.flInput);
            this.flMain.Controls.Add(this.flButtons);
            this.flMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flMain.Location = new System.Drawing.Point(1, 75);
            this.flMain.MaximumSize = new System.Drawing.Size(381, 297);
            this.flMain.Name = "flMain";
            this.flMain.Size = new System.Drawing.Size(381, 297);
            this.flMain.TabIndex = 15;
            // 
            // btnSizeController
            // 
            this.btnSizeController.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSizeController.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSizeController.Location = new System.Drawing.Point(1, 40);
            this.btnSizeController.Margin = new System.Windows.Forms.Padding(0);
            this.btnSizeController.Name = "btnSizeController";
            this.btnSizeController.Size = new System.Drawing.Size(34, 35);
            this.btnSizeController.TabIndex = 16;
            this.btnSizeController.TabStop = false;
            this.btnSizeController.Text = "-";
            this.btnSizeController.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSizeController.UseVisualStyleBackColor = true;
            this.btnSizeController.MouseEnter += new System.EventHandler(this.btnSizeController_MouseEnter);
            // 
            // FormARBreak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(383, 384);
            this.Controls.Add(this.btnSizeController);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.flMain);
            this.Controls.Add(this.lblStatus);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormARBreak";
            this.Text = "ARBreak";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnQuit_Clicked);
            this.Load += new System.EventHandler(this.FormARBreak_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numBreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWork)).EndInit();
            this.flButtons.ResumeLayout(false);
            this.flInput.ResumeLayout(false);
            this.flInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSnooze)).EndInit();
            this.flMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NumericUpDown numBreak;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numWork;
        private System.Windows.Forms.Button btnSnooze;
        private System.Windows.Forms.FlowLayoutPanel flButtons;
        private System.Windows.Forms.FlowLayoutPanel flInput;
        private System.Windows.Forms.Label lblSnoozeName;
        private System.Windows.Forms.NumericUpDown numSnooze;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flMain;
        private System.Windows.Forms.Button btnSizeController;
    }
}

