namespace WPFSampleProject.UI
{
    using System.Windows;

    public partial class Address : Window
    {
        WPFSampleProjectManager manager = new WPFSampleProjectManager();

        public Address()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            BindingDataGrid();
        }

        public void BindingDataGrid()
        {
            var addressCollection = manager.GetAddressCollection();
            addressDataGrid.ItemsSource = addressCollection;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var addressSelected = addressDataGrid?.SelectedItems[0] as Model.Address;
            if (addressSelected != null)
            {
                new UpdateAddress(addressSelected.Id).ShowDialog();
                Load();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var addressSelected = addressDataGrid?.SelectedItems[0] as Model.Address;
            if (addressSelected != null)
            {
                manager.DeleteAddress(addressSelected.Id);
                Load();
            }
        }

        private void CreateAddressBtn_Click(object sender, RoutedEventArgs e)
        {
            new CreateAddress().ShowDialog();
            Load();
        }

        private void PersonBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}