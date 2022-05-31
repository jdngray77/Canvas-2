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
    public partial class LogIn : MetroFramework.Forms.MetroForm
    {
        public string username = "";
        public LogIn()
        {
            InitializeComponent();
        }


        Classes.AccountHandler handler = new Classes.AccountHandler();
        Main main = new Main();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (txtusr.Text.Equals("")) { return; }
            if (txtusr.Text.Equals(" ")) { return; } //Blank is not valid

            if (txtusr.Text.Length < 4) { return; } //not long enough


            string EncUser = handler.EncryptUserName(txtusr.Text);

            if (!System.IO.Directory.Exists(Properties.Settings.Default.ApplicationDataLocation + "Users/" + EncUser))
            {
                MessageBox.Show("No user exists with that name!");
                return;
                //user does not exist
            }

            if (System.IO.File.Exists((Properties.Settings.Default.ApplicationDataLocation + "Users/" + EncUser + "/User.Dat")))
            {
                //User has password
                if (handler.ValidatePasswordCorrect(txtpass.Text, txtusr.Text))
                {
                    this.Hide();
                    main.LogIn(txtusr.Text);
                }
            } else
            {
                this.Hide();
                main.LogIn(txtusr.Text);
            }

            if (TGAuto.Checked)
            {
                Properties.Settings.Default.AutoLogIn = TGAuto.Checked;
                Properties.Settings.Default.LastUser = txtusr.Text;
                Properties.Settings.Default.Save();
            }





        }

 
        NewUser newuser = new NewUser();
        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            newuser.ShowDialog();
            this.Show();
        }

        private void autohelp(object sender, EventArgs e)
        {
            AutoLogIn login = new AutoLogIn();
            this.Hide();
            login.ShowDialog();
            this.Show();
        }

        private void close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void click(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
