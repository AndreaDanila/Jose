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
    public partial class LoansView : UserControl
    {
        public LoansView()
        {
            InitializeComponent();
        }

        public void ReloadData()
        {
            using (var repo = new ClientsRepository())
            {
                //DgClients.ItemsSource = repo.GetAll();
                CbxClient.ItemsSource = repo.GetAll();
            }
        }

        private void BtCreate_Click(object sender, RoutedEventArgs e)
        {

            var client = CbxClient.SelectedItem as Client;
            MessageBox.Show(client.Email);
            
            //CreateLoan(client, bookCopy);
        }

        public void CreateLoan(Client client, BookCopy copy)
        {
            // creamos un client

            var loan = new Loan()
            {
                ClientId = client.Id,
                BookCopyId = copy.Id,
                RequestDate = DateTime.Now
            };

            //using (var repo = new LoansRepository())
            //{
            //    var result = repo.Add(loan);

            //    // manejar mensajes
            //}
        }
    }
}
