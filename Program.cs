using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using UsersService.Infrastructure;
using UsersService.Domain;
using EventsService.Infrastructure;
using EventsService.Domain;
using PaymentsService.Infrastructure;
using PaymentsService.Domain;

var builder = WebApplication.CreateBuilder(args);

// Servicios básicos
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias con EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios EF
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IEventRepository, EfEventRepository>();
builder.Services.AddScoped<IPaymentRepository, EfPaymentRepository>();

var app = builder.Build();

// Swagger habilitado siempre
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventHub API v1");
    c.RoutePrefix = string.Empty; // Swagger en la raíz: http://localhost:5000
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

