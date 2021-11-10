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

namespace School
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var repository = new SchoolDbContext();

            if (repository.Students.Count() == 0)
            {
                var student1 = new Student()
                {
                    Name = "Pepe",
                    Dni = "12345678a",
                    Email = "p@p.com"
                };

                var subject1 = new Subject()
                {
                    Name = "Lengua",
                    Code = "S0001"
                };

                repository.Students.Add(student1);
                repository.Subjects.Add(subject1);
                repository.SaveChanges();

                var enroll1 = new Enrollment()
                {
                    StudentId = student1.Id,
                    SubjectId = subject1.Id,
                    Date = DateTime.Now
                };

                repository.Enrollments.Add(enroll1);

                repository.SaveChanges();
            }

            DgStudents.ItemsSource = repository.Students.ToList();
            DgSubjects.ItemsSource = repository.Subjects.ToList();
            DgEnrollments.ItemsSource = repository.Enrollments.ToList();
        }
    }
}
