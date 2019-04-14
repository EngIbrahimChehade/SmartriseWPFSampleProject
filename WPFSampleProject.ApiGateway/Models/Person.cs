using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WPFSampleProject.ApiGateway.Models
{
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

        internal IEnumerable<Person> ToViewModel(IEnumerable<Model.Person> model)
        {
            return model.Select(r => {
                return new Person()
                {
                    Id = r.Id,
                    Name = r.Name,
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    CreatedBy = r.CreatedBy,
                    CreatedOn = r.CreatedOn,
                    DateOfBirth = r.DateOfBirth,
                    Email = r.Email,
                    Gender = r.Gender,
                    ModifiedBy = r.ModifiedBy,
                    ModifiedOn = r.ModifiedOn,
                    PhoneNumber = r.PhoneNumber
                };
            });
        }
    }
}