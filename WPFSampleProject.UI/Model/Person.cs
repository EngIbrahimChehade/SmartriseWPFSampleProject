namespace WPFSampleProject.UI.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual List<Address> Addresses { get; set; }
    }
}