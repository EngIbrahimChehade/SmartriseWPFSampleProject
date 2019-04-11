namespace WPFSampleProject.UI
{
    using System;
    using System.Windows;
    using WPFSampleProject.Model;

    public partial class CreateAddress : Window
    {
        WPFSampleProjectManager manager = new WPFSampleProjectManager();

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
            var address = new Model.Address()
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
            manager.CreateAddress(address);
            this.Hide();
        }

        private void BindingPersonComboBox()
        {
            drpPerson.ItemsSource = manager.GetPersonCollection();
        }
    }
}
