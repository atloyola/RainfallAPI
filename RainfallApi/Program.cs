using Microsoft.OpenApi.Models;
using RainfallApi.Domain.Interfaces;
using RainfallApi.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Register repositories
builder.Services.AddTransient<IStationRepository, StationRepository>(); 
builder.Services.AddTransient<IReadingRepository, ReadingRepository>();
builder.Services.AddTransient<IMeasureRepository, MeasureRepository>();

// Swagger setup
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Rainfall API", 
        Version = "v1", 
        Description = "An API which provides rainfall reading data",
        Contact = new OpenApiContact
        {
            Name = "Sorted",
            Url = new Uri("https://www.sorted.com/")
        }        
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    c.IncludeXmlComments(xmlPath);
    c.AddServer(new OpenApiServer()
    {
         Url = "http://localhost:3000",
         Description = "Rainfall API"
    });    

});

var app = builder.Build();

// Development environment setup
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
