var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));

app.MapGet("/orders/{id:int}", (int id) =>
    Results.Ok(new { Id = id, Product = "Teclado mecanicoo", Status = "Pending" }));

app.Run();

public partial class Program;
