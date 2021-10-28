using Academia.Models;
using System;
using System.Collections.Generic;

namespace Academia
{
    class Program
    {
        //static List<double> Marks { get; set; }

        public static Dictionary<string, Student> Students = new Dictionary<string, Student>();


        static string EscapeWord = "RUNYOUFOOLS";

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenid@ al programa para gestión de alumnos");
            Console.WriteLine("Para ir a la gestión de alumnos use la opción a");
            Console.WriteLine("Para obtener estadísticas use la opción e");

            //Marks = new List<double>();
            var keepdoing = true;

            while (keepdoing)
            {
                var option = Console.ReadKey().KeyChar;

                if (option == 'a')
                {
                    ShowStudentsMenu();
                }
                else if (option == 'e')
                {
                    ShowStatsMenu();
                }
            }
        }

        static void ShowStudentsMenu()
        {
            Console.WriteLine();
            ShowStudentsMenuOptions();

            var keepdoing = true;
            while (keepdoing)
            {
                var text = Console.ReadLine();

                switch (text)
                {
                    case "all":
                        ShowAllStudents();
                        break;
                    case "add":
                        AddNewStudent();
                        break;
                    case "edit":
                        break;
                    case "m":
                        keepdoing = false;
                        break;
                    default:
                        AddMark(text);
                        break;
                }
            }

            ShowMainMenu();
        }

        private static void ShowStudentsMenuOptions()
        {
            Console.WriteLine("--Menu de Estudiantes--");

            Console.WriteLine("Para ver todos los estudiantes escriba all");
            Console.WriteLine("Para añadir un nuevo estudiante escriba add");
            Console.WriteLine("Para editar un estudiante escriba edit + el dni");
            Console.WriteLine("Para borrar un estudiante escriba del + el dni");
            Console.WriteLine("Para volver al menú principal escriba m");
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("Vuelta al menú principal");
            Console.WriteLine("Para introducir notas de los alumnos use la opción a");
            Console.WriteLine("Para obtener estadísticas use la opción e");
        }

        static void ShowAllStudents()
        {
            foreach (var student in Students.Values)
            {
                Console.WriteLine($"{student.Dni} {student.Name}");
            }
        }

        static void AddNewStudent()
        {
            Console.WriteLine("Primero inserte el dni o escriba anular para interrumpir");

            var keepdoing = true;
            while (keepdoing)
            {
                var dni = Console.ReadLine();

                if (dni == "anular")
                {
                    break;
                }
                else if (string.IsNullOrEmpty(dni) || dni.Length != 9)
                {
                    Console.WriteLine("El dni está en un formato incorrecto");
                }
                else if (Students.ContainsKey(dni))
                {
                    Console.WriteLine($"Ya existe un estudiante con el dni {dni}");
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("Ahora inserte el nombre o escriba anular para interrumpir");
                        var name = Console.ReadLine();

                        if (name == "anular")
                        {
                            keepdoing = false;
                            break;
                        }

                        if (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("El nombre está vacío");
                        }
                        else
                        {
                            var student = new Student
                            {
                                Id = Guid.NewGuid(),
                                Dni = dni,
                                Name = name
                            };
                            Students.Add(student.Dni, student);
                            keepdoing = false;
                            break;
                        }
                    }
                }
            }

            ShowStudentsMenuOptions();
        }

        static void EditStudent()
        {
            Console.WriteLine("Primero inserte el dni o escriba anular para interrumpir");

            var dni = Console.ReadLine();

            if (dni == "" || dni.Length != 9)
            {
                Console.WriteLine("Formato de dni incorrecto, vuelva a meterlo");
            }
            else if (!Students.ContainsKey(dni))
            {
                Console.WriteLine("El dni introducido no es correcto, vuelva a meterlo");
            }
            else
            {
                Console.WriteLine("Introduzca el nuevo nombre");

                var name = Console.ReadLine();
                var student = Students[dni];
            }
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            var keepdoing = true;
            while (keepdoing)
            {
                var dni = Console.ReadLine();

                if(!Students.ContainsKey(dni))
                    Console.WriteLine("no existe este usuario");

                if (dni == "anular")
                {
                    break;
                }
                else if (string.IsNullOrEmpty(dni) || dni.Length != 9)
                {
                    Console.WriteLine("El dni está en un formato incorrecto");
                }
                else if (Students.ContainsKey(dni))
                {
                    Console.WriteLine($"Ya existe un estudiante con el dni {dni}");
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("Ahora inserte el nombre o escriba anular para interrumpir");
                        var name = Console.ReadLine();

                        if (name == "anular")
                        {
                            keepdoing = false;
                            break;
                        }

                        if (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("El nombre está vacío");
                        }
                        else
                        {
                            var student = new Student
                            {
                                Id = Guid.NewGuid(),
                                Dni = dni,
                                Name = name
                            };
                            Students.Add(student.Dni, student);
                            keepdoing = false;
                            break;
                        }
                    }
                }
            }

            ShowStudentsMenuOptions();
        }

        static void AddMark(string text)
        {
            var mark = 0.0;

            if (double.TryParse(text, out mark))
            {
                //Marks.Add(mark);
                Console.WriteLine("Nota introducida correctamente, añada otra nota más, pulse all para lista todas las notas o pulse m para volver al menú principal");
            }
            else
            {
                Console.WriteLine($"La nota introducida {text} no está en un formato correcto, vuelva a introducirla correctamente");
            }
        }

        static void ShowStatsMenu()
        {
            Console.WriteLine();
            Console.WriteLine("--Menu de Estadísticas--");

            Console.WriteLine("Para ver la media escriba avg");
            Console.WriteLine("Para ver la nota más alta escriba max");
            Console.WriteLine("Para ver la nota más baja escriba min");
            Console.WriteLine("Para volver al menú principal escriba m");

            var keepdoing = true;
            while (keepdoing)
            {
                var text = Console.ReadLine();

                switch (text)
                {
                    case "avg":
                        ShowAverage();
                        break;
                    case "max":
                        ShowMaximum();
                        break;
                    case "min":
                        ShowMinimum();
                        break;
                    case "m":
                        keepdoing = false;
                        break;
                    default:
                        Console.WriteLine("comando no reconocido, introduzca una opción válida");
                        break;
                }
            }
            ShowMainMenu();
        }

        static void ShowAverage()
        {
            //var suma = 0.0;
            //for (var i = 0; i < Marks.Count; i++)
            //{
            //    suma += Marks[i];
            //}

            //var average = suma / Marks.Count;
            //Console.WriteLine("la media los exámenes es: {0}", average);
        }

        static void ShowMaximum()
        {
            //var max = 0.0;
            //for (var i = 0; i < Marks.Count; i++)
            //{
            //    if (Marks[i] > max)
            //        max = Marks[i];
            //}

            //Console.WriteLine("la nota más alta es: {0}", max);
        }

        static void ShowMinimum()
        {
            //var min = 0.0;
            //if (Marks.Count == 0)
            //    min = 0.0;
            //else
            //    min = Marks[0];

            // esto (el operador ternario) hace lo mismo que lo de arriba
            //var min = Marks.Count == 0 ? 0.0 : Marks[0];

            //for (var i = 0; i < Marks.Count; i++)
            //{
            //    if (Marks[i] < min)
            //        min = Marks[i];
            //}

            //Console.WriteLine("la nota más baja es: {0}", min);
        }
    }
}
