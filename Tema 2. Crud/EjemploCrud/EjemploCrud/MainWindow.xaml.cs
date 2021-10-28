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

namespace EjemploCrud
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

        public void Create()
        {
            //var student = new Student();
            //student.Id = Guid.NewGuid();
            //student.Name = "Perico";
            //student.Email = "perico@perico.com";
            //student.Dni = "12345678a";

            // esto es lo mismo que lo de arriba
            var student = new Student
            {                
                Name = TbName.Text,
                Email = TbEmail.Text,
                Dni = TbDni.Text
            };

            // el objeto ya tiene la información 
            // le damos el id que está dentro del obj student
            // y luego le damos el objeto student
            StudentsRepository.Add(student);
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

            // eemplo 3: obtener un studiante por el dni
            var student2 = StudentsRepository.GetByDni("12345678a");
           
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }
    }
}
