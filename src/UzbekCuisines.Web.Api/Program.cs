using Serilog;
using UzbekCuisines.Persistence;
using UzbekCuisines.Application;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using UzbekCuisines.Application.Orders.Create;
using Carter;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCarter();

builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 3;
        options.QueueLimit = 3;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });

    rateLimiterOptions.AddSlidingWindowLimiter("sliding", options =>
    {
        options.Window = TimeSpan.FromSeconds(15);
        options.SegmentsPerWindow = 3;
        options.PermitLimit = 15;
    });

    rateLimiterOptions.AddTokenBucketLimiter("token", options =>
    {
        options.TokenLimit = 100;
        options.ReplenishmentPeriod = TimeSpan.FromSeconds(5);
        options.TokensPerPeriod = 10;
    });

    rateLimiterOptions.AddConcurrencyLimiter("concurrency", options =>
    {
        options.PermitLimit = 5;

    });
});

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddRebus(rebus => rebus
    .Routing(r =>
        r.TypeBased().MapAssemblyNamespaceOf<ApplicationAssemblyReference>("uzbekcuisines-queue"))
    .Transport(t =>
        t.UseRabbitMq(
            builder.Configuration.GetConnectionString("MessageBroker"),
        "uzbekcuisines-queue"))
    .Sagas(s => 
        s.StoreInPostgres(
            builder.Configuration.GetConnectionString("Database"),
            "sagas",
            "sagas_indexes")),
     onCreated: async bus =>
     {
         await bus.Subscribe<OrderConfirmationEmailSent>();
         await bus.Subscribe<OrderPaymentRequestSent>();
     });

builder.Services.AutoRegisterHandlersFromAssemblyOf<ApplicationAssemblyReference>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.ApplyMigartions();
}

app.UseHttpsRedirection();

app.UseRateLimiter();

app.UseAuthorization();

app.MapCarter();

app.MapControllers();

app.Run();
