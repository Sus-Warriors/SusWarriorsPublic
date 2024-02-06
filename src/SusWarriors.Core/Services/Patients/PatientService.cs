using Ardalis.GuardClauses;
using SusWarriors.Core.Interfaces.Data;
using SusWarriors.Core.Interfaces.Services.PatientAggregate;
using SusWarriors.Core.Models.PatientAggregate;
using SusWarriors.Core.Models.Specifications.PatientAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusWarriors.Core.Services.Patients;
public class PatientService : IPatientService
{
  private readonly IReadRepository<Patient> _patientReadRepository;

  public PatientService(IReadRepository<Patient> patientReadRepository)
  {
    _patientReadRepository = patientReadRepository;
  }

  public async Task<Patient> GetPatientByIdentifierNumber(string identifierNumber)
  {
    var patientSpec = new PatientByIdentifierNumberSpec(identifierNumber, false);
    var patient = await _patientReadRepository.SingleOrDefaultAsync(patientSpec);
    if (patient is null)
    {
      throw new NotFoundException(nameof(identifierNumber), nameof(patient));
    }
    return patient!;
  }
}
