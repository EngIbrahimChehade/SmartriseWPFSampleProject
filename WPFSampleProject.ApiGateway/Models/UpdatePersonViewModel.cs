using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WPFSampleProject.Model;

namespace WPFSampleProject.ApiGateway.ViewModels
{
    public class UpdatePersonViewModel
    {
        [Required]
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

        public DateTime? ModifiedOn { get; set; }

        public virtual List<Address> Addresses { get; set; }

        internal Person ToModel()
        {
            return new Person()
            {
                Id = this.Id,
                Name = this.Name,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                Gender = this.Gender,
                ModifiedBy = this.ModifiedBy,
                DateOfBirth = this.DateOfBirth,
                Addresses = this.Addresses             
            };
        }
    }
}
