using Microsoft.EntityFrameworkCore;
using WebShop.Data;
using WebShop.Repositories;
using WebShop.UnitOfWork;
using WebShop.Logging;
using WebShop.Notifications;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext to the DI container
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Unit of Work in DI-container
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<INotificationObserver, EmailNotification>();

// Register logger in DI-container
builder.Services.AddSingleton<ILogger>(provider => new FileLogger("log.txt"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();