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

    public BatchParkingResponse Parking(List<Car> cars)
    {
        List<Ticket> tickets = new List<Ticket>();
        string message = string.Empty;
        foreach (var car in cars)
        {
            try
            {
                var ticket = this.Parking(car);
                tickets.Add(ticket);
            }
            catch (Exception e)
            {
                message = "Not enough positions.";
            }
        }

        return new BatchParkingResponse(tickets, message.Equals(String.Empty), message);
    }
}