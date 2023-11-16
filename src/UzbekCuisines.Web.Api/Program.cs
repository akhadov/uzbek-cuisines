using Serilog;
using UzbekCuisines.Persistence;
using UzbekCuisines.Application;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using UzbekCuisines.Application.Orders.Create;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
//builder.Services.AddCarter();

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

app.UseAuthorization();

//app.MapCarter();

app.MapControllers();

app.Run();
