using CustomerWebApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbname = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");


//var dbHost = "localhost";
//var dbname = "dbm_customer";
//var dbPassword = "superpassword12345678";
var connectionString = $"Data Source={dbHost}; Initial Catalog={dbname};User ID=sa; Password={dbPassword}; TrustServerCertificate=true";

builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(connectionString));

//builder.Services.AddDbContext<CustomerDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultStringConnections"));
//});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
