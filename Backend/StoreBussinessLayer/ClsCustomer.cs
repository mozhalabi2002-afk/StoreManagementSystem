using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class ClsCustomers
    {
        public enum eMode { AddNew = 1, Update = 2 }
        public eMode _Mode = eMode.AddNew;
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }
        public string Password { get; set; }

        public int PersonId { get; set; }
        public ClsPeople Person { get; set; }

        public CustomerDTO customer { get
            {
                return new CustomerDTO(CustomerId, CustomerName, Password, PersonId);
            }
        }
       
        public ClsCustomers(CustomerDTO customer,eMode Mode=eMode.AddNew)
        {
            _Mode = Mode;
            CustomerId = customer.CustomerId;
            PersonId = customer.PersonId;
            CustomerName = customer.CustomerName;
            Password = customer.Password;
            Person = ClsPeople.FindPerson(customer.PersonId);
        }

        private bool _AddNewCustomer()
        {
            CustomerId = ClsCustomersDataAccessLayer.AddNewCustomer(customer);

            return CustomerId != -1;

        }

        private bool _UpdateCustomer()
        {
            return ClsCustomersDataAccessLayer.UpdateCustomer(customer);
        }

        public static bool DeleteCustomer(int CustomerId,int PerosnId)
        {
            bool IsSuccess = false;

            IsSuccess=ClsCustomersDataAccessLayer.DeleteCustomer(CustomerId);

            if (!IsSuccess)
                return false;

            IsSuccess = ClsPeople.DeletePerson(PerosnId);

            return IsSuccess;
        }
        public static ClsCustomers FindCustomer(int CustomerId)
        {

            CustomerDTO customer=ClsCustomersDataAccessLayer.FindCustomerById(CustomerId);

            if (customer!=null)
            {
                return new ClsCustomers(customer, eMode.Update);
            }
            else
            {
                return null;
            }


        }

        public static ClsCustomers FindCustomerByCustomerNameAndPassword(string CustomerName, string Password)
        {

            CustomerDTO customer = ClsCustomersDataAccessLayer.FindCustomerByUserNameAndPassword(CustomerName, Password);

            if (customer != null)
            {
                return new ClsCustomers(customer, eMode.Update);
            }
            else
            {
                return null;
            }



        }

        public static bool IsCustomerExist(int CustomerId)
        {
            return ClsCustomersDataAccessLayer.IsExitCustomerById(CustomerId);
        }

        public static List<CustomerDTO> GetAllCustomers()
        {
            return ClsCustomersDataAccessLayer.GetAllCustomers();
        }
        public bool Save()
        {
            
            if (_Mode == eMode.AddNew)
            {
                if (_AddNewCustomer())
                {
                    _Mode = eMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return _UpdateCustomer();
            }
        }

    }
}
