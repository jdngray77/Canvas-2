using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canvas.Forms
{
    public enum SplashOption{
        NewProject,
        LoadProject,
        LogOut,
        ChangePassword,
        DeleteUser,
        CanvasSettings,
        Nothing
    }

    public partial class Splash : MetroFramework.Forms.MetroForm
    {

        public SplashOption Option = SplashOption.Nothing;

        public Splash()
        {
            InitializeComponent();
        }

        private void TileNewProject_Click(object sender, EventArgs e)
        {
            Option = SplashOption.NewProject;
            this.Close();
        }

        private void TileLogOut_click(object sender, EventArgs e)
        {
            Option = SplashOption.LogOut;
            this.Close();
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            Option = SplashOption.CanvasSettings;
            this.Close();
        }

        private void close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            Option = SplashOption.LoadProject;
            this.Close();
        }

        private void splash_shown(object sender, EventArgs e)
        {
            Option = SplashOption.Nothing;
        }
    }
}
