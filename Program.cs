var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

RentingService rentingService = new RentingService();

app.MapGet("/", () => {

    var bookInventory = rentingService.ListAllBooks();
    var booksList = bookInventory.Select(inventoryEntry => inventoryEntry.Key);

    return Results.Ok(booksList);
});

app.MapPost("/borrow", (BorrowedRequest borrowedRequest) => 
{
    BorrowReceipt? reciept = rentingService.BorrowBook(borrowedRequest.BookTitle);

    if (reciept == null)
    {
        return Results.BadRequest("Not Available");
    } 
    else
    {
        return Results.Accepted($"Borrowed book: {reciept.BookTitle}");
    }

});

app.Run();
