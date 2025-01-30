using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => {
    return "Get from '/'";
});

app.MapPost("/", () => {
    return "Posting to '/'";
});

app.MapPut("/", () => {
    return "Updating to '/'";
});

app.MapDelete("/", () => {
    return "Deleting '/'";
});


app.Run();
