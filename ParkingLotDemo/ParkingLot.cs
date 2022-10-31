namespace ParkingLotDemo;

public class ParkingLot
{
    private Dictionary<Ticket, Car> parkingSpace;

    public ParkingLot()
    {
        parkingSpace = new Dictionary<Ticket, Car>();
    }

    public Ticket Parking(Car car)
    {
        Ticket ticket = new Ticket(car.CarNumber);
        parkingSpace.Add(ticket, car);
        return ticket;
    }

    public Car PickUp(Ticket ticket)
    {
        if (!parkingSpace.ContainsKey(ticket))
        {
            return null;
        }

        var pickUpCar = parkingSpace[ticket];
        parkingSpace.Remove(ticket);
        return pickUpCar;
    }
}