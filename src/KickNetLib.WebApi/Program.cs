
using System.Reflection;
using KickNetLib.Api.Extensions;
using KickNetLib.Client.Extensions;
using KickNetLib.WebApi.Handlers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddKickLibClient(builder.Configuration);
builder.Services.AddKickLibApi(builder.Configuration);

// Register Factory handlers
builder.Services.AddTransient<WebHookHandlerFactory>();

// Register Handlers
var handlerTypes = Assembly.GetExecutingAssembly()
       .GetTypes()
       .Where(t => t.Name.EndsWith("Handler") && !t.IsAbstract && t.IsClass);

foreach (var handlerType in handlerTypes)
{
    // Dynamically register the handler types as Scoped services
    builder.Services.AddScoped(handlerType);
}

//Add support to logging with SERILOG
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
