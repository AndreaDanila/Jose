using System.Windows;
using School.Lib.Models;

namespace School.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var student = new Student();
        }
    }
}
