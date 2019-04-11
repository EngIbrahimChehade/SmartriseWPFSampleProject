namespace WPFSampleProject.UI
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    
    public partial class CreatePerson : Window
    {
        private List<Model.Address> addressesList = new List<Model.Address>();
        WPFSampleProjectManager manager = new WPFSampleProjectManager();

        public CreatePerson()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            BindingPersonComboBox();
            BindingAddressComboBox();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ValidateInputData())
            {
                var addresses = listView.Items;
                manager.CreatePerson(new Model.Person() {
                    Name = txtName.Text,
                    LastName = txtLastName.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    CreatedBy = drpPerson.Text,
                    Gender = drpGender.Text,
                    CreatedOn = DateTime.UtcNow,
                    DateOfBirth = txtDateOfBirth.DisplayDate,
                    Email = txtEmail.Text,
                    FirstName = txtFirstName.Text,
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

        private void BindingPersonComboBox()
        {
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
                this.listView.Items.Add(address);
                this.addressesList.Add(address);
            }
        }

        private void DeleteAddressBtn_Click(object sender, RoutedEventArgs e)
        {
            if(listView.Items.Count==0 || listView?.SelectedItems.Count == 0)
                return;

            var addressSelected = listView?.SelectedItems[0] as Model.Address;
            if (addressSelected != null)
            {
                listView.Items.Remove(addressSelected);
                this.addressesList.Remove(addressSelected);
            }
        }
    }
}
