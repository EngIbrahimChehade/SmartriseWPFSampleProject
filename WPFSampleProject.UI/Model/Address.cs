namespace WPFSampleProject.UI.Model
{
    using System;

    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Floor { get; set; }
        public string Building { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Createdon { get; set; }
        public DateTime? Modifiedon { get; set; }

        public int PersonId { get; set; }
    }
}