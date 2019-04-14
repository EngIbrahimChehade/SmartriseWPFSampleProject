namespace WPFSampleProject.UI
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Windows;

    public partial class UpdatePerson : Window
    {
        private List<Model.Address> addressesList = new List<Model.Address>();

        public int PersonId { get; set; }

        public UpdatePerson(int personId)
        {
            InitializeComponent();
            this.PersonId = personId;
            Load();
        }

        public void Load()
        {
            BindingComboBox();
            BindingAddressComboBox();
            BindForm();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputData())
            {
                var payload = new Model.Person()
                {
                    Id = PersonId,
                    Name = txtName.Text,
                    LastName = txtLastName.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    ModifiedOn = DateTime.UtcNow,
                    Gender = drpGender.Text,
                    DateOfBirth = txtDateOfBirth.DisplayDate,
                    Email = txtEmail.Text,
                    FirstName = txtFirstName.Text,
                    ModifiedBy = drpPerson?.Text,
                    Addresses = addressesList
                };
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:5423/Person");
                request.Method = "PUT";
                request.ContentType = "application/xml";
                Stream dataStream = request.GetRequestStream();
                Serialize(dataStream, payload);
                dataStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string returnString = response.StatusCode.ToString();

                this.Hide();
            }
        }

        private bool ValidateInputData()
        {
            var isValidEmail = DataValidation.IsValidEmail(txtEmail.Text);
            var isValidPhoneNumber = DataValidation.IsValidPhoneNumber(txtPhoneNumber.Text);
            var isValidFirstName = DataValidation.IsValidName(txtFirstName.Text);
            var isValidLastName = DataValidation.IsValidName(txtLastName.Text);

            var emailValidation = isValidEmail ?
                lblEamil.Visibility = Visibility.Hidden : lblEamil.Visibility = Visibility.Visible;
            var PhoneNumberValidation = isValidPhoneNumber ?
                lblPhoneNumber.Visibility = Visibility.Hidden : lblPhoneNumber.Visibility = Visibility.Visible;
            var firstNameValidation = isValidFirstName ?
                lblFirstName.Visibility = Visibility.Hidden : lblFirstName.Visibility = Visibility.Visible;
            var lastNameValidation = isValidLastName ?
                lblLastName.Visibility = Visibility.Hidden : lblLastName.Visibility = Visibility.Visible;

            return isValidEmail && isValidPhoneNumber && isValidFirstName && isValidLastName;
        }

        public void BindForm()
        {
            WebRequest request = WebRequest.Create("http://localhost:5423/Person/" + PersonId);
            WebResponse response = request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseData = reader.ReadToEnd();
                var person = JsonConvert.DeserializeObject<Model.Person>(responseData);
                txtName.Text = person.Name;
                txtFirstName.Text = person.FirstName;
                txtLastName.Text = person.LastName;
                txtEmail.Text = person.Email;
                txtPhoneNumber.Text = person.PhoneNumber;
                txtDateOfBirth.Text = person.DateOfBirth.ToString();
                drpGender.SelectedValue = person.Gender;
            }

            WebRequest request2 = WebRequest.Create("http://localhost:5423/Address/GetAddressCollectionByPersonId/" + PersonId);
            WebResponse response2 = request2.GetResponse();
            using (Stream dataStream = response2.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseData = reader.ReadToEnd();
                var addresses = JsonConvert.DeserializeObject<List<Model.Address>>(responseData);
                listView.ItemsSource = addresses;
                addressesList = addresses;
            }
        }

        private void BindingComboBox()
        {
            //var manager = new WPFSampleProjectManager();
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
        }

        private void BindingAddressComboBox()
        {
            WebRequest request = WebRequest.Create("http://localhost:5423/Address");
            WebResponse response = request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseData = reader.ReadToEnd();
                var addressCollection = JsonConvert.DeserializeObject<IEnumerable<Model.Address>>(responseData);
                drpAddress.ItemsSource = addressCollection;
            }
            //drpAddress.ItemsSource = manager.GetAddressCollection();            
        }

        private void AddAddressBtn_Click(object sender, RoutedEventArgs e)
        {
            var addressId = !string.IsNullOrWhiteSpace(drpAddress?.SelectedValue?.ToString()) ?
                Convert.ToInt32(drpAddress?.SelectedValue?.ToString()) : -1;
            if (addressId != -1)
            {

                WebRequest request = WebRequest.Create("http://localhost:5423/Address/" + addressId);
                WebResponse response = request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.  
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.  
                    string responseData = reader.ReadToEnd();
                    var address = JsonConvert.DeserializeObject<Model.Address>(responseData);
                    addressesList.Add(address);
                }

                //var address = manager.GetAddressById(addressId);
                //addressesList.Add(address);
                this.listView.ItemsSource = null;
                this.listView.ItemsSource = addressesList;
            }
        }

        private void DeleteAddressBtn_Click(object sender, RoutedEventArgs e)
        {
            if (listView.Items.Count == 0 || listView?.SelectedItems.Count == 0)
                return;

            var addressSelected = listView?.SelectedItems[0] as Model.Address;
            if (addressSelected != null && addressesList.Contains(addressSelected))
            {
                this.addressesList.Remove(addressSelected);
                listView.ItemsSource = null;
                listView.ItemsSource = addressesList;
            }
        }

        public void Serialize(Stream output, object input)
        {
            var ser = new DataContractSerializer(input.GetType());
            ser.WriteObject(output, input);
        }
    }
}