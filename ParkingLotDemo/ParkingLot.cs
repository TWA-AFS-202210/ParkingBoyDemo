namespace ParkingLotDemo;

public class ParkingLot
{
    private Dictionary<Ticket, Car> _parkingSpace;

    public ParkingLot()
    {
        _parkingSpace = new Dictionary<Ticket, Car>();
    }

    public Ticket Parking(Car car)
    {
        Ticket ticket = new Ticket(car.CarNumber);
        _parkingSpace.Add(ticket, car);
        return ticket;
    }

    public Car PickUp(Ticket ticket)
    {
        return _parkingSpace[ticket];
    }
}