using Library.Lib.DAL;
using Library.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library.UI.Views
{
    /// <summary>
    /// Interaction logic for ClientsView.xaml
    /// </summary>
    public partial class ClientsView : UserControl
    {
        public ClientsView()
        {
            InitializeComponent();
        }

        public void ReloadData()
        {
            using (var repo = new ClientsRepository())
            {
                DgClients.ItemsSource = repo.GetAll();
            }
        }

        private void BtCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateClient(TbName.Text, TbEmail.Text);
        }

        public void CreateClient(string name, string email)
        {
            // creamos un client

            var client = new Client()
            {
                Name = name,
                Email = email
            };

            using (var repo = new ClientsRepository())
            {
                var result = repo.Add(client);

                // manejar mensajes
            }
        }
    }
}
