namespace WPFSampleProject.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using WPFSampleProject.Model;

    public class WPFSampleProjectInitializer : DropCreateDatabaseAlways<WPFSampleProjectDataContext>
    {
        /// <summary>
        /// provide default data for the Standard table while initializing the WPFSampleProject database
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(WPFSampleProjectDataContext context)
        {
            List<Person> persons1 = new List<Person>();
            List<Address> addresses1 = new List<Address>();

            List<Person> persons2 = new List<Person>();
            List<Address> addresses2 = new List<Address>();

            addresses1.Add(new Address(){
                Name = "Beirut",
                City = "Jal El Dib",
                Country = "Lebanon",
                Building = "Unidem Center",
                Floor = "2nd floor",
                Createdon = DateTime.UtcNow,
                Region = "Jal El Dib",
                Street = "Main street",
            });
            addresses1.Add(new Address()
            {
                Name = "Tripoli",
                City = "Bahsas",
                Country = "Lebanon",
                Building = "Kabanne",
                Floor = "5nd floor",
                Createdon = DateTime.UtcNow,
                Region = "North",
                Street = "Al noor street",
            });
            persons1.Add(new Person() {
                Name = "Elias",
                LastName = "El Khoury",
                FirstName = "Elias",
                Email = "Elias@smartrise.us",
                PhoneNumber = "+961 4 723140",
                CreatedOn = DateTime.UtcNow,
                Addresses = addresses1,
                DateOfBirth = new DateTime(1992, 10, 13),
                Gender = "Male"                
            });

            addresses2.Add(new Address()
            {
                Name = "Jounieh",
                City = "Jounieh",
                Country = "Lebanon",
                Building = "Main street",
                Floor = "5nd floor",
                Createdon = DateTime.UtcNow,
                Region = "Jounieh",
                Street = "Main street",
            });
            persons2.Add(new Person()
            {
                Name = "Ibrahim",
                LastName = "Chehade",
                FirstName = "Ibrahim",
                Email = "Ibrahim@smartrise.us",
                PhoneNumber = "+961 70 489 869",
                CreatedOn = DateTime.UtcNow,
                Addresses = addresses2,
                DateOfBirth = new DateTime(1992, 10, 13),
                Gender = "Male"
            });

            context.Person.AddRange(persons1);
            context.Person.AddRange(persons2);

            base.Seed(context);
        }
    }
}