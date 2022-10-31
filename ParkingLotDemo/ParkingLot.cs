namespace ParkingLotDemo;

public class ParkingLot
{
    private Dictionary<Ticket, Car> parkingSpace;
    private int size;

    public ParkingLot()
    {
        parkingSpace = new Dictionary<Ticket, Car>();
        this.size = 10;
    }

    public ParkingLot(int size)
    {
        parkingSpace = new Dictionary<Ticket, Car>();
        this.size = size;
    }

    public Ticket Parking(Car car)
    {
        if (this.parkingSpace.Count >= this.size)
        {
            if (parkingSpace.Count >= size)
            {
                throw new LotFullException("Not enough positions.");
            }
        }

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

    public bool HasPosition()
    {
        return this.parkingSpace.Count < this.size;
    }

    public int GetPosition()
    {
        return this.size - this.parkingSpace.Count;
    }
}