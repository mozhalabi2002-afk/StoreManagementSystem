using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreProject
{
    public partial class TimeControl : UserControl
    {
        private TimeSpan _Value;
        public TimeSpan Value { 
            get {
                return TimeSpan.Parse(GetHour() + ":" + GetMinute()); ; }
            
            set { _Value = value;SetTime(value); } }
        public TimeControl()
        {
            InitializeComponent();
        }

        private int Hour;
        private int Minute;

        public void GetDefault()
        {

            int Hour = DateTime.Now.Hour;
            TBMinute.Text = DateTime.Now.Minute.ToString();

            if (Hour<=12)
            {
                RBAM.Checked = true;
                TBHour.Text = Hour.ToString();
            }
            else
            {
                RBPM.Checked = true;
                TBHour.Text = (Hour - 12).ToString();
            }

        }

        private void SetTime(TimeSpan time)
        {
            if (time.Hours > 12)
            {
                RBPM.Checked = true;
                TBHour.Text = (time.Hours - 12).ToString();
            }
            else
            {
                RBAM.Checked = true;
                TBHour.Text=(time.Hours).ToString();
            }

            TBMinute.Text = time.Minutes.ToString();
        }

        private int GetHour()
        {
            if (RBPM.Checked)
            {
                return 12 + Convert.ToInt32(TBHour.Text);
            }
            else
            {
                return Convert.ToInt32(TBHour.Text);
            }

                
        }

        private int GetMinute()
        {
            return Convert.ToInt32(TBMinute.Text);
        }
        private void TBHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            int NewNumber = Convert.ToInt32(e.KeyChar);

            bool Check = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (Check)
            {
                e.Handled = true;
                return;
            }

            if (string.IsNullOrEmpty(TBHour.Text))
            {
                e.Handled = false;
                return;
            }

            if ((Convert.ToInt32(TBHour.Text) > 1|| Convert.ToInt32(TBHour.Text) > 12)&&NewNumber!=8)
            {
                e.Handled= true;
                return;
            }else if((Convert.ToInt32(TBHour.Text) == 1&& NewNumber > 50)&& NewNumber != 8)
            {
                e.Handled = true;
                return;
            }
               
            
        }

        private void TBMinute_KeyPress(object sender, KeyPressEventArgs e)
        {
            int NewNumber = Convert.ToInt32(e.KeyChar);

            bool Check = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (Check)
            {
                e.Handled = true;
                return;
            }

            if (string.IsNullOrEmpty(TBMinute.Text))
            {
                e.Handled = false;
                return;
            }


            if ((Convert.ToInt32(TBMinute.Text) > 6|| Convert.ToInt32(TBMinute.Text) > 60)&& NewNumber != 8)
            {
                e.Handled = true;
                return;
            }
            else if ((Convert.ToInt32(TBHour.Text) == 6 && NewNumber > 48) && NewNumber != 8)
            {
                e.Handled = true;
                return;
            }
            

        }
    }
}
