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

        public void Example()
        {
            var student = new Student
            {
                Name = "Pepe",
                Dni = "A1"
            };
            Database.Students.Add(student.Dni, student);

            var subject = new Subject
            {
                Name = "Matemáticas"
            };
            Database.Materias.Add(subject.Name, subject);
            
            student.HacerExamen(8, "Matemáticas");

            var studentExams = student.MyExams;
        }
    }

    public static class Database
    {
        public static Dictionary<string, Student> Students = new Dictionary<string, Student>();
        public static Dictionary<string, Subject> Materias = new Dictionary<string, Subject>();
        public static List<Exam> Exams = new List<Exam>();

    }
}
