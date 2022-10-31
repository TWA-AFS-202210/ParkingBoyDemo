namespace ParkingLotDemo;

public class Ticket
{
    private string carNumber;

    public Ticket(string carNumber)
    {
        this.carNumber = carNumber;
    }

    public string CarNumber
    {
        get => carNumber;
        set => carNumber = value;
    }
}