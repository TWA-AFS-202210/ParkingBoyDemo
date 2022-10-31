namespace ParkingLotDemo;

public class ParkingBoy
{
    private ParkingLot parkingLot;
    private List<ParkingLot> parkingLots;

    public ParkingBoy(ParkingLot parkingLot)
    {
        this.parkingLots = new List<ParkingLot>() { parkingLot };
    }

    public ParkingBoy(List<ParkingLot> parkingLots)
    {
        this.parkingLots = parkingLots;
    }

    public Ticket Parking(Car car)
    {
        var hasPositionLot = this.parkingLots.Where(lot => lot.HasPosition()).FirstOrDefault((ParkingLot)null);
        if (hasPositionLot == null)
        {
            throw new LotFullException("Not enough positions.");
        }

        return hasPositionLot.Parking(car);
    }

    public Car PickUp(Ticket ticket)
    {
        if (ticket == null)
        {
            throw new ParkingException("Please provide your parking ticket.");
        }

        var car = this.parkingLots[0].PickUp(ticket);
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

        return new BatchParkingResponse(tickets, message.Equals(string.Empty), message);
    }
}