using ApiComicTienda.Models;
using ApiComicTienda.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});
builder.Services.AddSwaggerGen();

//Configurando Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
      policy =>
      {
          policy.WithOrigins("http://localhost:4200")
          .AllowAnyHeader()
          .AllowAnyMethod();
      });
});

//Configurando el DBCOntext para usar SQLServer
var connectionString = builder.Configuration.GetConnectionString("DBComicTienda");
builder.Services.AddDbContext<DBComicTiendaContext>(options => options.UseSqlServer(connectionString));

//Configurando la inyeccion de dependencia para IRepository
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IComicRepository, ComicRepository>();
builder.Services.AddScoped<IReceiptRepository, ReceiptRepository>();
builder.Services.AddScoped<ISalesDetailRepository, SalesDetailRepository>();
builder.Services.AddScoped<IFranchiseRepository, FranchiseRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyAllowedOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
