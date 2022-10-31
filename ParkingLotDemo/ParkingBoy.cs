namespace ParkingLotDemo;

public class ParkingBoy
{
    private ParkingLot _parkingLot;

    public ParkingBoy(ParkingLot parkingLot)
    {
        _parkingLot = parkingLot;
    }

    public Ticket ParkingCar(Car car)
    { 
        return _parkingLot.Parking(car);
    }

    public Car FetchCar(Ticket ticket)
    {
        return _parkingLot.FetchCar(ticket);
    }
}