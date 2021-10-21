using System;
using ClassesAndObjects.Models;

namespace ClassesAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var persona1 = new Person("Pepe", new DateTime(1978, 12, 15));
            var persona2 = new Person("Lolo", new DateTime(1980, 12, 15));

            persona1.SayHello(persona2);
        }
    }
}
