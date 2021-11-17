using Library.Lib.DAL;
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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public IMenuHandler MenuHandler { get; set; }
        public LoginView()
        {
            InitializeComponent();
        }

        private void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            var result = Login(TbEmail.Text, PbPassword.Password);

            if (result)
            {
                if (MenuHandler != null)
                    MenuHandler.OnLoginSuccess();
            }
            else
            {
                MessageBox.Show("No se ha encontrado un usuario con ese email y password");
            }
        }

        public bool Login(string email, string password)
        {
            using(var repo = new LibrariansRepository())
            {
                var admin = repo
                    .GetAll()
                    .FirstOrDefault(x => x.Email == email && x.Password == password);

                if (admin == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
