namespace Canvas.Forms
{
    partial class LogIn
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
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.txtpass = new MetroFramework.Controls.MetroTextBox();
            this.TGAuto = new MetroFramework.Controls.MetroToggle();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.txtusr = new MetroFramework.Controls.MetroTextBox();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(196, 127);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(19, 19);
            this.metroButton2.TabIndex = 6;
            this.metroButton2.Text = "?";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.autohelp);
            // 
            // txtpass
            // 
            // 
            // 
            // 
            this.txtpass.CustomButton.Image = null;
            this.txtpass.CustomButton.Location = new System.Drawing.Point(65, 1);
            this.txtpass.CustomButton.Name = "";
            this.txtpass.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtpass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtpass.CustomButton.TabIndex = 1;
            this.txtpass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtpass.CustomButton.UseSelectable = true;
            this.txtpass.CustomButton.Visible = false;
            this.txtpass.Lines = new string[0];
            this.txtpass.Location = new System.Drawing.Point(110, 84);
            this.txtpass.MaxLength = 32767;
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '•';
            this.txtpass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtpass.SelectedText = "";
            this.txtpass.SelectionLength = 0;
            this.txtpass.SelectionStart = 0;
            this.txtpass.ShortcutsEnabled = true;
            this.txtpass.Size = new System.Drawing.Size(87, 23);
            this.txtpass.TabIndex = 2;
            this.txtpass.UseSelectable = true;
            this.txtpass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtpass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TGAuto
            // 
            this.TGAuto.AutoSize = true;
            this.TGAuto.Location = new System.Drawing.Point(110, 128);
            this.TGAuto.Name = "TGAuto";
            this.TGAuto.Size = new System.Drawing.Size(80, 17);
            this.TGAuto.TabIndex = 3;
            this.TGAuto.Text = "Off";
            this.TGAuto.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 127);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(73, 19);
            this.metroLabel3.TabIndex = 19;
            this.metroLabel3.Text = "Auto LogIn";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 86);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(63, 19);
            this.metroLabel2.TabIndex = 18;
            this.metroLabel2.Text = "Password";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(68, 19);
            this.metroLabel1.TabIndex = 17;
            this.metroLabel1.Text = "Username";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(23, 164);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(174, 23);
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "Log In";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // txtusr
            // 
            // 
            // 
            // 
            this.txtusr.CustomButton.Image = null;
            this.txtusr.CustomButton.Location = new System.Drawing.Point(65, 1);
            this.txtusr.CustomButton.Name = "";
            this.txtusr.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtusr.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtusr.CustomButton.TabIndex = 1;
            this.txtusr.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtusr.CustomButton.UseSelectable = true;
            this.txtusr.CustomButton.Visible = false;
            this.txtusr.Lines = new string[0];
            this.txtusr.Location = new System.Drawing.Point(110, 58);
            this.txtusr.MaxLength = 32767;
            this.txtusr.Name = "txtusr";
            this.txtusr.PasswordChar = '\0';
            this.txtusr.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtusr.SelectedText = "";
            this.txtusr.SelectionLength = 0;
            this.txtusr.SelectionStart = 0;
            this.txtusr.ShortcutsEnabled = true;
            this.txtusr.Size = new System.Drawing.Size(87, 23);
            this.txtusr.TabIndex = 1;
            this.txtusr.UseSelectable = true;
            this.txtusr.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtusr.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(23, 193);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(174, 23);
            this.metroButton3.TabIndex = 5;
            this.metroButton3.Text = "Create a new user";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 227);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.TGAuto);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txtusr);
            this.Name = "LogIn";
            this.Resizable = false;
            this.Text = "LogIn";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroTextBox txtpass;
        private MetroFramework.Controls.MetroToggle TGAuto;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox txtusr;
        private MetroFramework.Controls.MetroButton metroButton3;
    }
}