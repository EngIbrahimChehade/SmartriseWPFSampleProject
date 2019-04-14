namespace WPFSampleProject.UI
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Windows;

    public partial class UpdateAddress : Window
    {
        public int AddressId { get; set; }

        public UpdateAddress(int AddressId)
        {
            InitializeComponent();
            this.AddressId = AddressId;
            Load();
        }

        public void Load()
        {
            BindingComboBox();
            BindForm();
        }

        public void BindForm()
        {
            WebRequest request = WebRequest.Create("http://localhost:5423/Address/"+ AddressId);
            WebResponse response = request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseData = reader.ReadToEnd();
                var address = JsonConvert.DeserializeObject<Model.Address>(responseData);

                txtName.Text = address.Name;
                txtFloor.Text = address.Floor;
                txtBuilding.Text = address.Building;
                txtStreet.Text = address.Street;
                txtCity.Text = address.City;
                txtRegion.Text = address.Region;
                txtCountry.Text = address.Country;
                drpPerson.Text = address.Modifiedby;
            }

            //var manager = new WPFSampleProjectManager();
            //var address = manager.GetAddressById(AddressId);
            //txtName.Text = address.Name;
            //txtFloor.Text = address.Floor;
            //txtBuilding.Text = address.Building;
            //txtStreet.Text = address.Street;
            //txtCity.Text = address.City;
            //txtRegion.Text = address.Region;
            //txtCountry.Text = address.Country;
            //drpPerson.Text = address.Modifiedby;
            //Address
        }

        private void BindingComboBox()
        {
            WebRequest request = WebRequest.Create("http://localhost:5423/Person");
            WebResponse response = request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseData = reader.ReadToEnd();
                var personCollection = JsonConvert.DeserializeObject<IEnumerable<Model.Person>>(responseData);
                drpPerson.ItemsSource = personCollection;
            }

            //drpPerson.ItemsSource = manager.GetPersonCollection();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var payload = new Model.Address()
            {
                Id = AddressId,
                Name = txtName.Text,
                Floor = txtFloor.Text,
                Building = txtBuilding.Text,
                Street = txtStreet.Text,
                City = txtCity.Text,
                Region = txtRegion.Text,
                Country = txtCountry.Text,
                Modifiedby = drpPerson.Text,
                Modifiedon = DateTime.UtcNow
            };
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:5423/Address");
            request.Method = "PUT";
            request.ContentType = "application/xml";
            Stream dataStream = request.GetRequestStream();
            Serialize(dataStream, payload);
            dataStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string returnString = response.StatusCode.ToString();
            this.Hide();
        }

        public void Serialize(Stream output, object input)
        {
            var ser = new DataContractSerializer(input.GetType());
            ser.WriteObject(output, input);
        }
    }
}
