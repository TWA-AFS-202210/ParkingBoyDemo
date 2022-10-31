namespace ParkingLotDemo;

public class Ticket
{
    private string _carNumber;

    public Ticket(string carNumber)
    {
        _carNumber = carNumber;
    }

    public string CarNumber
    {
        get => _carNumber;
        set => _carNumber = value;
    }
}