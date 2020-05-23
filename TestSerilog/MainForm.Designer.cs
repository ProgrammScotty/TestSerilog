namespace TestSerilog
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Save = new System.Windows.Forms.Button();
            this.tbx_Vorname = new System.Windows.Forms.TextBox();
            this.tbx_Nachname = new System.Windows.Forms.TextBox();
            this.tbx_Alter = new System.Windows.Forms.TextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.tbx_Email = new System.Windows.Forms.TextBox();
            this.btn_Crash = new System.Windows.Forms.Button();
            this.tbx_LogMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(44, 161);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Speichern";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // tbx_Vorname
            // 
            this.tbx_Vorname.Location = new System.Drawing.Point(31, 12);
            this.tbx_Vorname.Name = "tbx_Vorname";
            this.tbx_Vorname.Size = new System.Drawing.Size(100, 20);
            this.tbx_Vorname.TabIndex = 1;
            // 
            // tbx_Nachname
            // 
            this.tbx_Nachname.Location = new System.Drawing.Point(31, 40);
            this.tbx_Nachname.Name = "tbx_Nachname";
            this.tbx_Nachname.Size = new System.Drawing.Size(100, 20);
            this.tbx_Nachname.TabIndex = 2;
            // 
            // tbx_Alter
            // 
            this.tbx_Alter.Location = new System.Drawing.Point(31, 68);
            this.tbx_Alter.Name = "tbx_Alter";
            this.tbx_Alter.Size = new System.Drawing.Size(100, 20);
            this.tbx_Alter.TabIndex = 3;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(44, 196);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "Beenden";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // tbx_Email
            // 
            this.tbx_Email.Location = new System.Drawing.Point(31, 96);
            this.tbx_Email.Name = "tbx_Email";
            this.tbx_Email.Size = new System.Drawing.Size(100, 20);
            this.tbx_Email.TabIndex = 5;
            // 
            // btn_Crash
            // 
            this.btn_Crash.Location = new System.Drawing.Point(44, 132);
            this.btn_Crash.Name = "btn_Crash";
            this.btn_Crash.Size = new System.Drawing.Size(75, 23);
            this.btn_Crash.TabIndex = 6;
            this.btn_Crash.Text = "Exception";
            this.btn_Crash.UseVisualStyleBackColor = true;
            this.btn_Crash.Click += new System.EventHandler(this.btn_Crash_Click);
            // 
            // tbx_LogMessage
            // 
            this.tbx_LogMessage.Location = new System.Drawing.Point(31, 225);
            this.tbx_LogMessage.Multiline = true;
            this.tbx_LogMessage.Name = "tbx_LogMessage";
            this.tbx_LogMessage.Size = new System.Drawing.Size(312, 43);
            this.tbx_LogMessage.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 280);
            this.ControlBox = false;
            this.Controls.Add(this.tbx_LogMessage);
            this.Controls.Add(this.btn_Crash);
            this.Controls.Add(this.tbx_Email);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.tbx_Alter);
            this.Controls.Add(this.tbx_Nachname);
            this.Controls.Add(this.tbx_Vorname);
            this.Controls.Add(this.btn_Save);
            this.Name = "MainForm";
            this.Text = "Test Serilog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox tbx_Vorname;
        private System.Windows.Forms.TextBox tbx_Nachname;
        private System.Windows.Forms.TextBox tbx_Alter;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.TextBox tbx_Email;
        private System.Windows.Forms.Button btn_Crash;
        private System.Windows.Forms.TextBox tbx_LogMessage;
    }
}

