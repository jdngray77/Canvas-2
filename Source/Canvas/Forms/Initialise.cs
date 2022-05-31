﻿using Canvas.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canvas.Forms
{
    public partial class Initialise : MetroFramework.Forms.MetroForm
    {
        public Initialise()
        {
            InitializeComponent();
        }

        Main main = new Main();
        private void Load(object sender, EventArgs e)
        {
            LogIn log = new LogIn();

            timer1.Stop();

            //was last close a crash?
            if (Properties.Settings.Default.CrashOnClose)
            {
                if (Properties.Settings.Default.AutoLogIn)
                {
                    if (MessageBox.Show("Canvas crashed the last time it closed. Would you like to log in and reload the last project? A backup copy has been made in ./appdata/crashHandler/backup.Jpeg", "Re load project?", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        Properties.Settings.Default.CrashOnClose = false;
                    }
                } else
                {
                    MessageBox.Show("Canvas crashed the last time it closed, but auto log in is not enabled. For security reason, you will have to reload the project yourself. A backup copy has been made in ./appdata/crashHandler/backup.Jpeg");
                }
            }


            //Is a debugger attached?
            if (Debugger.IsAttached && Properties.Settings.Default.IsInitialised)
            {
                if (MessageBox.Show("A debugger is attached, would you like to reset canvas to default?", "Debugger attached", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    main.ResetCanvas();
                }
            }

            //If first time use
            if (!Properties.Settings.Default.IsInitialised)
            {
                //Program is not initialised, has the directory already been set?
                if (Properties.Settings.Default.ApplicationDataLocation == "./")
                {
                    //Treat as not set, assume doesn't exist

                    MessageBox.Show("For first time use, select a folder for Canvas to use.");

                    //Get location from user, and create appdata foler
                    FolderBrowserDialog location = new FolderBrowserDialog();
                    location.ShowDialog();
                    string path = location.SelectedPath;
                    path += "/AppData/";
                    Directory.CreateDirectory(path + "/Users/");


                    //Save Path
                    Properties.Settings.Default.ApplicationDataLocation = path;
                    Properties.Settings.Default.Save();
                }

                //Make first user
                NewUser usr = new NewUser();
                usr.ShowDialog();

                Properties.Settings.Default.IsInitialised = true;
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.AutoLogIn)//should we auto log in?
            {
                if (!Properties.Settings.Default.LastUser.Equals("CauseNoUserException"))
                {
                    this.Hide();
                    if (Properties.Settings.Default.CrashOnClose == true)
                    {
                        main.recover();
                    } else
                    { 
                        main.LogIn(Properties.Settings.Default.LastUser);
                    }


                    
                    return;
                }
            }


            //else display login screen
             this.Hide();
            log.ShowDialog();
            return;
        }

        private void keydown(object sender, KeyEventArgs e)
        {
            timer1.Stop();
            if (MessageBox.Show("Reset canvas to factory settings?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("This will format all user's, user data and inprogress projects! Are you sure?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    main.ResetCanvas();
                }
            }


            timer1.Start();
            return;

        }
    }
}
