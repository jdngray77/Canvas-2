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
    public partial class Details : MetroFramework.Forms.MetroForm
    {
        public Details()
        {
            InitializeComponent();
        }

        public void ShowDetails(string filepath)
        {
            var files = new FileInfo(filepath);
            Image image = Image.FromFile(files.ToString());
            lblResolution.Text = image.Size.Width + " X " + image.Size.Height;
            lblSize.Text = files.Length / 1000 + "Kb";
            lblModified.Text = files.LastWriteTime.ToLongDateString() + " " + files.LastWriteTime.ToLongTimeString();
            lblAccessed.Text = files.LastAccessTime.ToLongDateString() + " " + files.LastAccessTime.ToLongTimeString();
            lblCreated.Text = files.CreationTime.ToLongDateString() + " " + files.CreationTime.ToLongTimeString();
            lblExtention.Text = files.Extension;

            this.ShowDialog();
        }
    }
}
