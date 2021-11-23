using System;

namespace SpaceshipsShop.Lib.Models
{
    public class SpaceShip
    {
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Password { get; set; }

        public int FTLFactor { get; set; }

        public string Color { get; set; }

        public int PassengersCapacity { get; set; }
    }
}
