namespace ParkingLotDemo;

public class ParkingBoy
{
    private ParkingLot parkingLot;

    public ParkingBoy(ParkingLot parkingLot)
    {
        this.parkingLot = parkingLot;
    }

    public Ticket Parking(Car car)
    {
        return parkingLot.Parking(car);
    }

    public Car PickUp(Ticket ticket)
    {
        if (ticket == null)
        {
            throw new ParkingException("Please provide your parking ticket.");
        }

        var car = this.parkingLot.PickUp(ticket);
        if (car == null)
        {
            throw new ParkingException("Unrecognized parking ticket.");
        }

        return car;
    }

    public List<Ticket> Parking(List<Car> cars)
    {
        return cars.Select(Parking).ToList();
    }
}