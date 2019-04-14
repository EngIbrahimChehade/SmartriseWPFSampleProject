namespace WPFSampleProject.ApiGateway.ViewModels
{
    using System;
    using WPFSampleProject.Model;

    public class CreateAddressViewModel
    {
        public string Name { get; set; }
        public string Floor { get; set; }
        public string Building { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Createdby { get; set; }

        internal Address ToModel()
        {
            return new Address()
            {
                Name = this.Name,
                Floor = this.Floor,
                Building = this.Building,
                Street = this.Street,
                City = this.City,
                Region = this.Region,
                Country = this.Country,
                Createdby = this.Createdby
            };
        }
    }
}
