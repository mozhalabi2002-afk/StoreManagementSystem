using Microsoft.Win32;
using StoreProject.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreProject.GlobalClasses
{
    public class ClsVendorGlobal
    {
        public static DTOVendor Vendor;

        public static bool RememberUsernameAndaPasswordByRegistry(string Username, string Password)
        {

            string KeyFile = @"HKEY_CURRENT_USER\SOFTWARE\StoreProject";
            string ValueName = "UserName";
            string ValuePassword = "Password";
            string ValueNameData = Username;
            string ValuePasswordData = Password;
            try
            {
                if (Username != "")
                {
                    Registry.SetValue(KeyFile, ValueName, ValueNameData, RegistryValueKind.String);
                    Registry.SetValue(KeyFile, ValuePassword, ValuePasswordData, RegistryValueKind.String);
                }
                else
                {
                    Registry.SetValue(KeyFile, ValueName, "", RegistryValueKind.String);

                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Message Error : {ex.Message}");
                return false;

            }
        }

        public static bool GetStoredCredentialByRegistry(ref string Username, ref string Password)
        {

            string KeyFile = @"HKEY_CURRENT_USER\SOFTWARE\StoreProject";
            string ValueName = "UserName";
            string ValuePassword = "Password";

            try
            {
                Username = Registry.GetValue(KeyFile, ValueName, null) as string;
                Password = Registry.GetValue(KeyFile, ValuePassword, null) as string;

                if (Username != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Message Error : {ex.Message}");
                return false;

            }
        }


    }
}
