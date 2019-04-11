namespace WPFSampleProject.UI
{
    using System.Windows;

    public partial class PersonWindow : Window
    {
        WPFSampleProjectManager manager = new WPFSampleProjectManager();

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
            var personCollection = manager.GetPersonCollection();
            personDataGrid.ItemsSource = personCollection;
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
                manager.DeletePerson(personeSelected.Id);
                Load();
            }
        }

        private void addressesBtn_Click(object sender, RoutedEventArgs e)
        {
            new Address().ShowDialog();
        }
    }
}
