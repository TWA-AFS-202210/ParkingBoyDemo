namespace ParkingLotDemo;

public abstract class BaseParkingBoy
{
    private List<ParkingLot> parkingLots;

    protected BaseParkingBoy(List<ParkingLot> parkingLots)
    {
        this.parkingLots = parkingLots;
    }

    protected BaseParkingBoy(ParkingLot lot)
    {
        this.parkingLots = new List<ParkingLot>() { lot };
    }

    public List<ParkingLot> ParkingLots
    {
        get => parkingLots;
        set => parkingLots = value;
    }

    public Car PickUp(Ticket ticket)
    {
        if (ticket == null)
        {
            throw new ParkingException("Please provide your parking ticket.");
        }

        var car = this.ParkingLots.Select(lot => lot.PickUp(ticket)).FirstOrDefault(car => car != null);
        if (car == null)
        {
            throw new ParkingException("Unrecognized parking ticket.");
        }

        return car;
    }

    public abstract Ticket Parking(Car car);

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