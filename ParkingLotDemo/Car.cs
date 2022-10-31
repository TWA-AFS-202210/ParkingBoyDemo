namespace ParkingLotDemo;

public class Car
{
    private string _carNumber;

    public Car(string carNumber)
    {
        CarNumber = carNumber;
    }

    public string CarNumber
    {
        get => _carNumber;
        set => _carNumber = value;
    }
}