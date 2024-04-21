using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using UtiliSense.Solar.Data.Contracts;
using UtiliSense.Solar.Data.Models;
using UtiliSense.Solar.Data.Repositories;

var allowSpecificOrigins = "_myAllowSpecificOrigins";
var allowAnyOrigin = "_myAllowAnyOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:32768/", "https://localhost:32768/");
                      });

    options.AddPolicy(name: allowAnyOrigin,
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                      });
});

builder.Services.AddScoped<ISolarPowerDataRepository, SolarPowerDataRepository>();
//builder.Services.AddScoped<IProductionDataService, ProductionDataService>();

builder.Host.UseSerilog((context, loggerConfiguration) =>
loggerConfiguration
    .ReadFrom.Configuration(context.Configuration));

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<UtilitiesDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "UtiliSense.Solar.Api",
        Description = "Pending",
        TermsOfService = new Uri("https://utilisense.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "UtiliSense",
            Email = string.Empty,
            Url = new Uri("https://utilisense.com/contact"),
        },
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT"),
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    // enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MySolarPower.API v1"));

    app.UseCors(allowAnyOrigin);
}
else
{
    app.UseCors(allowSpecificOrigins);
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
