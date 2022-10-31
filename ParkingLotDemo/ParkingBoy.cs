namespace ParkingLotDemo;

public class ParkingBoy : BaseParkingBoy
{
    public ParkingBoy(List<ParkingLot> parkingLots)
        : base(parkingLots)
    {
    }

    public ParkingBoy(ParkingLot lot) : base(lot)
    {
    }

    public override Ticket Parking(Car car)
    {
        var hasPositionLot = this.ParkingLots.Where(lot => lot.HasPosition()).FirstOrDefault((ParkingLot)null);
        if (hasPositionLot == null)
        {
            throw new LotFullException("Not enough positions.");
        }

        return hasPositionLot.Parking(car);
    }
}