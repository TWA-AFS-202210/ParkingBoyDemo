namespace ParkingLotDemo;

public class SmartParkingBoy : BaseParkingBoy
{
    public SmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
    {
    }

    public override Ticket Parking(Car car)
    {
        var maxSpaceLot = this.ParkingLots.OrderByDescending(lot => lot.GetPosition()).First();
        if (maxSpaceLot.HasPosition())
        {
            return maxSpaceLot.Parking(car);
        }

        throw new LotFullException("Not enough positions.");
    }
}