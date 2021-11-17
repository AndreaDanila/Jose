using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.TestInterfaces
{
    public class Motorbike : IVehicle
    {
        public string Brand { get; set; }
        public void Start(double speed)
        {
            // aquí van las cosas que hace un moto
        }

        public void Stop()
        {
        }
    }
}
