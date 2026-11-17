using StoreProject.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.GlobalClasses
{
    public class ClsCustomerGlobal
    {

        public static CustomerDTO Customer;

        /*public static bool InitializePlayer(string UserName, string Password)
        {
            ClsPlayerGlobal.Customer = ClsCustomers.FindCustomer(UserName, Password);


            if (Customer != null)
            {

                ClsPlayers.RefershPlayer += RefershPlayer;
                return true;
            }
            else return false;
        }

        private static void RefershPlayer()
        {
            ClsPlayerGlobal.PlayerGlobal = ClsPlayers.FindPlayerByPlayerNameAndPassword(PlayerGlobal.PlayerName, PlayerGlobal.Password);

        }*/



    }
}
