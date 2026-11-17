using StoreProject.People;
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
    public partial class AddOrEditPerson : UserControl
    {



        List<string> list = new List<string>();
        public Action<int> PersonFilled;
        public Action<PeopleDto> FullPersonFilled;


        enum eMode { eAddNewPerson = 1, eEditNewPerson = 2 }
        eMode _Mode = eMode.eAddNewPerson;

        PeopleDto person = new PeopleDto();
        public AddOrEditPerson()
        {
            InitializeComponent();
            FillNoList();
        }

        private void CallPersonEvent()
        {
            if (PersonFilled != null)
            {

                PersonFilled.Invoke(person.PersonId);
            }
        }

        private void CallFuulPersonEvent()
        {
            if (FullPersonFilled != null)
            {

                FullPersonFilled.Invoke(person);
            }
        }

        private void FillPerson()
        {
            person.FirstName = TBFirstName.Text;
            person.SecondName = TBSecondName.Text;
            person.LastName = TBLastName.Text;
            person.PhoneNumber = Convert.ToInt32(TBPhoneNumber.Text);
            person.No = Convert.ToInt32(TBNO.Text);

        }

        private async Task FillNoList()
        {
            list = await PeopleApi.GetAllPeopleNo();

            
        }

        public async Task LoadPersonId(int PersonId)
        {


            person = await PeopleApi.FindPerson(PersonId);

            if (person == null) return;

            _Mode = eMode.eEditNewPerson;
            TBFirstName.Text = person.FirstName;
            TBSecondName.Text = person.SecondName;
            TBLastName.Text = person.LastName;
            TBNO.Text = person.No.ToString();
            TBPhoneNumber.Text = person.PhoneNumber.ToString();

            panel1.Enabled = false;

        }

        private async void BtnNext_Click(object sender, EventArgs e)
        {
            bool IsSuccess = false;
            int Id = -1;
            if (!this.ValidateChildren())
            {
                return;
            }

            FillPerson();

            if (_Mode == eMode.eAddNewPerson)
            {
                person.PersonId= await PeopleApi.AddNewPerson(person);

                IsSuccess = person.PersonId > 0;
            }
            else
            {
                IsSuccess = await PeopleApi.UpdatePerson(person);
            }

            if (IsSuccess)
            {
                CallPersonEvent();
                CallFuulPersonEvent();
            }
        }
        private void TextBox_Validating(TextBox box, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(box.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(box, "You must fill text box with a value");
                box.Focus();

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(box, "");

            }
        }
       
        private void TB_Validating(object sender, CancelEventArgs e)
        {
            TextBox_Validating((TextBox)sender, e);
        }

        private void PhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBPhoneNumber.Text) )
            {

                e.Cancel = true;
                errorProvider1.SetError(TBPhoneNumber, "You must fill text box with a value");
                TBPhoneNumber.Focus();

            }
            else if( TBPhoneNumber.Text.Length != 10)
            {
                e.Cancel = true;
                errorProvider1.SetError(TBPhoneNumber, "You must phone number equal 10");
                TBPhoneNumber.Focus();

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBPhoneNumber, "");

            }
        }

        private void TBNO_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBNO.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(TBNO, "You must fill text box with a value");
                TBNO.Focus();

            }
            else if (list.Contains(TBNO.Text)&&TBNO.Text!=person.No.ToString())
            {
                e.Cancel = true;
                errorProvider1.SetError(TBNO, "N.O is found , write anthor one");
                TBNO.Focus();

            }
            else if (TBNO.Text.Length != 9)
            {
                e.Cancel = true;
                errorProvider1.SetError(TBNO, "You must [N.O] equal 10");
                TBNO.Focus();

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBNO, "");

            }
        }

 

     
        private void AddOrEditPerson_Enter(object sender, EventArgs e)
        {
            FillNoList();
        }
    }
}
