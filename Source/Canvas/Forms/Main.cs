

using Canvas.Classes;
using Canvas.Properties;
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


    #region vitrifiedMethods

    //private void picExit_Click(object sender, EventArgs e)
    //{
    //    Application.Exit();
    //}


    //private void picMinimize_Click(object sender, EventArgs e)
    //{
    //    WindowState = FormWindowState.Minimized;
    //}

    //private void picIcon_Click(object sender, EventArgs e)
    //{
    //    MessageBox.Show("We might think about sign in at some point.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //}


    //private void btnInfo_Click(object sender, EventArgs e)
    //{
    //    panInfo.Location = new Point(panInfo.Location.X, panInfo.Location.Y - panInfo.Height);
    //    panInfo.Visible = !panInfo.Visible;

    //    for (int i = 1; i < panInfo.Height; i++)
    //    {
    //        panInfo.Location = new Point(panInfo.Location.X, panInfo.Location.Y - panInfo.Height + i);
    //        Application.DoEvents();
    //        Thread.Sleep(1);
    //    }

    //    if (panInfo.Visible)
    //    {
    //        btnInfo.BackColor = Color.FromArgb(235, 110, 0);
    //    }
    //    else
    //    {
    //        btnInfo.BackColor = Color.FromArgb(225, 128, 0);
    //    }
    //}

    //private void btnInfo_MouseDown(object sender, MouseEventArgs e)
    //{
    //    btnInfo.BackColor = Color.FromArgb(235, 110, 0);
    //}

    //private void btnInfo_MouseUp(object sender, MouseEventArgs e)
    //{

    //    if (panInfo.Visible)
    //    {
    //        btnInfo.BackColor = Color.FromArgb(235, 110, 0);
    //    }
    //    else
    //    {
    //        btnInfo.BackColor = Color.FromArgb(225, 128, 0);
    //    }

    //}

    //private void btnInfo_MouseEnter(object sender, EventArgs e)
    //{
    //    btnInfo.BackColor = Color.FromArgb(224, 160, 96);
    //}

    //private void btnInfo_MouseLeave(object sender, EventArgs e)
    //{

    //    if (panInfo.Visible)
    //    {
    //        btnInfo.BackColor = Color.FromArgb(235, 110, 0);
    //    }
    //    else
    //    {
    //        btnInfo.BackColor = Color.FromArgb(225, 128, 0);
    //    }

    //}

    //private void Main_PostLoad(object sender, EventArgs e)
    //{
    //    Preview(StyleCombo.SelectedIndex, PreviewBox);
    //    PostLoadTimer.Stop();
    //}

    #endregion

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
     * Move the user creation into the user handler
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
     * ctrl + click to fill with corrosponding left or right click colour.
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
     * UPDATING THE WINDOW CLEARS THA FUCKIN CANVAS
     * so does resizing this VVV 
     * Fix the replace on zoom thingy (Get graphics, scale, then replace post zoom? not sure if this would work.)
     * 
     * 
     * 
     * Checkbox in special to enable zoom
     * 
     * Middle click centers, not resizes
     * Canvas ancors to centre, not corner
     * 
     * Replace ui elements with metro framework
     * 
     * autosaving
     * 
     * 
     * How to kill hanging processes:
     * open WIN + R and run ' taskkill /F /PID ' followed by the process number indicated in the error list to kill the process, even if it cannot be found in the task manager.
     * Error eg:  ..The file is locked by: "Canvas (8760)"..
     * Command eg: taskkill /F /PID 8760
     *  
     * If the thread is left hanging open after closing a window (indicated by prevention of building with 'being used by another process'), list it below alongside how the window was closed.
     * Splash Home Screen - 'X' button
     * 
     * 
     * Application resetting for debugging:
     * Canvas will prompt for auto reset 
     */


    public partial class Main : MetroFramework.Forms.MetroForm
    {

        #region variables
        //Objects
        private AccountHandler handler = new AccountHandler(); //class object to handle the user account.
        private Forms.Splash splash = new Forms.Splash(); //Form object for splash screen
        private Forms.Load loader = new Forms.Load(); //form object for loading projects.
        public static CustomBrushes brush = new CustomBrushes(); //Class object for defining our brushes.
        private Settings settings = new Settings();


        //Strings
        public String fileName = "Canvas1";

        //Integers
        private static int zoomPercent = 1;
        private static int minZoomPercent = 1;
        private static int maxZoomPercent = 150;
        private static int originscalex, originscaley;
        public static int BrushModInt1, BrushModInt2, BrushModInt3;
        public static int PaintOffsetX;
        public static int PaintOffsetY;

        //Boolean
        private static Boolean Draw = false;
        public static Boolean PointToPoint = false;

        //Custom enumerated
        private static OptionPaneVisibility OPIV = OptionPaneVisibility.TBD;
     
        #endregion

        #region Instantiators
        public Main()
        {
            InitializeComponent();
            PanelBox.MouseWheel += PanelBox_MouseWheel; //There is no mouse wheel event in the designer, so this is here
            MenuTabber.MouseWheel += MenuTabber_MouseWheel;
            Application.ThreadException += new ThreadExceptionEventHandler(ThreadExceptionEventHandler);
        }

        public void ResetCanvas() //Method to reset canvas to default settings, and delete all data..
        {
            try 
            {
                Directory.Delete(Settings.Default.ApplicationDataLocation, true);
                //attempt to delete all data.
            }
            catch (Exception) //failed to do so
            {
                //Warn user of failiure to delete data
                if (MessageBox.Show("Unable to delete app data folder at '" + Properties.Settings.Default.ApplicationDataLocation + "'. This may be because it doesn't exist or is in use. Reset without deleting?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return; //Stop if user decides to cancel, else continue.
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
            }
            catch (Exception)
            {
                //Super fuckin' annoying .net problem caused by multiple consecutive resets. Do nothing.
                MessageBox.Show("Windows has encoutered an error with saving the applications settings. This is commonly caused by restoring the application before it is set-up. If this occours whilst the application is set-up, take a copy of the appdata folder, reinstall the application and set it up, then restore the appdata folder.");
            }
            MessageBox.Show("Reset complete!");
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //set the title
            string title = " - Canvas";
            if (Debugger.IsAttached)
            {
                title += " [Debugging session]";
            } 

            this.Text = fileName + title;

            //Initial window prep
            prepareWindow(windowUpdateType.Initial);
            PaintOffsetX = 10;
            PaintOffsetY = MenuTabber.Top + MenuTabber.Height + 10;
            //StyleCombo.SelectedIndex = 0;
        }

        private void prepareWindow(windowUpdateType type)
        {
            //Window preperation
            if (type == windowUpdateType.Initial)
            {
                //if initial, set location and size
                this.Location = new Point(0, 0);
                this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 1);

                //Menutabber size too
                MenuTabber.Width = this.Width;
            }



            //Drawing panel preperation
            UpdateCanvasLocation(OptionsPane.Visible);
            panelArea.Height = this.Height - 10; //size to ten away from bottom of window
            panelArea.Width = (this.Width - 20) - OptionsPane.Width; //size to ten away from left of window
            PanelBox.Height = panelArea.Height;
            PanelBox.Width = panelArea.Width;
            originscalex = panelArea.Height;
            originscaley = panelArea.Width;

            if (this.Width < this.Height) //prevent zooming from exceeding boundarys with rectangular monitors with max size
            {
                maxZoomPercent = this.Width - 10;
            }
            else
            {
                maxZoomPercent = this.Height - 10;
            }

            resizePane(); //cause update with these new panel values

            //OptionsPane
            SetOptionPaneVisible(OptionPaneVisibility.Hidden); //hide it
            OptionsPane.Height = this.Height; //set it's height

            //Preview(StyleCombo.SelectedIndex, PreviewBox); - vitrified. no need to initialise a preview on a new class instance. It's being called way before the window is even created.
            //Just create a preview upon show.

        }


        private void main_Shown(object sender, EventArgs e)
        {
            Preview(StyleCombo.SelectedIndex, PreviewBox); //Initial preview when window is finally shown.
            SetOptionPaneVisible(OptionPaneVisibility.Hidden);//This is fuckin dumb, but it is needed to fix the canvas
            SetOptionPaneVisible(OptionPaneVisibility.Invert);//being cleared the first time the options pane is opened
            SetOptionPaneVisible(OptionPaneVisibility.Invert);

        }

        public void recover()
        {
            try
            {
                handler.LogInUser(Properties.Settings.Default.LastUser);
                fileName = Properties.Settings.Default.CrashProject; //set filename from loaded file

                PanelBox.Image = Image.FromFile(Properties.Settings.Default.ApplicationDataLocation + handler.EncryptUserName(handler.userName) + "/" + Properties.Settings.Default.CrashProject); //set image from loaded file
                PanelBox.Refresh(); //refresh to set image
                Show(); //show window

                Properties.Settings.Default.CrashProject = "";
                Properties.Settings.Default.CrashOnClose = false;
                Properties.Settings.Default.Save();
            } catch (Exception)
            {
                MessageBox.Show("Failed to recover project. Try re-importing the backup from ./appdata/CrashHandler/Backup.Jpeg");
                Properties.Settings.Default.CrashProject = "";
                Properties.Settings.Default.CrashOnClose = false;
                Properties.Settings.Default.Save();
                Application.Exit();
            }
        }

        public void LogIn(string usertolog)
        {
            relog: //call to come back without nesting invokes

            handler.LogInUser(usertolog); //Load user data in the account handler class
            try
            {
                splash = new Forms.Splash();
                splash.ShowDialog(); //Open splash screen - User's first interactable screen after logging in is this line.
            } catch (ObjectDisposedException) { }
            //an exception is thrown when the load form attempts to end the application, but the main tries to reload the splash. This'll do/


            switch (splash.Option) //Which option did the user select in the splash screen?
            {
                case Forms.SplashOption.NewProject: //open default
                    PanelBox.Image = new Bitmap(PanelBox.Width, PanelBox.Height);
                    PanelBox.Refresh();
                    fileName = "Canvas1";
                    Show();
                    break;


                case Forms.SplashOption.LogOut:
                    handler.LogOutUser(); //Invoke log out user. This method will close the application if sucessfull.
                    goto relog;  //resurse if log out did not complete

                case Forms.SplashOption.Nothing:
                    Application.Exit(); //Exit if splash screen is closed by user
                    break;

                case Forms.SplashOption.CanvasSettings:
                        settings.ShowDialog();
                    break;

                case Forms.SplashOption.LoadProject: //User want's to load a project.
                    loader.LoadFile(handler.userName);//invoke load dialog with the current user

                    if (loader.filepath == "") { goto relog; }//resurse to splash screen if no project was selected
                    else //project was selected
                    {
                        fileName = loader.fileName; //set filename from loaded file
                        PanelBox.Image = Image.FromFile(loader.filepath); //set image from loaded file
                        PanelBox.Refresh(); //refresh to set image
                        Show(); //show window
                    }
                    break;
            }
            //Never place code under this switch. The user's option should be handled entirely within it.
        }


        #endregion

        #region Canvas     


        //Bitmap ImageCache;
        private void PanelBox_MouseWheel(object sender, MouseEventArgs e) //Mouse wheel
        {
            //Graphics tempg = PanelBox.CreateGraphics();
            //ImageCache = new Bitmap(panelArea.Width, panelArea.Height, tempg);
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
            //chacheDrawTimer.Start();
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
                UpdateCanvasLocation(OptionsPane.Visible);
            }
           
        }

        private static int StartMouseX, StartMouseY;

        private void PanelBox_MouseDown(object sender, MouseEventArgs e)
        {
            StartMouseX = Cursor.Position.X;
            StartMouseY = Cursor.Position.Y;
            Drawing();
        }

        private void UpdateCanvasLocation(Boolean vis)
        {
            if (vis)
            {
                panelArea.Location = new Point(OptionsPane.Width + 10, MenuTabber.Height + MenuTabber.Top + 10); //position ten pixels away from top and side panels.
            }
            else
            {
                panelArea.Location = new Point(10, MenuTabber.Top + MenuTabber.Height + 10); //position ten pixels away from top and side panels.
            }

        }
        #endregion

        #region Window Handling and events
        private void chkResizewindow_CheckedChanged(object sender, EventArgs e) //Allow resizing, if user requests - but warn first.
        {
            this.Resizable = chkResizeWindow.Checked;
            if (chkResizeWindow.Checked)
            {
                MessageBox.Show("Resizing the window will erase the canvas graphics layer!");
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
        }
    
        private void StyleCombo_SelectedIndexChanged(object sender, EventArgs e) //Change brush, initalise it then display it's preview.
        {
            initialiseBrush(StyleCombo.SelectedIndex);
            Preview(StyleCombo.SelectedIndex, PreviewBox);
            if (StyleCombo.SelectedIndex == 4) {
                PointToPoint = true;
            }
           
            
        }
        private void Main_SizeChanged(object sender, EventArgs e) //invode resize when resized
        {
            prepareWindow(windowUpdateType.Resize);
        }

        private void MenuTabber_MouseWheel(object sender, MouseEventArgs e) //Change tab when scroll wheelin' on the tab menu.
        {
            if (e.Delta > 0) 
            {
                if (MenuTabber.SelectedIndex == 0)
                {
                    return;
                }
                else
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

        private void btnNextStyle_Click(object sender, EventArgs e) //Change to next brush
        {
            if (StyleCombo.SelectedIndex < StyleCombo.Items.Count - 1)
            {
                StyleCombo.SelectedIndex++;
            }
        }

        private void BtnPrevStyle_Click(object sender, EventArgs e) //Change to previous brush
        {
            if (StyleCombo.SelectedIndex > 0)
            {
                StyleCombo.SelectedIndex--;
            }
        }

        private void BrushMod1_ValueChanged(object sender, EventArgs e) //Validate and store value
        {
            EndValidation(sender,e);
            BrushModInt1 = int.Parse(BrushMod1.Text);
        }

        private void BrushMod2_ValueChanged(object sender, EventArgs e)//Validate and store value
        {
            EndValidation(sender, e);
            BrushModInt2 = int.Parse(BrushMod2.Text);
        }

        private void BrushMod3_ValueChanged(object sender, EventArgs e)//Validate and store value
        {
            EndValidation(sender, e);
            BrushModInt3 = int.Parse(BrushMod3.Text);
        }

        private void initialiseBrush(int style) //Invoked to set brush after user has selected the brush.
        {
            brush.initialiseBrush(this, style);
        }

        private void PreviewBox_Click(object sender, EventArgs e)
        {
            Preview(StyleCombo.SelectedIndex, PreviewBox);
        }

        private void btnCanvasClear_Click(object sender, EventArgs e) //clear with backcolour.
        {
            PanelBox.CreateGraphics().Clear(PicPanelColor.BackColor);
        }

        private void btnLogOut_Click(object sender, EventArgs e)//exit project, invoke login method to go back to splash screeb.
        {
            this.Hide();
            SetOptionPaneVisible(OptionPaneVisibility.Hidden);
            LogIn(handler.userName);
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            throw new Exception("Test");
        }

        private void close(object sender, FormClosedEventArgs e) //ensure the thread is closed when the window is.
        {
            Application.Exit();
        }

        public void ThreadExceptionEventHandler(object sender, ThreadExceptionEventArgs e) //Cause crash. Can call manually in a state of desperation - but is also called upon an unhandled exception.
        {

            Console.Write("A crutial state has been declared at " + DateTime.Now.ToShortTimeString() + ", canvas will now exit.");
            MessageBox.Show("Canvas has encountered a fatal problem and must close. All data since the last save will be lost, sorry. You will be prompted to open the current project opon re-loading.", "[Attach debugger now to collect data]");


            /*
              How to debug this:
              1) Execute without a debugger
              2) Cause an exception (There's a button for that in 'extra', but it may be moved to settings.)
              3) When the dialog shows, attach a debugger to the thread labled '[Attach debugger now to collect data]'
              4) Acknowledge the dialog. The debugger should atomatically break here.
              */
              Debugger.Break(); //Break any connected debugger to notify the software tester.



            //invoke typical save

            //is there a crash handler folder yet? if not, create it.
            if (!System.IO.Directory.Exists(Properties.Settings.Default.ApplicationDataLocation + "CrashHandler/")) System.IO.Directory.CreateDirectory(Properties.Settings.Default.ApplicationDataLocation + "/CrashHandler/");

            try
            {
                if (PanelBox.Image != null)
                {
                    Bitmap filetosave = new Bitmap(PanelBox.Image);
                    filetosave.Save(Properties.Settings.Default.ApplicationDataLocation + "CrashHandler/Backup.Jpeg", ImageFormat.Jpeg); //Save canvas's memory to backup file
                }
            } catch (Exception)
            {
                MessageBox.Show("Canvas could not save a backup of the current project. Sorry.");
            }


            string filename = "Crash Log.log"; //define log
            string loc = Properties.Settings.Default.ApplicationDataLocation + "CrashHandler/" + filename;
            Process proc = Process.GetCurrentProcess(); //get current thread

            string[] lines = new string[28]
            {
                "Current User: " + Properties.Settings.Default.LastUser,
                "Loaded project: " + fileName,
                "",
                "Canvas Up time: " + Convert.ToString(DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime()),
                "",
                "Memory (b):",

                "Working set: " + proc.WorkingSet64,
                "Maximum working set: " + proc.MinWorkingSet,
                "Minimum working set: " + proc.MaxWorkingSet,
                "Peak working set: " +  proc.PeakWorkingSet64,

                "paged memory: " +  proc.PagedMemorySize64,
                "Non-paged memory: " +  proc.NonpagedSystemMemorySize64,
                "paged system memory: " +  proc.PagedSystemMemorySize64,
                "Peak paged memory: " +  proc.PeakPagedMemorySize64,

                "Virtual memory: " +  proc.VirtualMemorySize64,
                "Peak virtual memory: " +  proc.PeakVirtualMemorySize64,
                "",
                "Date of capture: " + DateTime.Now.ToShortDateString(),
                "Time of capture: " + DateTime.Now.ToShortTimeString(),
                "",
                "Exception data: " + e.Exception.Data,
                "Exception message: " + e.Exception.Message,
                "Error code: " + e.Exception.HResult,
                "Inner exception: " + e.Exception.InnerException,
                "Caused by method: " + e.Exception.TargetSite,
                "In application: " + e.Exception.Source,
                "Help link: " + e.Exception.HelpLink,
                "Stack trace: " + e.Exception.StackTrace,
            };
            
            

            //Dump it to file
            System.IO.File.WriteAllLines(loc, lines);

            //Set setting data for crash state
            Properties.Settings.Default.CrashOnClose = true;
            Properties.Settings.Default.LastUser = handler.userName;
            Properties.Settings.Default.CrashProject = filename;
            Properties.Settings.Default.Save();

           
            
            //throw new SystemException(); Throw exception to crash application -- vitrified. It was caught by the JIT, and now the exception handler; thus getting in a loop.
            
            Application.Exit(); //This is now how the application is ended by the crash handler.          ignore this --> //this is not unreachable. That's what they want you to believe!!
        }

        private void btnFill_Click(object sender, EventArgs e) //Fill with primary colour
        {
            PanelBox.CreateGraphics().Clear(picPrimaryColour.BackColor);
        }

        private void btnSecondary_Click(object sender, EventArgs e) //fill with secondary
        {
            PanelBox.CreateGraphics().Clear(picSecondaryColour.BackColor);
        }

        private void btnToggleOptionPane_Click(object sender, EventArgs e) //invoke a toggle of the option pane.
        {
            SetOptionPaneVisible(OptionPaneVisibility.Invert);
        }

        private void SetOptionPaneVisible(OptionPaneVisibility Visibility) //set visibility state, then update canvas
        {
            switch (Visibility)
            {
                case OptionPaneVisibility.Hidden:
                    OPIV = OptionPaneVisibility.Hidden;
                    OptionsPane.Visible = false;
                    UpdateCanvasLocation(false);
                    break;

                case OptionPaneVisibility.TBD:
                    if (this.Width < OptionsPane.Width + 500)
                    {
                        UpdateCanvasLocation(false);
                        SetOptionPaneVisible(OptionPaneVisibility.Hidden);
                    }
                    else
                    {
                        UpdateCanvasLocation(true);
                        SetOptionPaneVisible(OptionPaneVisibility.Shown);
                    }
                    break;

                case OptionPaneVisibility.Shown:
                    OPIV = OptionPaneVisibility.Shown;
                    UpdateCanvasLocation(true);
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

        }

        private void main_keypress(object sender, KeyPressEventArgs e)
        {
            int i = e.KeyChar;

            switch (i)
            {
                case 27:
                    SetOptionPaneVisible(OptionPaneVisibility.Invert);
                    break;
            }
        }
        #endregion

        #region Drawing
        private void Colour_Picker(object sender, EventArgs e) // Use this when colours are worked on.
        {
            DialogResult = colorDialog.ShowDialog();

            PictureBox pic = (PictureBox)sender;
            pic.BackColor = colorDialog.Color;

            //------------------------------------------------------------------------------------------------------// - Recent colour
            if (Recent_1.BackColor == SystemColors.Control || Recent_1.BackColor == picPrimaryColour.BackColor) { Recent_1.BackColor = picPrimaryColour.BackColor; }
            else if (Recent_2.BackColor == SystemColors.Control || Recent_2.BackColor == picPrimaryColour.BackColor) { Recent_2.BackColor = picPrimaryColour.BackColor; }
            else if (Recent_3.BackColor == SystemColors.Control || Recent_3.BackColor == picPrimaryColour.BackColor) { Recent_3.BackColor = picPrimaryColour.BackColor; }
            else if (Recent_4.BackColor == SystemColors.Control || Recent_4.BackColor == picPrimaryColour.BackColor) { Recent_4.BackColor = picPrimaryColour.BackColor; }
            else if (Recent_5.BackColor == SystemColors.Control || Recent_5.BackColor == picPrimaryColour.BackColor) { Recent_5.BackColor = picPrimaryColour.BackColor; }
            else if (Recent_6.BackColor == SystemColors.Control || Recent_6.BackColor == picPrimaryColour.BackColor) { Recent_6.BackColor = picPrimaryColour.BackColor; }

            else if (Recent_7.BackColor == SystemColors.Control || Recent_7.BackColor == picPrimaryColour.BackColor) { Recent_7.BackColor = picPrimaryColour.BackColor; }
            else if (Recent_8.BackColor == SystemColors.Control || Recent_8.BackColor == picPrimaryColour.BackColor) { Recent_8.BackColor = picPrimaryColour.BackColor; }
            else if (Recent_9.BackColor == SystemColors.Control || Recent_9.BackColor == picPrimaryColour.BackColor) { Recent_9.BackColor = picPrimaryColour.BackColor; }
            else if (Recent_10.BackColor == SystemColors.Control || Recent_10.BackColor == picPrimaryColour.BackColor) { Recent_10.BackColor = picPrimaryColour.BackColor; }
            else if (Recent_11.BackColor == SystemColors.Control || Recent_11.BackColor == picPrimaryColour.BackColor) { Recent_11.BackColor = picPrimaryColour.BackColor; }
            else if (Recent_12.BackColor == SystemColors.Control || Recent_12.BackColor == picPrimaryColour.BackColor) { Recent_12.BackColor = picPrimaryColour.BackColor; }
            //------------------------------------------------------------------------------------------------------//
        }
        private void Recent_1_Click(object sender, EventArgs e)
        {
            PictureBox Picture = (PictureBox)sender;
            picPrimaryColour.BackColor = Picture.BackColor;
        }

        public void Preview(int style, PictureBox Output) //Display a brush in the parsed picturebox.
        {
            if (!chkEnablePreview.Checked) { return; } //don't if not enabled.
            Output.Image = new Bitmap(Output.Width, Output.Height); //Ensure there is an image to draw to, and also clear out the output box.


            //Draw the three stamp types.
            for (double i = 1.0; i <= Output.Width - 50; i += 0.1)
            {

                //cosine wave
                brush.stamp(this, style, picPrimaryColour.BackColor, Output, ((int)i), (int)(Math.Cos(i) * 10) + 10, int.Parse(BrushSize.Text), int.Parse(BrushSize.Text), false);

                //Straight line
                brush.stamp(this, style, picPrimaryColour.BackColor, Output, ((int)i), Output.Height - 10, int.Parse(BrushSize.Text), int.Parse(BrushSize.Text), false);
            }


            //Single stamp
            brush.stamp(this, style, picPrimaryColour.BackColor, Output, Output.Width - 25 - 5, (Output.Height / 2) - 5, 10, 10, false);

            Bitmap image = new Bitmap(Output.Width, Output.Width, Output.CreateGraphics());
            image.Save("./999.jpeg", ImageFormat.Jpeg);

        }

      





        /*
         * This virtual method is for drawing on the canvas.
         * it is invoked when the mouse is down, but it loops itself.
         * 
         * virtual method modifyer = permits the method to be overridden by other code whilst it is running.
         * This isn't really needed, since the method implements 'application.doevents' which will invoke 
         * other events whilst still inside the method.
         */
        virtual public void Drawing() {
           // brush.PointToPoint = true;
            Draw = true;
            while (Draw)
            {
                Application.DoEvents(); //invoke other events and draw the graphics to the canvas.
                
                //always assume mouse is not down, as so not to get stuck in this loop if the mouse is lost.
                Draw = false;

                if (Control.MouseButtons == MouseButtons.Left) //primary colour
                {
                    brush.stamp(this, StyleCombo.SelectedIndex, picPrimaryColour.BackColor, PanelBox, Cursor.Position.X - this.Left, Cursor.Position.Y - this.Top, int.Parse(BrushSize.Text) / zoomPercent, int.Parse(BrushSize.Text) / zoomPercent, true);

                    Draw = true; //Mouse is still down.
                }

                if (Control.MouseButtons == MouseButtons.Right) //secondary colour
                {
                    brush.stamp(this, StyleCombo.SelectedIndex, picSecondaryColour.BackColor, PanelBox, Cursor.Position.X - this.Left, Cursor.Position.Y - this.Top, int.Parse(BrushSize.Text) / zoomPercent, int.Parse(BrushSize.Text) / zoomPercent, true);
                    Draw = true;//Mouse is still down.
                }
                continue; //loop
            }
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

        #region Colour Handling

        


        #endregion

    }
}
    
