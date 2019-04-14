namespace WPFSampleProject.UI
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.Serialization;
    using System.Windows;
    using WPFSampleProject.UI.Model;

    public partial class CreateAddress : Window
    {
        public CreateAddress()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            BindingPersonComboBox();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            var payload = new Model.Address()
            {
                Name = txtName.Text,
                Floor = txtFloor.Text,
                Building = txtBuilding.Text,
                Street = txtStreet.Text,
                City = txtCity.Text,
                Region = txtRegion.Text,
                Country = txtCountry.Text,
                Createdby = drpPerson.Text,
                Createdon = DateTime.UtcNow
            };
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:5423/Address");
            request.Method = "POST";
            request.ContentType = "application/xml";
            Stream dataStream = request.GetRequestStream();
            Serialize(dataStream, payload);
            dataStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string returnString = response.StatusCode.ToString();

            this.Hide();
        }

        private void BindingPersonComboBox()
        {
            WebRequest request = WebRequest.Create("http://localhost:5423/Person");
            WebResponse response = request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseData = reader.ReadToEnd();
                var personCollection = JsonConvert.DeserializeObject<IEnumerable<Person>>(responseData);
                drpPerson.ItemsSource = personCollection;
            }
            //drpPerson.ItemsSource = manager.GetPersonCollection();
        }

        public void Serialize(Stream output, object input)
        {
            var ser = new DataContractSerializer(input.GetType());
            ser.WriteObject(output, input);
        }
    }
}
