namespace Canvas.Forms
{
    partial class Load
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
            this.Recent1 = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.cmbProjects = new MetroFramework.Controls.MetroComboBox();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.lblfilename = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.lblFileSize = new MetroFramework.Controls.MetroLabel();
            this.lblOpenInExplorer = new MetroFramework.Controls.MetroLink();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.PreviewBox = new System.Windows.Forms.PictureBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.lblResolution = new MetroFramework.Controls.MetroLabel();
            this.lblSize = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.lblModified = new MetroFramework.Controls.MetroLabel();
            this.lblAccessed = new MetroFramework.Controls.MetroLabel();
            this.lblCreated = new MetroFramework.Controls.MetroLabel();
            this.lblExtention = new MetroFramework.Controls.MetroLabel();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Recent1
            // 
            this.Recent1.ActiveControl = null;
            this.Recent1.Location = new System.Drawing.Point(23, 102);
            this.Recent1.Name = "Recent1";
            this.Recent1.Size = new System.Drawing.Size(200, 54);
            this.Recent1.TabIndex = 1;
            this.Recent1.UseSelectable = true;
            this.Recent1.UseTileImage = true;
            this.Recent1.Click += new System.EventHandler(this.Recent1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 80);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(154, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Your most recent project";
            this.metroToolTip1.SetToolTip(this.metroLabel1, "v");
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(24, 322);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(120, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "All of your projects";
            // 
            // cmbProjects
            // 
            this.cmbProjects.BackColor = System.Drawing.Color.White;
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.ItemHeight = 23;
            this.cmbProjects.Location = new System.Drawing.Point(24, 344);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(199, 29);
            this.cmbProjects.TabIndex = 6;
            this.cmbProjects.UseSelectable = true;
            this.cmbProjects.SelectedIndexChanged += new System.EventHandler(this.cmbProjects_SelectedIndexChanged);
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(24, 412);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(92, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Load from file";
            this.metroToolTip1.SetToolTip(this.metroLabel3, "v");
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(280, 78);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(145, 19);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "Preview of selected file:";
            this.metroToolTip1.SetToolTip(this.metroLabel4, "v");
            // 
            // lblfilename
            // 
            this.lblfilename.AutoSize = true;
            this.lblfilename.Location = new System.Drawing.Point(359, 688);
            this.lblfilename.Name = "lblfilename";
            this.lblfilename.Size = new System.Drawing.Size(0, 0);
            this.lblfilename.TabIndex = 20;
            this.metroToolTip1.SetToolTip(this.lblfilename, "v");
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(280, 688);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(69, 19);
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "File name:";
            this.metroToolTip1.SetToolTip(this.metroLabel5, "v");
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(280, 711);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(57, 19);
            this.metroLabel6.TabIndex = 12;
            this.metroLabel6.Text = "File size:";
            this.metroToolTip1.SetToolTip(this.metroLabel6, "v");
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(359, 711);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(31, 19);
            this.lblFileSize.TabIndex = 21;
            this.lblFileSize.Text = "0Kb";
            this.metroToolTip1.SetToolTip(this.lblFileSize, "v");
            // 
            // lblOpenInExplorer
            // 
            this.lblOpenInExplorer.Location = new System.Drawing.Point(916, 682);
            this.lblOpenInExplorer.Name = "lblOpenInExplorer";
            this.lblOpenInExplorer.Size = new System.Drawing.Size(104, 23);
            this.lblOpenInExplorer.TabIndex = 8;
            this.lblOpenInExplorer.Text = "Open externally";
            this.lblOpenInExplorer.UseSelectable = true;
            this.lblOpenInExplorer.Click += new System.EventHandler(this.lblOpenInExplorer_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(916, 711);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(104, 23);
            this.metroButton1.TabIndex = 11;
            this.metroButton1.Text = "Load project";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // PreviewBox
            // 
            this.PreviewBox.Location = new System.Drawing.Point(280, 101);
            this.PreviewBox.Name = "PreviewBox";
            this.PreviewBox.Size = new System.Drawing.Size(740, 575);
            this.PreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PreviewBox.TabIndex = 15;
            this.PreviewBox.TabStop = false;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(23, 159);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(80, 19);
            this.metroLabel7.TabIndex = 16;
            this.metroLabel7.Text = "Canvas Size:";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(23, 178);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(59, 19);
            this.metroLabel8.TabIndex = 17;
            this.metroLabel8.Text = "File Size:";
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = true;
            this.lblResolution.Location = new System.Drawing.Point(128, 159);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(37, 19);
            this.lblResolution.TabIndex = 18;
            this.lblResolution.Text = "_ X _";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(128, 178);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(29, 19);
            this.lblSize.TabIndex = 19;
            this.lblSize.Text = "Mb";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(23, 197);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(91, 19);
            this.metroLabel9.TabIndex = 22;
            this.metroLabel9.Text = "Last modified:";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(23, 216);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(89, 19);
            this.metroLabel10.TabIndex = 23;
            this.metroLabel10.Text = "Last accessed:";
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(24, 254);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(65, 19);
            this.metroLabel11.TabIndex = 24;
            this.metroLabel11.Text = "Extention:";
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(24, 235);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(59, 19);
            this.metroLabel12.TabIndex = 25;
            this.metroLabel12.Text = "Created:";
            // 
            // lblModified
            // 
            this.lblModified.AutoSize = true;
            this.lblModified.Location = new System.Drawing.Point(128, 197);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(33, 19);
            this.lblModified.TabIndex = 26;
            this.lblModified.Text = "      ";
            // 
            // lblAccessed
            // 
            this.lblAccessed.AutoSize = true;
            this.lblAccessed.Location = new System.Drawing.Point(128, 216);
            this.lblAccessed.Name = "lblAccessed";
            this.lblAccessed.Size = new System.Drawing.Size(33, 19);
            this.lblAccessed.TabIndex = 27;
            this.lblAccessed.Text = "      ";
            // 
            // lblCreated
            // 
            this.lblCreated.AutoSize = true;
            this.lblCreated.Location = new System.Drawing.Point(128, 235);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(33, 19);
            this.lblCreated.TabIndex = 28;
            this.lblCreated.Text = "      ";
            // 
            // lblExtention
            // 
            this.lblExtention.AutoSize = true;
            this.lblExtention.Location = new System.Drawing.Point(128, 254);
            this.lblExtention.Name = "lblExtention";
            this.lblExtention.Size = new System.Drawing.Size(33, 19);
            this.lblExtention.TabIndex = 29;
            this.lblExtention.Text = "      ";
            // 
            // metroLink1
            // 
            this.metroLink1.Location = new System.Drawing.Point(276, 729);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(126, 23);
            this.metroLink1.TabIndex = 30;
            this.metroLink1.Text = "Show more details";
            this.metroLink1.UseSelectable = true;
            this.metroLink1.Click += new System.EventHandler(this.metroLink1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(23, 445);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(200, 32);
            this.metroButton2.TabIndex = 31;
            this.metroButton2.Text = "Open image from file";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(23, 483);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(200, 32);
            this.metroButton3.TabIndex = 32;
            this.metroButton3.Text = "Import to project from file";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // Load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 759);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroLink1);
            this.Controls.Add(this.lblExtention);
            this.Controls.Add(this.lblCreated);
            this.Controls.Add(this.lblAccessed);
            this.Controls.Add(this.lblModified);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.lblfilename);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblResolution);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.PreviewBox);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.lblOpenInExplorer);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.cmbProjects);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.Recent1);
            this.Name = "Load";
            this.Resizable = false;
            this.Text = "Load project";
            ((System.ComponentModel.ISupportInitialize)(this.PreviewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile Recent1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox cmbProjects;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLink lblOpenInExplorer;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.PictureBox PreviewBox;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel lblResolution;
        private MetroFramework.Controls.MetroLabel lblSize;
        private MetroFramework.Controls.MetroLabel lblfilename;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel lblModified;
        private MetroFramework.Controls.MetroLabel lblAccessed;
        private MetroFramework.Controls.MetroLabel lblCreated;
        private MetroFramework.Controls.MetroLabel lblExtention;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel lblFileSize;
        private MetroFramework.Controls.MetroLink metroLink1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
    }
}