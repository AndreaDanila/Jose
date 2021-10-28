namespace EjemploCrud.Lib.Models
{
    public class Student : Entity
    {
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Student()
        {
        }
    }
}
