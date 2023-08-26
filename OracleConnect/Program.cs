using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OracleConnect.DB;
using OracleConnect.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAddUser, AddUser>();
builder.Services.AddScoped<IValidator<UserDto>, ValidationUserDto>();
builder.Services.AddValidatorsFromAssemblyContaining<ValidationUserDto>();
builder.Services.AddScoped<Validation>();
builder.Services.AddDbContext<ConnectionOracle>(opt => opt.UseOracle(builder.Configuration.GetConnectionString("connection-db")));
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
