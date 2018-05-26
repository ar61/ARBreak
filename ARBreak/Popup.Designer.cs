namespace ARBreak
{
    public partial class Popup
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.wbRandomImg = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(86, 24);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(238, 31);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Its time for a break";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(138, 306);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(127, 44);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Ok";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // wbRandomImg
            // 
            this.wbRandomImg.CausesValidation = false;
            this.wbRandomImg.Location = new System.Drawing.Point(47, 76);
            this.wbRandomImg.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbRandomImg.Name = "wbRandomImg";
            this.wbRandomImg.ScrollBarsEnabled = false;
            this.wbRandomImg.Size = new System.Drawing.Size(313, 213);
            this.wbRandomImg.TabIndex = 2;
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(401, 364);
            this.Controls.Add(this.wbRandomImg);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblMessage);
            this.Name = "Popup";
            this.Text = "Popup";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnConfirm;
        public System.Windows.Forms.WebBrowser wbRandomImg;
    }
}
