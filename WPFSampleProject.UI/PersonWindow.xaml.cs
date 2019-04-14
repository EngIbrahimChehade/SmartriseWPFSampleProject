namespace WPFSampleProject.UI
{
    using System.IO;
    using System.Net;
    using System.Windows;
    using Newtonsoft.Json;
    using WPFSampleProject.UI.Model;
    using System.Collections.Generic;

    public partial class PersonWindow : Window
    {
        public PersonWindow()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            BuildDataGrid();
        }

        public void BuildDataGrid()
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
                personDataGrid.ItemsSource = personCollection;
            }
        }

        private void CreatePersonBtn_Click(object sender, RoutedEventArgs e)
        {
            new CreatePerson().ShowDialog();
            Load();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var personeSelected = personDataGrid?.SelectedItems[0] as Model.Person;
            if (personeSelected != null)
            {
                new UpdatePerson(personeSelected.Id).ShowDialog();
                Load();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var personeSelected = personDataGrid?.SelectedItems[0] as Model.Person;

            if(personeSelected != null)
            {
                WebRequest request = WebRequest.Create("http://localhost:5423/Person/"+ personeSelected.Id);
                request.Method = "DELETE";
                WebResponse response = request.GetResponse();
                Load();
            }
        }

        private void addressesBtn_Click(object sender, RoutedEventArgs e)
        {
            new Address().ShowDialog();
        }
    }
}
