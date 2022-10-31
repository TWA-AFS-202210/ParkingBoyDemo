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
            return null;
        }

        return parkingLot.PickUp(ticket);
    }

    public List<Ticket> Parking(List<Car> cars)
    {
        return cars.Select(Parking).ToList();
    }
}