using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => {
    var jsonPayload = new {message = "Hello", content = "Testing testing"};
    return Results.Ok(jsonPayload);
});

app.MapPost("/", (BorrowedRequest requestBody) => {
    Console.WriteLine{$"Message: {requestBody.Message}"};
    Console.WriteLine{$"Number: {requestBody.Number}"};
    return Results.Accepted();
});

app.MapPut("/", () => {
    Console.WriteLine($"At dynamic segment");
    return Results.Unauthorized();
});

app.MapDelete("/", () => {
    return Results.Created();
});


app.Run();
