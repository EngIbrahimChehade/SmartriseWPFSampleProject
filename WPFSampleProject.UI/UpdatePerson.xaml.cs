namespace WPFSampleProject.UI
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    
    public partial class UpdatePerson : Window
    {
        private List<Model.Address> addressesList = new List<Model.Address>();
        WPFSampleProjectManager manager = new WPFSampleProjectManager();

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
                manager.UpdatePerson(new Model.Person()
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
                });

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
            var person = manager.GetPersonById(PersonId);

            txtName.Text = person.Name;
            txtFirstName.Text = person.FirstName;
            txtLastName.Text = person.LastName;
            txtEmail.Text = person.Email;
            txtPhoneNumber.Text = person.PhoneNumber;
            txtDateOfBirth.Text = person.DateOfBirth.ToString();

            drpGender.SelectedValue = person.Gender;
            var addresses = manager.GetAddressCollectionByPersonId(person.Id);
            listView.ItemsSource = addresses;
            addressesList = addresses;
        }

        private void BindingComboBox()
        {
            var manager = new WPFSampleProjectManager();
            drpPerson.ItemsSource = manager.GetPersonCollection();
        }

        private void BindingAddressComboBox()
        {
            drpAddress.ItemsSource = manager.GetAddressCollection();            
        }

        private void AddAddressBtn_Click(object sender, RoutedEventArgs e)
        {
            var addressId = !string.IsNullOrWhiteSpace(drpAddress?.SelectedValue?.ToString()) ?
                Convert.ToInt32(drpAddress?.SelectedValue?.ToString()) : -1;
            if (addressId != -1)
            {
                var address = manager.GetAddressById(addressId);
                addressesList.Add(address);
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
    }
}