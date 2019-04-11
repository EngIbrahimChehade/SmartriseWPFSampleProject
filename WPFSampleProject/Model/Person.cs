namespace WPFSampleProject.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// initialize the person class
    /// </summary>
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(4)]
        public string LastName { get; set; }
        
        [Required]
        [MinLength(11)]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual List<Address> Addresses { get; set; }

        public void preferredcontactmethod(string email, string SMS, string phone)
        {

        }
    }
}