using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace Canvas.Classes
{
    class AccountHandler
    {
        //Keys.
        protected int EncPrivateKey = 156;
        private int EncPublicKey = -1;
        public string userName = "CauseNoUserException";

        //Variables
        private static bool PublicKeySet = false;
        private static bool UserNameSet = false;
        private static bool UserLoggedIn = false; //Read from setting data in instantiator

        public void setEncPublicKey(int key, bool validatekey)
        {
            //Validate key is within range. key is already int, no other validation is needed.
            if (key < 1) { InvalidKeyException("Key too small to set"); }
            if (key > 255) { InvalidKeyException("Key too large to set"); }

            if (!PublicKeySet) { PublicKeySet = !PublicKeySet; }
            EncPublicKey = key;

        }

        private void InvalidKeyException(string message)
        {
            Console.WriteLine("[AccountHandler] An invalid key exception was issued. Halting.");
            throw new InvalidOperationException(message);

        }

        private void validateKey()
        {

        }

        private void keyIsInUserName()
        {

        }

        private void CreateUser()
        {

        }

        private void RemoveUser()
        {

        }

        public bool ValidatePasswordCorrect(string password, string username)
        {
            //get key for user
            //encrypt password
            //check against stored string

            string EncPassword = UserEncrypt(username, password);


            string testString = System.IO.File.ReadAllText(Properties.Settings.Default.ApplicationDataLocation + "Users/" + EncryptUserName(username) + "/User.dat");

            if (EncPassword == testString) { return true; }

            return false;
        }

        public void LoadUser(string user)
        {
            
        }

        private void DecryptUser()
        {
            //Import and decrypt data to memory
        }

        public string EncryptUserName(string username)
        {
            string usernameAscii = "";
            string key = UserKey(username);

           

            for (int i = 0; i <= username.Length - 1; i++) //Convert username to ascii id's
            {
                int character = (int)char.Parse(username.Substring(i, 1));
                usernameAscii += (char)(character + int.Parse(key));
            }

            return usernameAscii;
        }

        private string UserKey(string username)
        {
            string usernameAscii = "";
            for (int i = 0; i <= username.Length - 1; i++) //Convert username to ascii id's
            {
                int character = (int)char.Parse(username.Substring(i, 1));
                usernameAscii += character;
            }


            for (int i = 0; i <= username.Length - 3; i++)
            {
                string temp = usernameAscii.Substring(i, 3);
                if (int.Parse(temp) < 255 && int.Parse(temp) > 1)
                {
                    return temp;
                }
            }

            
            return "-1";
        }

        public string UserEncrypt(string User, string str)
        {
            string key = UserKey(User);
            string encryptedstring = "";

            for (int i = 0; i <= str.Length - 1; i++)
            {
                int characterasascii = (int)char.Parse(str.Substring(i, 1));
                characterasascii += int.Parse(key);
                encryptedstring += (char)characterasascii;
            }
                return encryptedstring;
        }

        private void SaveUser()
        {
            //encrypt and write data from application
        }

        public void LogOutUser()
        {
            //call save user
            //save work
            if (Properties.Settings.Default.AutoLogIn)
            {
                if (MessageBox.Show("Auto Log In is enabled. Logging out will disable this, and you will have to log in again. Are you sure?", "Log out of Canvas?", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }

            Properties.Settings.Default.LastUser = "NoUserException";
            Properties.Settings.Default.AutoLogIn = false;

            Properties.Settings.Default.Save();
            
            Application.Exit();
        }

        public void LogInUser(string user)
        {
            userName = user;
            EncPublicKey = int.Parse(UserKey(user));
            Properties.Settings.Default.LastUser = user;
            Properties.Settings.Default.Save();
            //auto load if previous user has selected to auto load.
            //Settings data will procure auto login bool, the user that last set it, and who was last logged on to validate.
            //Thoese data points should be clearred when another user loggs in to prevent auto log in of an incorrect user.
        }

        public bool ValidateUser(string username)
        {
            if (username == "") { return false; } //empty is not valid
            if (username.Length < 4) { return false; } //must be longer than four characters
            if (username == "CauseNoUserException") { return false; }
            
            string usernameAscii = "";
            for (int i = 0; i <= username.Length - 1; i++) //Convert username to ascii id's
            {
                int character = (int)char.Parse(username.Substring(i, 1));
                usernameAscii += character;
            }

               if (System.IO.Directory.Exists(Properties.Settings.Default.ApplicationDataLocation + "Users/" + EncryptUserName(username))) { return false; } //Already exists 


            for (int i = 0; i <= username.Length - 3; i++)
            {
                string temp = usernameAscii.Substring(i, 3);
                if (int.Parse(temp) < 255 && int.Parse(temp) > 1)
                {
                    return true;
                }
            }

         
            return false;
        }


    }
}
