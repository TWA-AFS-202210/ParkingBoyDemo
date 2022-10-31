namespace ParkingLotDemo;

public class ParkingBoy
{
    private ParkingLot _parkingLot;

    public ParkingBoy(ParkingLot parkingLot)
    {
        _parkingLot = parkingLot;
    }

    public Ticket Parking(Car car)
    {
        return _parkingLot.Parking(car);
    }

    public Car PickUp(Ticket ticket)
    {
        if (ticket == null)
        {
            return null;
        }
        return _parkingLot.PickUp(ticket);
    }

    public List<Ticket> Parking(List<Car> cars)
    {
        return cars.Select(Parking).ToList();
    }
}