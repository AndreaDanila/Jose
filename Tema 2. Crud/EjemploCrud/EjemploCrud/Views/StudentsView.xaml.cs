using EjemploCrud.Lib.DAL;
using EjemploCrud.Lib.Models;
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

namespace EjemploCrud.Views
{
    /// <summary>
    /// Lógica de interacción para StudentsView.xaml
    /// </summary>
    public partial class StudentsView : UserControl
    {
        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set
            {
                _selectedStudent = value;
                if (value == null)
                {
                    BtSave.Visibility = Visibility.Hidden;

                    TbDni.Text = string.Empty;
                    TbName.Text = string.Empty;
                    TbEmail.Text = string.Empty;
                }
                else
                {
                    BtSave.Visibility = Visibility.Visible;

                    TbDni.Text = value.Dni;
                    TbName.Text = value.Name;
                    TbEmail.Text = value.Email;
                }
            }
        }
        Student _selectedStudent;

        public StudentsView()
        {
            InitializeComponent();

            //Inicializa el DataGrid de Students
            DgStudents.ItemsSource = StudentsRepository.GetAll();


            var dict = new Dictionary<Guid, Student>();
            var list = new List<Student>();

            // así recorremos un diccionario
            foreach (var item in dict)
            {
                var key = item.Key;
                var student = item.Value;
                Console.WriteLine(student.Name);
            }

            // así recorremos una lista
            foreach (var student in list)
            {
                // ya tengo el student
                Console.WriteLine(student.Name);
            }

        }

        public void Clear()
        {
            SelectedStudent = null;
        }

        public void Create()
        {
            var student = new Student
            {
                Name = TbName.Text,
                Email = TbEmail.Text,
                Dni = TbDni.Text
            };

            // el objeto ya tiene la información 
            // le damos el id que está dentro del obj student
            // y luego le damos el objeto student

            var addResult = StudentsRepository.Add(student);
            if (addResult != StudentValidationsTypes.Ok)
                MessageBox.Show($"error adding student:{addResult}");
            else
                DgStudents.ItemsSource = StudentsRepository.GetAll();

            Clear();
        }

        public void Retrieve()
        {
            // le pedimos datos a la DB
            // ejemplo 1: Todos los datos (SELECT * FROM TABLE)

            var allStudents = StudentsRepository.GetAll();


            // ejemplo 2: un estudiante en particular a partir de su id
            // este id aleatorio no existirá en la db por lo que dará null
            var idAleatorio = Guid.NewGuid();
            var student = StudentsRepository.Get(idAleatorio);

            // eemplo 3: obtener un estudiante por el dni
            var student2 = StudentsRepository.GetByDni("12345678a");

        }

        public void Update()
        {
            if (SelectedStudent != null)
            {
                var studentCopy = SelectedStudent.Clone();

                studentCopy.Dni = TbDni.Text;
                studentCopy.Name = TbName.Text;
                studentCopy.Email = TbEmail.Text;

                var editResult = StudentsRepository.Update(studentCopy);
                if (editResult != StudentValidationsTypes.Ok)
                    MessageBox.Show($"error editing student:{editResult}");
                else
                    DgStudents.ItemsSource = StudentsRepository.GetAll();
            }
        }

        public void Delete(Student student)
        {
            if (student != null)
            {
                var deleteResult = StudentsRepository.Delete(student.Id);
                if (deleteResult != StudentValidationsTypes.Ok)
                    MessageBox.Show($"error deleting student:{deleteResult}");
                else
                    DgStudents.ItemsSource = StudentsRepository.GetAll();
            }
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void BtSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectedStudent = ((Button)sender).DataContext as Student;
        }

        private void BtClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            Update();
            SelectedStudent = null;
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = ((Button)sender).DataContext as Student;
            Delete(selectedStudent);
        }
    }
}
