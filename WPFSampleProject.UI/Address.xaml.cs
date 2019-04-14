namespace WPFSampleProject.UI
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Windows;

    public partial class Address : Window
    {
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
            WebRequest request = WebRequest.Create("http://localhost:5423/Address");
            WebResponse response = request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseData = reader.ReadToEnd();
                var addressCollection = JsonConvert.DeserializeObject<IEnumerable<Model.Address>>(responseData);
                addressDataGrid.ItemsSource = addressCollection;
            }
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

                WebRequest request = WebRequest.Create("http://localhost:5423/Address/" + addressSelected.Id);
                request.Method = "DELETE";
                WebResponse response = request.GetResponse();
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