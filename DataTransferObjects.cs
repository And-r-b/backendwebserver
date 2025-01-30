using Microsoft.AspNetCore.SignalR;

class BorrowedRequest
{
    public required string Message { get; set; }
    public required int Number { get; set; }
}