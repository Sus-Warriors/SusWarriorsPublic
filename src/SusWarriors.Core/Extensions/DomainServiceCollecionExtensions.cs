using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SusWarriors.Core.Interfaces.Services.PatientAggregate;
using SusWarriors.Core.Services.Patients;

namespace SusWarriors.Core.Extensions;
public static class DomainServiceCollecionExtensions
{
  public static IServiceCollection AddDomainServices(this IServiceCollection services, 
    IConfiguration config)
  {
    services.AddScoped<IPatientService, PatientService>();
    return services;
  }
}
