using System.Text.Json;
using Praxos.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "praxos.db");
string connectionString = $"Data Source={dbPath}";

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen()
    .AddPersistence(connectionString)
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();