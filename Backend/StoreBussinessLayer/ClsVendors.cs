using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class ClsVendors
    {
       public enum eMode { eAddNew = 1, eUpdate = 2 }
        public eMode _Mode = eMode.eAddNew;
        public int VendorId { get; set; }
        public int PersonId { get; set; }

        public DTOVendor Vendor { get {
                return new DTOVendor(VendorId, PersonId, VendorName,Password ,ShiftTimeStarted,
            ShiftTimeFinshed, SalaryPerHour, Permission); } }
        public string VendorName { get; set; }
        public string Password { get; set; }
        public ClsPeople Person { get; set; }
        public string ShiftTimeStarted { get; set; }
        public string ShiftTimeFinshed { get; set; }

        public double SalaryPerHour { get; set; }

        public int Permission { get; set; }

        public ClsVendors(DTOVendor vendor,eMode Mode=eMode.eAddNew)
        {
            _Mode = Mode;
            VendorId = vendor.VendorId;
            PersonId = vendor.PersonId;
            VendorName = vendor.VendorName;
            Password = vendor.Password;
            ShiftTimeStarted = vendor.ShiftTimeStarted;
            ShiftTimeFinshed = vendor.ShiftTimeFinshed;
            SalaryPerHour = vendor.SalaryPerHour;
            Permission = vendor.Permission;
            Person = ClsPeople.FindPerson(vendor.PersonId);
        }
        private bool _AddNewVendor()
        {
            VendorId = ClsVendorDataAccessLayer.AddNewVendor(Vendor);
            return VendorId != -1;
        }

        public static DTOVendor GetOneVendor()
        {

            DTOVendor dTO = new DTOVendor();

            dTO.PersonId = 5013;
            dTO.Password = "A7";
           
            dTO.SalaryPerHour = 44;
            dTO.ShiftTimeFinshed = "14:41:00";
            dTO.ShiftTimeStarted = "11:41:00";
            dTO.VendorName = "Vendor7";

            return dTO;

        }

        private bool _UpdateVendor()
        {
            return ClsVendorDataAccessLayer.UpdateVendor(Vendor);
        }
        public static bool DeleteVendor(int VendorId,int PersonId)
        {
            bool IsSuccess = false;

            IsSuccess = ClsVendorDataAccessLayer.DeleteVendor(VendorId);
            if (!IsSuccess)
                return false;

            IsSuccess = ClsPeople.DeletePerson(PersonId);
            
            return IsSuccess;
        }

        public static bool IsExistVendor(int VendorId)
        {
            return ClsVendorDataAccessLayer.IsExitVendorById(VendorId);
        }

        public static List<DTOVendor> GetAllVendors()
        {
            return ClsVendorDataAccessLayer.GetAllVendors();
        }

        public static ClsVendors FindVendor(int VendorId)
        {
            
            DTOVendor vendor = ClsVendorDataAccessLayer.FindVendorById(VendorId);

            if (vendor!=null)
            {

                return new ClsVendors(vendor,eMode.eUpdate);
            }
            else
            {
                return null;
            }
        }

        public static ClsVendors FindVendorByUserNameAndPassword(string VendorName, string Password)
        {
            
            DTOVendor vendor = ClsVendorDataAccessLayer.FindVendorByVendorNameAndPassword(VendorName,Password);

            if (vendor != null)
            {

                return new ClsVendors(vendor, eMode.eUpdate);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {



            if (_Mode == eMode.eAddNew)
            {
                if (_AddNewVendor())
                {
                    _Mode = eMode.eUpdate;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return _UpdateVendor();
            }
        }

    }
}
