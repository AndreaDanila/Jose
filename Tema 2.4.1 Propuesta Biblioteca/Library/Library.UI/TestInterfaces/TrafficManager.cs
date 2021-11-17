using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.TestInterfaces
{
    public class TrafficManager
    {
        public List<IVehicle> Vehicles { get; set; } 

        public TrafficManager()
        {
            var car1 = new Car();
            var moto1 = new Motorbike();

            Vehicles = new List<IVehicle>();

            Vehicles.Add(car1);
            Vehicles.Add(moto1);

            foreach (var v in Vehicles)
            {
                
            }

        }
    }
}
