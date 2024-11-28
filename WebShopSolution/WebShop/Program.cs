using Microsoft.EntityFrameworkCore;
using WebShop.Data;
using WebShop.UnitOfWork;
using WebShop.Logging;
using WebShop.Notifications;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<INotificationObserver, EmailNotification>();


builder.Services.AddSingleton<WebShop.Logging.ILogger>(provider => new FileLogger("log.txt"));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Lägg till Swagger middleware
app.UseSwagger();
app.UseSwaggerUI();

// Aktivera HTTPS-omdirigering endast i produktionsmiljö
if (!app.Environment.IsDevelopment())
{
    // Endast aktivera HTTPS-omdirigering utanför utvecklingsmiljö
    app.UseHttpsRedirection();
}


app.UseAuthorization();


app.MapControllers();


app.Run();