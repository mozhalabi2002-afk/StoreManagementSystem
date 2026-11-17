using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Security.Cryptography;

namespace Knowlage_Sword_Game
{
    public  class ClsUtil
    {

        public static bool CreateFolderIsNotExist(string FolderName)
        {
            if (!Directory.Exists(FolderName))
            {

                try
                {
                    Directory.CreateDirectory(FolderName);
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error creating folder");
                    return false;
                }
            }

            return true;
        }

        public static string GenrateGUID()
        {
            return Guid.NewGuid().ToString();
        }

        public static string ReplaceFileNameWithGUID(string SourceFile)
        {
            string FileName = SourceFile;
            FileInfo file = new FileInfo(FileName);
            string extin=file.Extension;
            return GenrateGUID() + extin;

        }

        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {

            string DistinationFolder = @"D:\Programming Project\StoreProject\Images\";
            
            if (!CreateFolderIsNotExist(DistinationFolder)){

                return false;
            }

            string DistinationFile = DistinationFolder + ReplaceFileNameWithGUID(SourceFile);

            try
            {
                File.Copy(SourceFile, DistinationFile, true);

            } 
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            SourceFile = DistinationFile;
            return true;
        }

      public static string HashingPassword(string Password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                StringBuilder stringBuilder = new StringBuilder();
                byte[] hashbyte=sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));

                foreach(byte b in hashbyte)
                {
                    stringBuilder.Append(b.ToString());
                }

                return stringBuilder.ToString();

            }
        }

    }
}
