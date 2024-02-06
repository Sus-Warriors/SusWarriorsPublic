using SusWarriors.Infrastructure.Data;
using SusWarriors.Infrastructure.Extensions;
using SusWarriors.Core.Extensions;
using System.Reflection;
using SusWarriors.Application.Interfaces;
using SusWarriors.Application.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDb<HealthDbContext>(config);
builder.Services.AddMediatR(opts => opts.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddDomainServices(config);
builder.Services.AddCors(opts => opts.AddDefaultPolicy(policy =>
{
  policy.AllowAnyOrigin()
  .AllowAnyMethod()
  .AllowAnyHeader();
}));
builder.Services.AddScoped<IMedItemService, MedItemService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddHttpLogging(opts => { });
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.BuildDatabase<HealthDbContext>();
} else
{
  app.BuildDatabase<HealthDbContext>();
}
app.UseRouting();
app.UseHttpsRedirection();

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.Run();
