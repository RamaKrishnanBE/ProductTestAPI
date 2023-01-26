using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductTest.DataAccess.EFCore;
using ProductTest.DataAccess.EFCore.Interfaces;
using ProductTest.DataAccess.Features.PipelineBehaviours;
using ProductTest.DataAccess.Features.ProductFeatures.Commands;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IApplicationContext, ApplicationContext>();

var assembly = AppDomain.CurrentDomain.Load("ProductTest.DataAccess.Features");

builder.Services.AddMediatR(assembly);
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();
app.UseRouting();

app.Run();
