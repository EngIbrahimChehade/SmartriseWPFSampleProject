namespace WPFSampleProject.UI
{
    using System;
    using System.Windows;

    public partial class UpdateAddress : Window
    {
        public int AddressId { get; set; }
        WPFSampleProjectManager manager = new WPFSampleProjectManager();

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
            var manager = new WPFSampleProjectManager();
            var address = manager.GetAddressById(AddressId);

            txtName.Text = address.Name;
            txtFloor.Text = address.Floor;
            txtBuilding.Text = address.Building;
            txtStreet.Text = address.Street;
            txtCity.Text = address.City;
            txtRegion.Text = address.Region;
            txtCountry.Text = address.Country;
            drpPerson.Text = address.Modifiedby;
            //Address
        }

        private void BindingComboBox()
        {
            drpPerson.ItemsSource = manager.GetPersonCollection();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            manager.UpdateAddress(new Model.Address()
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
            });

            this.Hide();
        }
    }
}
