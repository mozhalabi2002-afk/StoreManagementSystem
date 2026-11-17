using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class ClsPeople
    {
       public enum eMode { AddNew = 1, Update = 2 }
        public eMode Mode = eMode.AddNew;
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public int No { get; set; }
        public int PhoneNumber { get; set; }

        public PeopleDto People { get
            {
                return new PeopleDto(PersonId,FirstName,SecondName,LastName,No,PhoneNumber);
            } 
        }

        public ClsPeople(PeopleDto dto,eMode Mode=eMode.AddNew)
        {
            this.Mode = Mode;
            PersonId = dto.PersonId;
            FirstName = dto.FirstName;
            SecondName = dto.SecondName;
            LastName = dto.LastName;
            No = dto.No;
            PhoneNumber = dto.PhoneNumber;
        }

        private bool _AddNewPerson()
        {
            PersonId = ClsPeopleDataAccessLayer.AddNewPerson(People);

            return PersonId != -1;

        }

        private bool _UpdatePerson()
        {
            return ClsPeopleDataAccessLayer.UpdatePerson(People);
        }

        public static bool DeletePerson(int PersonId)
        {
            return ClsPeopleDataAccessLayer.DeletePerson(PersonId);
        }

        public static ClsPeople FindPerson(int PersonId)
        {

            PeopleDto people = ClsPeopleDataAccessLayer.FindPersonById(PersonId);

            if (people!=null)
            {
                return new ClsPeople(people,eMode.Update);
            }
            else
            {
                return null;
            }


        }

        public static bool IsPersonExist(int PersonId)
        {
            return ClsPeopleDataAccessLayer.IsExitPersonById(PersonId);
        }

        public static List<PeopleDto> GetAllPeople()
        {
            return ClsPeopleDataAccessLayer.GetAllPeople();
        }

        public static List<string> GetAllNo()
        {
            return ClsPeopleDataAccessLayer.GetAllNo();
        }

        public bool Save()
        {
            if (Mode == eMode.AddNew)
            {
                if (_AddNewPerson())
                {
                    Mode = eMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return _UpdatePerson();
            }
        }
    }
}
