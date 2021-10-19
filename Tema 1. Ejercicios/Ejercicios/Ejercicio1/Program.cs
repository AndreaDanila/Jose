using System;

namespace Ejercicios
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Jose";
            string surname1 = "Freire";
            string surname2 = "Martín";

            int year = 1978;
            int month = 12;
            int day = 15;

            ExecutePhase1();
            ExecutePhase2(year);
            ExecutePhase3(year);
            ExecutePhase4(name, surname1, surname2, year, month, day);
        }

        private static void ExecutePhase1()
        {
            Console.WriteLine("Fase 1");

            string name = "Jose";
            string surname1 = "Freire";
            string surname2 = "Martín";

            int year = 1978;
            int month = 12;
            int day = 15;

            Console.WriteLine(name + " " + surname1 + " " + surname2);
            Console.WriteLine($"{name} {surname1} {surname2}");

            Console.WriteLine(day + "/" + month + "/" + year);
            Console.WriteLine($"{day}/{month}/{year}");
        }

        private static void ExecutePhase2(int bornYear)
        {
            Console.WriteLine("Fase 2");

            const int firstYear = 1948;
            const int jump = 4;


            //forma 1
            var counter = 0;

            for(var i = firstYear; i <= bornYear; i++)
            {
                var dif = i - firstYear;
                var calc = dif - (jump) * counter;
                
                if (calc == jump)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);

            //forma 2
            var counter2 = 0;
            for (var i = firstYear  + 1; i <= bornYear; i+=jump)
            {
                counter2++;
            }
            Console.WriteLine(counter2);

            //forma3
            double div = (bornYear - firstYear) / jump;
            double mod = ((bornYear - firstYear) % jump)/10;
            int counter3 = (int)(div - mod);

            Console.WriteLine($"div:{div} mod:{mod} total years:{counter3}");
        }

        private static void ExecutePhase3(int bornYear)
        {
            Console.WriteLine("Fase 3");

            const int firstYear = 1948;
            const int jump = 4;

            for (var i = firstYear; i <= bornYear; i++)
            {
                bool isLeap = ((i - firstYear) % jump) == 0;
                var msg = isLeap ? "bisiesto" : "normal";

                Console.WriteLine($"el año:{i} es {msg}");
            }
        }

        private static void ExecutePhase4(string name, 
                                    string surname1, 
                                    string surname2, 
                                    int year, 
                                    int month, 
                                    int day)
        {
            var fullName = $"{name} {surname1} {surname2}";
            var birthDate = $"{day}/{month}/{year}";

            bool isLeap = ((year) % 4) == 0;
            var msg = fullName + " " + birthDate + " y el año " + (isLeap ? "bisiesto" : "normal");
            Console.WriteLine(msg);
        }
    }
}
