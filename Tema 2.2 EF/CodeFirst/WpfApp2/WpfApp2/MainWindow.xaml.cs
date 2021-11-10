using Academy.Lib.DAL;
using Academy.Lib.Models;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var repository = new AcademyDbContext();

            if (repository.Students.Count() == 0)
            {
                var student = new Student
                {
                    Id = Guid.NewGuid(),
                    Name = "Perico",
                    Email = "p@p.com",
                    Dni = "12345678a"
                };

                var subject = new Subject()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sexología",
                    Code = "S0069"
                };

                var enrollment = new Enrollment()
                {
                    Id = Guid.NewGuid(),
                    StudentId = student.Id,
                    SubjectId = subject.Id,
                    Date = DateTime.Now
                };

                repository.Students.Add(student);
                repository.Subjects.Add(subject);
                repository.Enrollments.Add(enrollment);

                repository.SaveChanges();
            }

            DgStudents.ItemsSource = repository.Students.ToList();
            DgSubjects.ItemsSource = repository.Subjects.ToList();
            DgEnrollments.ItemsSource = repository.Enrollments.ToList();
        }    
    }
}
