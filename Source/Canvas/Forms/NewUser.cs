using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canvas.Forms
{
    public partial class NewUser : MetroFramework.Forms.MetroForm
    {
        public NewUser()
        {
            InitializeComponent();
        }

        Classes.AccountHandler handler = new Classes.AccountHandler();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Check for blanks
            if (txtusr.Text.Equals("")) { return; }
            if (txtusr.Text.Equals(" ")) { return; }

            if (txtusr.Text.Length < 4) { return; } //not long enough


            //Check username can be used
            if (!handler.ValidateUser(txtusr.Text))
            {
                MessageBox.Show("For security reasions, that name cannot be used. Please choose another.");
                this.Show();
                return;
            }

            string userascii = handler.EncryptUserName(txtusr.Text);
             Directory.CreateDirectory(Properties.Settings.Default.ApplicationDataLocation + "Users/" + userascii + "/");

            //create password, if needed
            if (!txtpass.Text.Equals(""))
            {
                System.IO.File.Create(Properties.Settings.Default.ApplicationDataLocation + "Users/" + userascii + "/User.dat").Dispose();
                System.IO.File.WriteAllText(Properties.Settings.Default.ApplicationDataLocation + "Users/" + userascii + "/User.dat", handler.UserEncrypt(txtusr.Text, txtpass.Text));

            }

        
 
            Properties.Settings.Default.AutoLogIn = TGAuto.Checked;
            Properties.Settings.Default.LastUser = txtusr.Text;
            Properties.Settings.Default.Save();

            txtpass.Text = "";
            txtusr.Text = "";
            TGAuto.Checked = false;
            return;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            AutoLogIn logindialog = new AutoLogIn();
            logindialog.ShowDialog();
        }
    }
}
