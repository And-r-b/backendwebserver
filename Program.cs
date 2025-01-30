var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

RentingService rentingService = new RentingService();

// rentingService.BorrowBook("Martian");
// rentingService.ListAllBooks();

app.MapGet("/", () => {

    var bookInventory = rentingService.ListAllBooks();
    var booksList = bookInventory.Select(inventoryEntry => inventoryEntry.Key);

    return Results.Ok(booksList);
});

app.Run();
