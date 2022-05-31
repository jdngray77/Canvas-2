using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canvas.Forms
{
    public partial class Load : MetroFramework.Forms.MetroForm
    {
        public Load()
        {
            InitializeComponent();
        }

        
        Classes.AccountHandler handler = new Classes.AccountHandler();
        public void LoadFile(string username)
        {
            handler.LogInUser(username);
            //assume user exists and is logged in
            Recent1.Enabled = false;
            string location = Properties.Settings.Default.ApplicationDataLocation + "Users/" + handler.EncryptUserName(username) + "/Media/";

            if (!System.IO.Directory.Exists(location)) //check if media folder exists
            {
                System.IO.Directory.CreateDirectory(location); //if not create it
            } else
            { //if it does, check it

            var directory = new DirectoryInfo(location); //set the location to a directory variable

                //Setup the recent file
                try
                {
                    var files = directory.GetFiles("*.*").Where(file => new string[] { ".jpg", ".gif", ".png", ".Jpeg" }.Contains(Path.GetExtension(file.ToString()))).OrderByDescending(f => f.LastWriteTime).First(); //get the files from the media folder in order of last write time (Most recent)
                    
                    Recent1.Tag = location + files.ToString(); 
                    Recent1.Text = files.Name;
                    Recent1.Enabled = true;

                    Image image = Image.FromFile(location + files.ToString());
                    lblResolution.Text = image.Size.Width + " X " + image.Size.Height;
                    lblSize.Text = files.Length / 1000 + "Kb";
                    lblModified.Text = files.LastWriteTime.ToLongDateString() + " " + files.LastWriteTime.ToLongTimeString();
                    lblAccessed.Text = files.LastAccessTime.ToLongDateString() + " " + files.LastAccessTime.ToLongTimeString();
                    lblCreated.Text = files.CreationTime.ToLongDateString() + " " + files.CreationTime.ToLongTimeString();
                    lblExtention.Text = files.Extension;

                    preview(location + files.ToString());
                } catch (System.InvalidOperationException)
               {
                    //Likely no image files to be loaded.
               }

                //populate box with all images from /media
                populateProjects();




                this.ShowDialog();
            }



        }

        private void populateProjects()
        {
            string location = Properties.Settings.Default.ApplicationDataLocation + "Users/" + handler.EncryptUserName(handler.userName) + "/Media/";

            var directory = new DirectoryInfo(location); //set the location to a directory variable

            cmbProjects.Items.Clear();
            cmbProjects.Items.AddRange(directory.GetFiles("*.*").Where(file => new string[] { ".jpg", ".gif", ".png", ".Jpeg" }.Contains(Path.GetExtension(file.ToString()))).ToArray()); //get the files from the media folder in order of last write time (Most recent)
        }

        public string fileName = "";
        private void preview(string filepath)
        {
            Image image = Image.FromFile(filepath);
            PreviewBox.Tag = filepath;
            PreviewBox.Image = image;
            PreviewBox.Refresh();
            FileInfo files = new FileInfo(filepath);
            fileName = files.Name;
            lblfilename.Text = files.Name;
            lblFileSize.Text = files.Length / 1000 + "Kb";
        }

        private void FileDropped(object sender, DragEventArgs e)
        {
            System.Diagnostics.Debugger.Break();
        }

        private void Recent1_Click(object sender, EventArgs e)
        {
            preview(Recent1.Tag.ToString());
        }

        private void lblOpenInExplorer_Click(object sender, EventArgs e)
        {
            Process.Start(PreviewBox.Tag.ToString());
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            Forms.Details details = new Forms.Details();
            details.ShowDetails(PreviewBox.Tag.ToString());
        }

        private void cmbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            string location = Properties.Settings.Default.ApplicationDataLocation + "Users/" + handler.EncryptUserName(handler.userName) + "/Media/";
            preview(location + cmbProjects.SelectedItem.ToString());
        }

        private Boolean Validate(string filePath)
        {
            if (filePath.Contains("AppData"))
            {
                if (!filePath.Contains(handler.EncryptUserName(handler.userName)))
                {
                    MessageBox.Show("You are not permitted to load other user's projects.");
                    return false;
                }
                MessageBox.Show("You may not load projects from /appdata/. To load a project from your user, select it below.");
                return false;
            }
            return true;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C://";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    
                    //Get the path of specified file
                    
                    filePath = openFileDialog.FileName;

                    //security check
                    if (!Validate(filePath))
                    {
                        return;
                    }

                    try
                    {
                        FileInfo file = new FileInfo(filePath);

                        bool valid = false;
                        if (file.Extension != ".Jpeg") { valid = true; }
                        if (file.Extension != ".Jpg") { valid = true; }
                        if (file.Extension != ".png") { valid = true; }

                        if (!valid) { return; }

                        preview(filePath);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                } else
                {
                    return;
                }
            }


        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C://";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //security check
                    if (!Validate(filePath))
                    {
                        return;
                    }


                    try
                    {
                        FileInfo file = new FileInfo(filePath);

                        bool valid = false;
                        if (file.Extension != ".Jpeg") { valid = true; }
                        if (file.Extension != ".Jpg") { valid = true; }
                        if (file.Extension != ".png") { valid = true; }

                        if (!valid) { return; }


                         Bitmap bmp = new Bitmap(filePath);
                        bmp.Save(Properties.Settings.Default.ApplicationDataLocation + "Users/" + handler.EncryptUserName(handler.userName) + "/Media/" + file.Name, ImageFormat.Jpeg);
                        preview(Properties.Settings.Default.ApplicationDataLocation + "Users/" + handler.EncryptUserName(handler.userName) + "/Media/" + file.Name);

                        populateProjects();

                       

                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }



            
        }



        public string filepath = "";
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (PreviewBox.Tag == null) { return; }
            if (PreviewBox.Tag.ToString() == "") { return; }


            filepath = PreviewBox.Tag.ToString();
            this.Close();
        }
    }
}
