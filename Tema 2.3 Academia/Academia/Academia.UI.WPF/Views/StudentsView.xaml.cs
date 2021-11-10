using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Academy.Lib.DAL;
using Academy.Lib.Models;

namespace Academy.UI.Views
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
            using (var repo = new StudentsRepository())
            {
                DgStudents.ItemsSource = repo.GetAll();
            }


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

            using (var repo = new StudentsRepository())
            {
                var addResult = repo.Add(student);
                if (addResult != StudentValidationsTypes.Ok)
                    MessageBox.Show($"error adding student:{addResult}");
                else
                    DgStudents.ItemsSource = repo.GetAll();
            }
            Clear();
        }

        public void Retrieve()
        {
            // le pedimos datos a la DB
            // ejemplo 1: Todos los datos (SELECT * FROM TABLE)

            using (var repo = new StudentsRepository())
            {
                var allStudents = repo.GetAll();


                // ejemplo 2: un estudiante en particular a partir de su id
                // este id aleatorio no existirá en la db por lo que dará null
                var idAleatorio = Guid.NewGuid();
                var student = repo.Get(idAleatorio);

                // eemplo 3: obtener un estudiante por el dni
                var student2 = repo.GetByDni("12345678a");
            }

        }

        public void Update()
        {
            if (SelectedStudent != null)
            {
                var studentCopy = SelectedStudent.Clone();

                studentCopy.Dni = TbDni.Text;
                studentCopy.Name = TbName.Text;
                studentCopy.Email = TbEmail.Text;


                using (var repo = new StudentsRepository())
                {
                    var editResult = repo.Update(studentCopy);
                    if (editResult != StudentValidationsTypes.Ok)
                        MessageBox.Show($"error editing student:{editResult}");
                    else
                        DgStudents.ItemsSource = repo.GetAll();
                }
            }
        }

        public void Delete(Student student)
        {
            if (student != null)
            {
                using (var repo = new StudentsRepository())
                {
                    var deleteResult = repo.Delete(student.Id);
                    if (deleteResult != StudentValidationsTypes.Ok)
                        MessageBox.Show($"error deleting student:{deleteResult}");
                    else
                        DgStudents.ItemsSource = repo.GetAll();
                }
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
