using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Domain;
using PaymentGateway.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PaymentRepository>();

// Add services to the container.
builder.Services.AddMvcCore();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//https://localhost:7110/paymentGatewayApi/
app.MapGet("/paymentGatewayApi/", () => "Accessing paymentGatewayApi !");


//POST //https://localhost:7110/paymentGatewayApi/payment
app.MapPost("/paymentGatewayApi/payment", ([FromServices] PaymentRepository repo, Payment payment) =>
{
    repo.Create(payment);
    return Results.Created($"/payment/{payment.Id}", payment);
});

//GET //https://localhost:7110/paymentGatewayApi/payment/{id}
app.MapGet("/paymentGatewayApi/payment/{id}", ([FromServices] PaymentRepository repo, Guid id) =>
{
    var payment = repo.GetById(id);
    return payment is not null ? Results.Ok(payment) : Results.NotFound();
});

app.Run();