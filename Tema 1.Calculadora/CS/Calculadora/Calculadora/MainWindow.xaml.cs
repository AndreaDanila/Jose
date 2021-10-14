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

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            Calculate("+");
        }

        public void Calculate(string op)
        {
            var num1 = double.Parse(TbNum1.Text);
            var num2 = double.Parse(TbNum2.Text);
            var msg = "";

            if (op == "+")
            {
                var resultado = num1 + num2;
                msg = "the sumatory is " + resultado;
            }
            else if (op == "-")
            {
                var resultado = num1 - num2;
                msg = "the substraction is " + resultado;
            }
            else if (op == "*")
            {
                var resultado = num1 * num2;
                msg = "the multiplication is " + resultado;
            }
            else if (op == "/")
            {
                var resultado = num1 / num2;
                msg = "the division is " + resultado;
            }

            LbOutput.Content = msg;
        }
    }
}
