using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => {
    var jsonPayload = new {message = "Hello"};
    return Results.Ok("All went well");
});

app.MapPost("/", () => {
    return Results.BadRequest();
});

app.MapPut("/", () => {
    return Results.Unauthorized();
});

app.MapDelete("/", () => {
    return Results.Created();
});


app.Run();
