namespace ParkingLotDemo;

public class Car
{
    private string carNumber;

    public Car(string carNumber)
    {
        CarNumber = carNumber;
    }

    public string CarNumber
    {
        get => carNumber;
        set => carNumber = value;
    }
}