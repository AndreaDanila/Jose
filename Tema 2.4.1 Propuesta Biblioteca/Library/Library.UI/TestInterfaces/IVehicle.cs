namespace Library.UI.TestInterfaces
{
    public interface IVehicle
    {
        string Brand { get; set; }
        void Start(double speed);

        void Stop();
    }
}
