using UtiliSense.Gas.Data.Contracts;
using UtiliSense.Gas.Data.Repository;
using UtiliSense.Gas.Services.Contracts;
using UtiliSense.Gas.Services.RulesBook;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IGasConsumptionRepository, GasConsumptionRepository>();
builder.Services.AddScoped<IRules, Rules>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
