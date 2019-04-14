namespace WPFSampleProject
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WPFSampleProject.Data;
    using WPFSampleProject.Model;

    /// <summary>
    /// WPFSampleProject manager mainly contains methods CRUD
    /// </summary>
    public class WPFSampleProjectManager
    {
        #region Address

        /// <summary>
        /// Get all addresses collection
        /// </summary>
        /// <returns>list of Address</returns>
        public List<Address> GetAddressCollection()
        {
            using (var dataContext = new WPFSampleProjectDataContext())
            {
                return dataContext.Addresses.ToList();
            }
        }

        /// <summary>
        /// Get addresses collection by personId
        /// </summary>
        /// <param name="personId"></param>
        /// <returns>List address </returns>
        public List<Address> GetAddressCollectionByPersonId(int personId)
        {
            using (var dataContext = new WPFSampleProjectDataContext())
            {
                return dataContext.Addresses.Where(r=>r.PersonId == personId).ToList();
            }
        }

        /// <summary>
        /// Get address by addressId
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns>Address</returns>
        public Address GetAddressById(int addressId)
        {
            using (var dataContext = new WPFSampleProjectDataContext())
            {
                return dataContext.Addresses.SingleOrDefault(r => r.Id == addressId);
            }
        }

        /// <summary>
        /// CreateAddress method
        /// </summary>
        /// <param name="address"></param>
        public void CreateAddress(Address address)
        {
            using (var dataContext = new WPFSampleProjectDataContext())
            {
                dataContext.Addresses.Add(address);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// UpdateAddress method
        /// </summary>
        /// <param name="address"></param>
        public void UpdateAddress(Address address)
        {
            using (var dataContext = new WPFSampleProjectDataContext())
            {
                var oldAddress = dataContext.Addresses.SingleOrDefault(r => r.Id == address.Id);
                if (oldAddress == null)
                    return;

                oldAddress.Name = address.Name;
                oldAddress.Floor = address.Floor;
                oldAddress.Building = address.Building;
                oldAddress.Street = address.Street;
                oldAddress.City = address.City;
                oldAddress.Region = address.Region;
                oldAddress.Country = address.Country;
                oldAddress.Modifiedby = address.Modifiedby;
                oldAddress.Modifiedon = address.Modifiedon;

                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// DeleteAddress based on addressId
        /// </summary>
        /// <param name="addressId"></param>
        public void DeleteAddress(int addressId)
        {
            using (var dataContext = new WPFSampleProjectDataContext())
            {
                var oldAddress = dataContext.Addresses.SingleOrDefault(r => r.Id == addressId);
                if (oldAddress == null)

                dataContext.Addresses.Remove(oldAddress);
                dataContext.SaveChanges();
            }
        }
        #endregion

        #region Person
        /// <summary>
        /// Get person collection
        /// </summary>
        /// <returns></returns>
        public List<Person> GetPersonCollection()
        {
            using (var dataContext = new WPFSampleProjectDataContext())
            {
                return dataContext.Person.ToList();
            }
        }

        /// <summary>
        /// Create new person
        /// </summary>
        /// <param name="person"></param>
        public void CreatePerson(Person person)
        {
            using (var dataContext = new WPFSampleProjectDataContext())
            {
                dataContext.Person.Add(person);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Get person By Id
        /// </summary>
        /// <param name="personId"></param>
        /// <returns>Person</returns>
        public Person GetPersonById(int personId)
        {
            using (var dataContext = new WPFSampleProjectDataContext())
            {
                return dataContext.Person.SingleOrDefault(r => r.Id == personId);
            }
        }

        /// <summary>
        /// Update Person 
        /// </summary>
        /// <param name="person"></param>
        public void UpdatePerson(Person person)
        {
            using (var dataContext = new WPFSampleProjectDataContext())
            {
                var oldPerson = dataContext.Person.SingleOrDefault(r=> r.Id == person.Id);
                if (oldPerson == null)
                    return;

                oldPerson.Name = person.Name;
                oldPerson.FirstName = person.FirstName;
                oldPerson.LastName = person.LastName;
                oldPerson.Email = person.Email;
                oldPerson.PhoneNumber = person.PhoneNumber;
                oldPerson.DateOfBirth = person.DateOfBirth;
                oldPerson.Gender = person.Gender;
                oldPerson.ModifiedBy = person.ModifiedBy;
                oldPerson.ModifiedOn = person.ModifiedOn;
                oldPerson.Addresses = person.Addresses;

                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Delete person based on personId
        /// </summary>
        /// <param name="personId"></param>
        public void DeletePerson(int personId)
        {
            using (var dataContext = new WPFSampleProjectDataContext())
            {
                var oldPerson = dataContext.Person.ToList().SingleOrDefault(r => string.Equals(r.Id, personId));
                if (oldPerson == null)
                    return;

                dataContext.Person.Remove(oldPerson);
                dataContext.SaveChanges();
            }
        }
        #endregion
    }
}