namespace Canvas.Forms
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.TileNewProject = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.TileLogOut = new MetroFramework.Controls.MetroTile();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.metroTile5 = new MetroFramework.Controls.MetroTile();
            this.metroTile6 = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // TileNewProject
            // 
            this.TileNewProject.ActiveControl = null;
            this.TileNewProject.Location = new System.Drawing.Point(24, 63);
            this.TileNewProject.Name = "TileNewProject";
            this.TileNewProject.Size = new System.Drawing.Size(259, 237);
            this.TileNewProject.TabIndex = 0;
            this.TileNewProject.Text = "New project";
            this.TileNewProject.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TileNewProject.TileImage = global::Canvas.Properties.Resources.NewProject;
            this.TileNewProject.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.TileNewProject.UseCustomForeColor = true;
            this.TileNewProject.UseSelectable = true;
            this.TileNewProject.UseStyleColors = true;
            this.TileNewProject.UseTileImage = true;
            this.TileNewProject.Click += new System.EventHandler(this.TileNewProject_Click);
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(291, 63);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(259, 237);
            this.metroTile2.TabIndex = 1;
            this.metroTile2.Text = "Load project";
            this.metroTile2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTile2.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile2.TileImage")));
            this.metroTile2.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile2.UseCustomForeColor = true;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.UseTileImage = true;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // TileLogOut
            // 
            this.TileLogOut.ActiveControl = null;
            this.TileLogOut.Location = new System.Drawing.Point(23, 306);
            this.TileLogOut.Name = "TileLogOut";
            this.TileLogOut.Size = new System.Drawing.Size(125, 105);
            this.TileLogOut.TabIndex = 2;
            this.TileLogOut.Text = "Log out";
            this.TileLogOut.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TileLogOut.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TileLogOut.UseSelectable = true;
            this.TileLogOut.UseTileImage = true;
            this.TileLogOut.Click += new System.EventHandler(this.TileLogOut_click);
            // 
            // metroTile4
            // 
            this.metroTile4.ActiveControl = null;
            this.metroTile4.Location = new System.Drawing.Point(158, 306);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(125, 105);
            this.metroTile4.TabIndex = 3;
            this.metroTile4.Text = "Change password";
            this.metroTile4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTile4.UseSelectable = true;
            this.metroTile4.UseTileImage = true;
            // 
            // metroTile5
            // 
            this.metroTile5.ActiveControl = null;
            this.metroTile5.Location = new System.Drawing.Point(291, 306);
            this.metroTile5.Name = "metroTile5";
            this.metroTile5.Size = new System.Drawing.Size(125, 105);
            this.metroTile5.TabIndex = 4;
            this.metroTile5.Text = "Delete user";
            this.metroTile5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTile5.UseSelectable = true;
            this.metroTile5.UseTileImage = true;
            // 
            // metroTile6
            // 
            this.metroTile6.ActiveControl = null;
            this.metroTile6.Location = new System.Drawing.Point(425, 306);
            this.metroTile6.Name = "metroTile6";
            this.metroTile6.Size = new System.Drawing.Size(125, 105);
            this.metroTile6.TabIndex = 5;
            this.metroTile6.Text = "Canvas settings";
            this.metroTile6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTile6.UseSelectable = true;
            this.metroTile6.UseTileImage = true;
            this.metroTile6.Click += new System.EventHandler(this.metroTile6_Click);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 442);
            this.Controls.Add(this.metroTile6);
            this.Controls.Add(this.metroTile5);
            this.Controls.Add(this.metroTile4);
            this.Controls.Add(this.TileLogOut);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.TileNewProject);
            this.Name = "Splash";
            this.Resizable = false;
            this.Text = "Welcome!";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.splash_shown);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile TileNewProject;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile TileLogOut;
        private MetroFramework.Controls.MetroTile metroTile4;
        private MetroFramework.Controls.MetroTile metroTile5;
        private MetroFramework.Controls.MetroTile metroTile6;
    }
}