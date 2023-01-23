using Domain.Interfaces;
using Infra.Context;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);
// Add database configurarion.
builder.Services.AddDbContext<AppDbContext>
    (optionsBuilder => optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDb"));

// Add services to the container.
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof (BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof (BaseService<>));
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
