using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WPFSampleProject.Model;

namespace WPFSampleProject.ApiGateway.ViewModels
{
    public class CreatePersonViewModel
    {
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

        public virtual List<Address> Addresses { get; set; }

        internal Person ToModel()
        {
            return new Person()
            {
                Name = this.Name,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                Gender = this.Gender,
                CreatedBy = this.CreatedBy,
                DateOfBirth = this.DateOfBirth,
                Addresses = this.Addresses               
            };
        }
    }
}
