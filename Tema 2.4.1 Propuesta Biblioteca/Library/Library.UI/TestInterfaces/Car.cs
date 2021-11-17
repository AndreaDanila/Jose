using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.TestInterfaces
{
    public class Car : IVehicle
    {
        public int Doors { get; set; }
        public string Brand { get; set; }

        public void Start(double speed)
        {        
            // las acciones típicas de un coche
            // mete la llave
            // mete punto muerto
            // mete embrague
            // mete marcha
            // acelera
        }

        public void Stop()
        {
            // la acción parar típica de un coche

        }
    }
}
