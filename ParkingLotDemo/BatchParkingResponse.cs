namespace ParkingLotDemo;

public class BatchParkingResponse
{
    private List<Ticket> tickets;
    private bool isSuccess;
    private string errorMessage;

    public BatchParkingResponse(List<Ticket> tickets, bool isSuccess, string errorMessage)
    {
        this.tickets = tickets;
        this.isSuccess = isSuccess;
        this.errorMessage = errorMessage;
    }

    public List<Ticket> Tickets
    {
        get => tickets;
        set => tickets = value;
    }

    public bool IsSuccess
    {
        get => isSuccess;
        set => isSuccess = value;
    }

    public string ErrorMessage
    {
        get => errorMessage;
        set => errorMessage = value;
    }
}