using Ecommerce.Data;
using Ecommerce.Data.Repositories;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(mySQLConfiguration);

builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPOlicy", builder =>
    {

        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    } );

  
  
});


var app = builder.Build();
// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CORSPOlicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
