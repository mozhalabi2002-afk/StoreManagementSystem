using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreProject.Customers
{
    public partial class FrmCustomerHome : Form
    {
        public delegate void CloseHomeDelegate();
        public CloseHomeDelegate CloseHome;
        public FrmCustomerHome()
        {
            InitializeComponent();
        }

        private void CallClose()
        {
            if (CloseHome != null)
            {
                CloseHome.Invoke();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            CallClose();
        }
    }
}
