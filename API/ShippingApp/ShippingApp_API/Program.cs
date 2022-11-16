using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShippingApp_DataAccess.Interfaces;
using ShippingApp_DataAccess.Repositories;
using ShippingApp_Domain;
using ShippingApp_Service.Interfaces;
using ShippingApp_Service.OfferService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
         builder.WithOrigins("http://localhost:4200")
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "ShippingApp API", Version = "v1" });
    
});

builder.Services.AddAuthorization();


var dbConnectionString = builder.Configuration["ConnectionStrings:DatabaseConnectionString"];

builder.Services.AddDbContext<ShippingAppDbContext>(options => options.UseSqlServer(dbConnectionString));


builder.Services.AddTransient<IOfferService, OfferService>();
builder.Services.AddTransient<IUserOffersRepository, UserOffersRepository>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
