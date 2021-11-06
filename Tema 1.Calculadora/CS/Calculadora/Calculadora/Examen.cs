using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{

    class Examen
    {

        public Examen()
        {
            MiClase.Metodo();

            var c = new MiClase();

            var b = c;

            for (; ; )
            {

            }

            var d = new Dictionary<int, string>();

            foreach(var item in d)
            {

            }

            var result = MiClase.Metodo();
        }
    }

    public class MiClase
    {
        public static void Metodo()
        {
            var a1 = new A();
            var b1 = new B();

            var b2 = (A)b1;
            var a2 = (B)a1;
        }

        protected static void MetodoProtected()
        {

        }

        public void MetodoNoStatic()
        {

        }
    }

    public class A
    {
        public string PropA { get; set; }

        public A()
        {
            var a = this.PropA;

            if(true)
            {
                var o = 5;
            }
            else
            {
                var h = 4;
            }
            else if(true)
            {

            }
        }
    }

    public class B : A
    {
        public string PropB { get; set; }

        public B()
        {
            var a = this.PropA;
            var b = this.PropB;
        }
    }
}
