
using Canvas.Classes;
using Canvas.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canvas
{
    enum windowUpdateType
    {
        Initial,
        Resize
    }

    enum OptionPaneVisibility
    {
        Shown,
        Hidden,
        TBD,
        Invert
    }

    /*
     * TODO
     * 
     * Cursor outline when drawing (outlines pen area)
     * Double click header to full screen
     * Drag header to move window , yes ?
     * 
     * file pane is closeed by default
     * replace toggle options pane with 'File'
     * 'File' pane takes focus when open
     * file pane options need to be finished
     * 
     * User sign in
     * Splash screen with 'New / open / sign in / recent
     * 
     * ?? SHOULD SIGN IN HAVE ACCOUNT PROTECTION ??
     * Password protection
     * usernames are encrypted with the cody engine
     * data folders names are hidden and only the current user's may be accessed.
     * User data is stored in an encrypted CSV file.
     * 
     * 
     * 
     * 
     * 
     * encryption method VV
     * account username is encrypted with the EncPrivateKey variable as the ROT key
     * the users data is encrypted with the first three consecutive numbers from the usernames's ascii id's.
     * 
     * for this reasion, a username must be checked to have a length of atleast 2
     * 
     * eg:
     * 
     * Gordie
     * 71111114100105101
     * 
     * first check = 711 [ > 255, invalid ]
     * next check, offset read by 1 = 111 [ < 255, valid ]
     * 
     * This would make '111' the user's public key for decrypting thier data, set this to EncPublicKey.
     * this public key gives access to the user's files and is therefore private. It should never be used outside of the accounthandler class.
     * use the setter to change, there will be no getter.
     * any change to the user account which required the public get must be handled in the accounthandler class.
     * No exceptions.
     * 
     * If there happens to be no valid combination OR IF IT ALREADY EXISTS, the user must select a different name.
     * 
     * The exact same algorythmic method [THE EXACT SAME BLOCK OF CODE, NO COPYING AND PASTING!!!] must be used to create and load the user data to ensure compatability
     *  
     * Account names are stored in the user's folder name in the data folder [./Appdata/Users/71111114100105101/]
     * Get the ascii id, then check that the folder exists, else the user does not exist.
     *  
     * The userdata file [./Appdata/Users/71111114100105101/User.dat] can then be decrypted with the user's public decryption key, gathered from the user's name.
     * 
     * 
     * 
     * 
     * 
     * USE INBUILT SETTINGS TO SAVE DATA
     * 
     * Colour pallettes
     * Recently used and favourite brushes [user selects favorites]
     * 
     * debug values
     * colour tab
     * 
     * space to move
     * undo
     * pen mode
     * line pen
     * Fill tools
     * 
     * get speed of pen when mouse down [debug value too]
     * 
     * 'Change when [speed]'
     * ability to select Function to change on 'change with [speed]
     * 
     * Keyboard shortcuts
     * Clear canvas
     * change pen
     * 
     * arrange tab pages
     * empty brush modifyer when not in use
     * 
     * 
     * 
     * Fix the replace on zoom thingy (Get graphics, then replace post zoom?)
     * Checkbox in special to enable zoom
     * 
     * Middle click centers, not resizes
     * Canvas ancors to centre, not corner
     * 
     * Replace ui elements with metro framework
     */


    public partial class Main : MetroFramework.Forms.MetroForm
    {

        #region Instantiators
        public Main()
        {
            InitializeComponent();
            PanelBox.MouseWheel += PanelBox_MouseWheel;
            MenuTabber.MouseWheel += MenuTabber_MouseWheel;
        }


        private void Main_Load(object sender, EventArgs e)
        {
            string title = " - Canvas";
            if (Debugger.IsAttached)
            {
                title += " [Debugging]";

            } else

            this.Text = fileName + title;
            prepareWindow(windowUpdateType.Initial);
            PaintOffsetX = 10;
            PaintOffsetY = MenuTabber.Top + MenuTabber.Height + 10;
            StyleCombo.SelectedIndex = 0;
        }

        private void prepareWindow(windowUpdateType type)
        {
            //Window preperation
            if (type == windowUpdateType.Initial)
            {
                this.Location = new Point(0, 0);
                this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 1);
                
            }
            else


             //Menutabber
             MenuTabber.Width = this.Width;

            //Drawing panel preperation
            UpdateCanvasLocation();
            panelArea.Height = this.Height - 10; //size to ten away from bottom of window
            panelArea.Width = (this.Width - 20) - OptionsPane.Width; //size to ten away from left of window
            PanelBox.Height = panelArea.Height;
            PanelBox.Width = panelArea.Width;
            originscalex = panelArea.Height;
            originscaley = panelArea.Width;

            if (this.Width < this.Height) //prevent overcasting with rectangular monitors with max size
            {
                maxZoomPercent = this.Width - 10;
            }
            else
            {
                maxZoomPercent = this.Height - 10;
            }

            resizePane();

            //OptionsPane
            SetOptionPaneVisible(OptionPaneVisibility.Hidden);
            OptionsPane.Height = this.Height;

            Preview(StyleCombo.SelectedIndex, PreviewBox);
        }

        AccountHandler handler = new AccountHandler();
        public void LogIn(string usertolog)
        {
            handler.LoadUser(usertolog);
            Forms.Splash splash = new Forms.Splash();
            splash.ShowDialog();

            switch (splash.Option)
            {
                case Forms.SplashOption.NewProject:
                    this.Show();
                    break;
                case Forms.SplashOption.LogOut:
                    handler.LogOutUser();
                    LogIn(usertolog);  //resurse if log out did not complete
                 break;
                case Forms.SplashOption.Nothing:
                    Application.Exit(); //Exit if splash screen is closed by user
                    break;
            }
        }

        public void ResetCanvas()
        {
            try
            {
                Directory.Delete(Settings.Default.ApplicationDataLocation, true);
            }
            catch (Exception)
            {
                if (MessageBox.Show("Unable to delete app data folder at '" + Properties.Settings.Default.ApplicationDataLocation + "'. This may be because it doesn't exist or is in use. Reset without deleting?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                Settings.Default.Reset();
                Settings.Default.ApplicationDataLocation = "./";
                Settings.Default.AutoLogIn = false;
                Settings.Default.IsInitialised = false;
                Settings.Default.LastUser = "NoUserException";
                Settings.Default.Save();
            } catch (Exception)
            {
                MessageBox.Show("Windows has encoutered an error with saving the applications settings. This is commonly caused by restoring the application before it is set-up. If this occours whilst the application is set-up, take a copy of the appdata folder, reinstall the application and set it up, then restore the appdata folder.");
            }
            MessageBox.Show("Reset complete!");
        }

        #endregion

        #region File handling
        String fileName = "Canvas1";

        #endregion

        #region Canvas     

        //CanvasSize canvasSize = new CanvasSize();
        private static int zoomPercent = 1;
        private static int minZoomPercent = 1;
        private static int maxZoomPercent = 150;
        private static int originscalex, originscaley;

        Bitmap ImageCache;
        private void PanelBox_MouseWheel(object sender, MouseEventArgs e) //Mouse wheel
        {
            Graphics tempg = panelArea.CreateGraphics();
            ImageCache = new Bitmap(panelArea.Width, panelArea.Height, tempg);
            if (e.Delta < 0)
            {
                zoomPercent++;
            }
            else
            {
                zoomPercent--;
            }

            if (zoomPercent < minZoomPercent)
            {
                zoomPercent = minZoomPercent;
            }

            if (zoomPercent > maxZoomPercent)
            {
                zoomPercent = maxZoomPercent;
            }
            resizePane();
            chacheDrawTimer.Start();
        }

        private void resizePane()
        {
            PanelBox.Height = originscalex / zoomPercent;
            PanelBox.Width = originscaley / zoomPercent;
            panelArea.Height = originscalex / zoomPercent;
            panelArea.Width = originscaley / zoomPercent;
        }

        private void PanelBox_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                zoomPercent = 1;
                resizePane();
                UpdateCanvasLocation();
            }
           
        }

        private static int StartMouseX, StartMouseY;

        private void PanelBox_MouseDown(object sender, MouseEventArgs e)
        {
            StartMouseX = Cursor.Position.X;
            StartMouseY = Cursor.Position.Y;
            Drawing();
        }

        private void UpdateCanvasLocation()
        {
            if (OptionsPane.Visible)
            {
                panelArea.Location = new Point(OptionsPane.Width + 10, MenuTabber.Height + MenuTabber.Top + 10); //position ten pixels away from top and side panels.
            }
            else
            {
                panelArea.Location = new Point(10, MenuTabber.Top + MenuTabber.Height + 10); //position ten pixels away from top and side panels.
            }

        }

  
        #endregion

        #region Window Handling
        private void chkResizewindow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkResizeWindow.Checked)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
        }


        private void Main_SizeChanged(object sender, EventArgs e)
        {
            prepareWindow(windowUpdateType.Resize);
        }

        private void MenuTabber_MouseWheel(object sender, MouseEventArgs e)
        {
   
            if (e.Delta > 0)
            {
                if (MenuTabber.SelectedIndex == 0)
                {
                    return;
                } else
                {
                    MenuTabber.SelectedIndex--;
                }
            }
            else
            {
                    if (MenuTabber.SelectedIndex == MenuTabber.TabCount)
                    {
                        return;
                    }
                    else
                    {
                        MenuTabber.SelectedIndex++;
                    }
            }
            
        }

        private void btnNextStyle_Click(object sender, EventArgs e)
        {
            if (StyleCombo.SelectedIndex < StyleCombo.Items.Count - 1)
            {
                StyleCombo.SelectedIndex++;
            }
        }

        private void BtnPrevStyle_Click(object sender, EventArgs e)
        {
            if (StyleCombo.SelectedIndex > 0)
            {
                StyleCombo.SelectedIndex--;
            }
        }


        public static int BrushModInt1, BrushModInt2, BrushModInt3;
        private void BrushMod1_ValueChanged(object sender, EventArgs e)
        {
            EndValidation(sender,e);
            BrushModInt1 = int.Parse(BrushMod1.Text);
        }

        private void BrushMod2_ValueChanged(object sender, EventArgs e)
        {
            EndValidation(sender, e);
            BrushModInt2 = int.Parse(BrushMod2.Text);
        }

        private void BrushMod3_ValueChanged(object sender, EventArgs e)
        {
            EndValidation(sender, e);
            BrushModInt3 = int.Parse(BrushMod3.Text);
        }

        private void initialiseBrush(int style)

        {
            switch (style)
            {
                case 0:
                    BrushLabel1.Text = "";
                    BrushLabel2 .Text= "";
                    BrushLabel3.Text = "";
                    BrushMod1.Enabled = false;
                    BrushMod2.Enabled = false;
                    BrushMod3.Enabled = false;
                    break;
                case 1:
                    BrushLabel1.Text = "";
                    BrushLabel2.Text = "";
                    BrushLabel3.Text = "";
                    BrushMod1.Enabled = false;
                    BrushMod2.Enabled = false;
                    BrushMod3.Enabled = false;
                    break;
                case 2:
                    BrushMod1.Text = "5";
                    BrushMod2.Text = "2";
                    BrushLabel1.Text = "Spread";
                    BrushLabel2.Text = "Density";
                    BrushLabel3.Text = "";
                    BrushMod1.Enabled = true;
                    BrushMod2.Enabled = true;
                    BrushMod3.Enabled = false;
                    break;

            }
        }

        #endregion

        #region Option Pane
        private static OptionPaneVisibility OPIV = OptionPaneVisibility.TBD;
        private void SetOptionPaneVisible(OptionPaneVisibility Visibility)
        {
            switch (Visibility)
            {
                case OptionPaneVisibility.Hidden:
                    OPIV = OptionPaneVisibility.Hidden;
                    OptionsPane.Visible = false;
                    break;

                case OptionPaneVisibility.TBD:
                    if (this.Width < OptionsPane.Width + 500)
                    {
                        SetOptionPaneVisible(OptionPaneVisibility.Hidden);
                    }
                    else
                    {

                        SetOptionPaneVisible(OptionPaneVisibility.Shown);
                    }
                    break;

                case OptionPaneVisibility.Shown:
                    OPIV = OptionPaneVisibility.Shown;
                    OptionsPane.Visible = true;
                    break;
                case OptionPaneVisibility.Invert:
                    if (OptionsPane.Visible)
                    {
                        SetOptionPaneVisible(OptionPaneVisibility.Hidden);
                    }
                    else
                    {
                        SetOptionPaneVisible(OptionPaneVisibility.Shown);
                    }
                    break;
            }
            UpdateCanvasLocation();
        }

        private void btnToggleOptionPane_Click(object sender, EventArgs e)
        {
            SetOptionPaneVisible(OptionPaneVisibility.Invert);
        }

        #endregion

        #region Header panel
        private void HeaderPanel_DoubleClick(object sender, MouseEventArgs e)
        {
            prepareWindow(windowUpdateType.Initial);
        }

        private static Boolean HeaderMouseDown = false;
        private void HeaderPanel_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void HeaderPanel_MouseUp(object sender, MouseEventArgs e)
        {

        }

        #endregion

        #region Tom's shit
        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void picMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void picIcon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("We might think about sign in at some point.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

     
        private void btnInfo_Click(object sender, EventArgs e)
        {
            panInfo.Location = new Point(panInfo.Location.X, panInfo.Location.Y - panInfo.Height);
            panInfo.Visible = !panInfo.Visible;

            for (int i = 1; i < panInfo.Height; i++)
            {
                panInfo.Location = new Point(panInfo.Location.X, panInfo.Location.Y - panInfo.Height + i);
                Application.DoEvents();
                Thread.Sleep(1);
            }

            if (panInfo.Visible)
            {
                btnInfo.BackColor = Color.FromArgb(235, 110, 0);
            }
            else
            {
                btnInfo.BackColor = Color.FromArgb(225, 128, 0);
            }
        }

        private void btnInfo_MouseDown(object sender, MouseEventArgs e)
        {
            btnInfo.BackColor = Color.FromArgb(235, 110, 0);
        }

        private void btnInfo_MouseUp(object sender, MouseEventArgs e)
        {

            if (panInfo.Visible)
            {
                btnInfo.BackColor = Color.FromArgb(235, 110, 0);
            }
            else
            {
                btnInfo.BackColor = Color.FromArgb(225, 128, 0);
            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnInfo_MouseEnter(object sender, EventArgs e)
        {
            btnInfo.BackColor = Color.FromArgb(224, 160, 96);
        }



        private void btnInfo_MouseLeave(object sender, EventArgs e)
        {

            if (panInfo.Visible)
            {
                btnInfo.BackColor = Color.FromArgb(235, 110, 0);
            }
            else
            {
                btnInfo.BackColor = Color.FromArgb(225, 128, 0);
            }

        }





        #endregion

        #region Drawing

        public static int PaintOffsetX;
        public static int PaintOffsetY;
        private static Boolean Draw = false;

        private void Colour_Picker(object sender, EventArgs e)
        {
            DialogResult = colorDialog.ShowDialog();
            picPrimaryColour.BackColor = colorDialog.Color;

        }

        private void timertick(object sender, EventArgs e)
        {
        }

        private void DebugTimer2_Tick(object sender, EventArgs e)
        {
        }

        private void StyleCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            initialiseBrush(StyleCombo.SelectedIndex);
            Preview(StyleCombo.SelectedIndex, PreviewBox);
        }

        private void Main_PostLoad(object sender, EventArgs e)
        {
            Preview(StyleCombo.SelectedIndex, PreviewBox);
            PostLoadTimer.Stop();
        }

        private void DrawFromCache(object sender, EventArgs e)
        {
            try
            {
                panelArea.CreateGraphics().DrawImage(ImageCache, new Point(0, 0));
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            chacheDrawTimer.Stop();
        }

        public void Preview(int style, PictureBox Output)
        {
            if (!chkEnablePreview.Checked) { return; }
            Output.CreateGraphics().Clear(Output.BackColor);
            for (double i = 1.0; i <= Output.Width - 50; i += 0.1)
            {
                brush.stamp(style, picPrimaryColour.BackColor, Output.CreateGraphics(), ((int)i), (int)(Math.Cos(i) * 10) + 10, int.Parse(BrushSize.Text), int.Parse(BrushSize.Text), false);
                brush.stamp(style, picPrimaryColour.BackColor, Output.CreateGraphics(), ((int)i), Output.Height - 10, int.Parse(BrushSize.Text), int.Parse(BrushSize.Text), false);
            }
            brush.stamp(style, picPrimaryColour.BackColor, Output.CreateGraphics(), Output.Width - 25 - 5, (Output.Height / 2) - 5, 10, 10, false);
        }


    private void btnCanvasClear_Click(object sender, EventArgs e)
        {
            PanelBox.CreateGraphics().Clear(PicPanelColor.BackColor);
        }

        private void PicPanelColor_Click(object sender, EventArgs e)
        {
            DialogResult = colorDialog.ShowDialog();
            PicPanelColor.BackColor = colorDialog.Color;
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            PanelBox.CreateGraphics().Clear(picPrimaryColour.BackColor);
        }

        private void PreviewBox_Click(object sender, EventArgs e)
        {
            Preview(StyleCombo.SelectedIndex, PreviewBox);
        }

        private void picSecondaryColour_Click(object sender, EventArgs e)
        {
            DialogResult = colorDialog.ShowDialog();
            picSecondaryColour.BackColor = colorDialog.Color;
        }


        private void btnSecondary_Click(object sender, EventArgs e)
        {
            PanelBox.CreateGraphics().Clear(picSecondaryColour.BackColor);
        }



        public static CustomBrushes brush = new CustomBrushes();
        virtual public void Drawing() {
            Draw = true;
            while (Draw)
            {
                Draw = false;
                if (Control.MouseButtons == MouseButtons.Left)
                {
                    brush.stamp(StyleCombo.SelectedIndex, picPrimaryColour.BackColor, PanelBox.CreateGraphics(), Cursor.Position.X - this.Left, Cursor.Position.Y - this.Top, int.Parse(BrushSize.Text) / zoomPercent, int.Parse(BrushSize.Text) / zoomPercent, true);

                    Draw = true;
                }

                if (Control.MouseButtons == MouseButtons.Right)
                {
                    brush.stamp(StyleCombo.SelectedIndex, picSecondaryColour.BackColor, PanelBox.CreateGraphics(), Cursor.Position.X - this.Left, Cursor.Position.Y - this.Top, int.Parse(BrushSize.Text) / zoomPercent, int.Parse(BrushSize.Text) / zoomPercent, true);
                    Draw = true;
                }
                Application.DoEvents();

            }
        }

        private void StartValidation(object sender, MouseEventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            SetOptionPaneVisible(OptionPaneVisibility.Hidden);
            LogIn(handler.userName);
        }

    
            private void close(object sender, FormClosedEventArgs e)
            {
                Application.Exit();
            }
        

        internal static void ExceptionEnd()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Validation
        private static string stringToValidate = "Null";
        private void StartValidation(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTextBox validationtext = (MetroFramework.Controls.MetroTextBox)sender;
            stringToValidate = validationtext.Text;
        }

        private void EndValidation(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTextBox validationtext = (MetroFramework.Controls.MetroTextBox)sender;
            try {
                int i = int.Parse(validationtext.Text);
            }
            catch (Exception)
            {
                validationtext.Text = stringToValidate;
            }

            stringToValidate = validationtext.Text;
        }


        #endregion



    }
}
    
