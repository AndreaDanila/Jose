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

namespace AcademyEF6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var repository = new Entities();

            if (repository.Students.Count() == 0)
            {
                var student1 = new Student();
                student1.Name = "Jose";
                student1.Email = "j@j.com";
                student1.Dni = "12345678a";

                var student2 = new Student();
                student2.Name = "Marta";
                student2.Email = "m@m.com";
                student2.Dni = "12345678b";

                repository.Students.Add(student1);
                repository.Students.Add(student2);
                repository.SaveChanges();
            }

            DgItems.ItemsSource = repository.Students.ToList();
        }
    }
}
