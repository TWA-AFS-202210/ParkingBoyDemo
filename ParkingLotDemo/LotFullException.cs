namespace ParkingLotDemo;

public class LotFullException : Exception
{
    public LotFullException(string? message) : base(message)
    {
    }
}